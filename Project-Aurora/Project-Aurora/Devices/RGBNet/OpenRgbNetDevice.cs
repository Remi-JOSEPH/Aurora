﻿using System.Threading.Tasks;
using Aurora.Settings;
using RGB.NET.Devices.OpenRGB;

namespace Aurora.Devices.RGBNet;

public class OpenRgbNetDevice : RgbNetDevice
{ 
    public override string DeviceName => "OpenRGB (RGB.NET)";
    
    protected override OpenRGBDeviceProvider Provider => OpenRGBDeviceProvider.Instance;
    
    private readonly OpenRGBServerDefinition _openRgbServerDefinition = new()
    {
        ClientName = "Aurora (RGB.NET)"
    };

    public OpenRgbNetDevice()
    {
        var info = "Sdk server needs to be enabled in OpenRGB";
        var sdkLink = "https://openrgb.org/";
        _tooltips = new DeviceTooltips(true, true, info, sdkLink);
    }

    protected override Task ConfigureProvider()
    {
        base.ConfigureProvider();
        
        var ip = Global.Configuration.VarRegistry.GetVariable<string>($"{DeviceName}_ip");
        var port = Global.Configuration.VarRegistry.GetVariable<int>($"{DeviceName}_port");

        _openRgbServerDefinition.Ip = ip;
        _openRgbServerDefinition.Port = port;

        Provider.AddDeviceDefinition(_openRgbServerDefinition);
        return Task.CompletedTask;
    }

    protected override void RegisterVariables(VariableRegistry variableRegistry)
    {
        base.RegisterVariables(variableRegistry);
        
        variableRegistry.Register($"{DeviceName}_sleep", 0, "Sleep for", 1000, 0);
        variableRegistry.Register($"{DeviceName}_ip", "127.0.0.1", "IP Address");
        variableRegistry.Register($"{DeviceName}_port", 6742, "Port", 1024, 65535);
        variableRegistry.Register($"{DeviceName}_fallback_key", DeviceKeys.Peripheral_Logo, "Key to use for unknown leds. Select NONE to disable");
    }
}