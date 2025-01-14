﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using CSScriptLib;

namespace Aurora.Devices.ScriptedDevice;

internal class ScriptDeviceLoader : IDeviceLoader
{
    private readonly string _scriptFolder;

    public ScriptDeviceLoader(string scriptFolder)
    {
        _scriptFolder = scriptFolder;
    }

    public IEnumerable<IDevice> LoadDevices()
    {
        if (!Directory.Exists(_scriptFolder))
            Directory.CreateDirectory(_scriptFolder);

        var files = Directory.GetFiles(_scriptFolder);
        if (files.Length == 0)
            yield break;

        Global.logger.Information($"Loading device scripts from {_scriptFolder}");

        foreach (var deviceScript in files)
        {
            yield return LoadScript(deviceScript);
        }
    }

    private IDevice? LoadScript(string deviceScript)
    {
        var ext = Path.GetExtension(deviceScript);
        switch (ext)
        {
            case ".py":
                return LoadPython(deviceScript);
            case ".cs":
                CompileCs(deviceScript);
                break;
            case ".dll":
                return LoadDll(deviceScript);
            default:
                Global.logger.Error("Script with path {Path} has an unsupported type/ext! ({Extension})", deviceScript, ext);
                break;
        }
        return null;
    }

    private IDevice? LoadPython(string deviceScript)
    {
        var scope = Global.PythonEngine.ExecuteFile(deviceScript);
        if (scope.TryGetVariable("main", out var mainType))
        {
            var script = Global.PythonEngine.Operations.CreateInstance(mainType);

            IDevice scriptedDevice = new ScriptedDevice(script);
            Global.logger.Information($"Loaded device script {deviceScript}");
            return scriptedDevice;
        }

        Global.logger.Error("Script \"{Script}\" does not contain a public 'main' class", deviceScript);
        return null;
    }

    private void CompileCs(string deviceScript)
    {
        CSScript.RoslynEvaluator.CompileAssemblyFromFile(deviceScript, deviceScript + ".dll");
        File.Delete(deviceScript);  //TODO DON'T DELETE!!! create new process for compiling
        MessageBox.Show(deviceScript + " is compiled. Aurora will crash but script will be loaded next time.");
    }

    private IDevice? LoadDll(string deviceScript)
    {
        var data = File.ReadAllBytes(deviceScript);
        var scriptAssembly = Assembly.Load(data);
        var typ = scriptAssembly.ExportedTypes.First( type => type.FullName?.StartsWith("css_root+") ?? false);
        var constructorInfo = typ.GetConstructor(Type.EmptyTypes);
        if (constructorInfo == null)
        {
            Global.logger.Information($"Script {deviceScript} does not have parameterless constructor or device class isn't the first one");
            return null;
        }
        dynamic script = Activator.CreateInstance(typ);
        IDevice scriptedDevice = new ScriptedDevice(script);
        Global.logger.Information($"Loaded device script {deviceScript}");
        return scriptedDevice;
    }
}