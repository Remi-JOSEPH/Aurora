﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Reflection;

namespace Aurora.Devices.ScriptedDevice;

public class DllDeviceLoader : IDeviceLoader
{
    private readonly string _dllFolder;

    private List<Assembly> _deviceAssemblies;

    public DllDeviceLoader(string dllFolder)
    {
        _dllFolder = dllFolder;
    }

    public IEnumerable<IDevice> LoadDevices()
    {
        if (!Directory.Exists(_dllFolder))
            Directory.CreateDirectory(_dllFolder);

        var files = Directory.GetFiles(_dllFolder, "*.dll");
        if (files.Length == 0)
            return ImmutableList<IDevice>.Empty;

        Global.logger.Information($"Loading devices plugins from {_dllFolder}");

        _deviceAssemblies = new List<Assembly>();
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

        var devices = new List<IDevice>();
        foreach (var deviceDll in files)
        {
            try
            {
                var deviceAssembly = Assembly.LoadFile(deviceDll);

                foreach (var type in deviceAssembly.GetExportedTypes())
                {
                    if (!typeof(IDevice).IsAssignableFrom(type) || type.IsAbstract) continue;
                    _deviceAssemblies.Add(deviceAssembly);
                    var devDll = (IDevice)Activator.CreateInstance(type);
                    Global.logger.Information($"Loaded device plugin {deviceDll}");
                    devices.Add(devDll);
                }
            }
            catch (Exception e)
            {
                Global.logger.Error($"Error loading device dll: {deviceDll}. Exception: {e.Message}");
            }
        }

        return devices;
    }

    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.RequestingAssembly == null || !_deviceAssemblies.Contains(args.RequestingAssembly)) return null;
        var searchDir = Path.GetDirectoryName(args.RequestingAssembly.Location);
        foreach (var file in Directory.GetFiles(searchDir, "*.dll"))
        {
            var assemblyName = AssemblyName.GetAssemblyName(file);
            if (assemblyName.FullName == args.Name)
            {
                return AppDomain.CurrentDomain.Load(assemblyName);
            }
        }
        foreach (var file in Directory.GetFiles(Path.Combine(searchDir, "x64"), "*.dll"))
        {
            var assemblyName = AssemblyName.GetAssemblyName(file);
            if (assemblyName.FullName == args.Name)
            {
                return AppDomain.CurrentDomain.Load(assemblyName);
            }
        }
        return null;
    }
}