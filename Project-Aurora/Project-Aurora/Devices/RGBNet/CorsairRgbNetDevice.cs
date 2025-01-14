﻿using System;
using System.Threading.Tasks;
using Aurora.Settings;
using Aurora.Utils;
using RGB.NET.Devices.Corsair;

namespace Aurora.Devices.RGBNet;

public class CorsairRgbNetDevice : RgbNetDevice
{
    protected override CorsairDeviceProvider Provider => CorsairDeviceProvider.Instance;

    public override string DeviceName => "Corsair (RGB.NET)";

    public CorsairRgbNetDevice()
    {
        const string sdkLink = "https://www.corsair.com/ww/en/s/downloads";
        _tooltips = new DeviceTooltips(false, true, null, sdkLink);
    }

    protected override void RegisterVariables(VariableRegistry variableRegistry)
    {
        base.RegisterVariables(variableRegistry);

        variableRegistry.Register($"{DeviceName}_exclusive", false, "Request exclusive control");
    }

    protected override bool OnShutdown()
    {
        base.OnShutdown();

        return !App.Closing;
    }

    protected override async Task ConfigureProvider()
    {
        await base.ConfigureProvider();

        await DesktopUtils.WaitSessionUnlock();
        Global.logger.Information("Lock released");

        var exclusive = Global.Configuration.VarRegistry.GetVariable<bool>($"{DeviceName}_exclusive");

        CorsairDeviceProvider.ExclusiveAccess = exclusive;
        CorsairDeviceProvider.ConnectionTimeout = new TimeSpan(0, 0, 5);

        Provider.SessionStateChanged += SessionStateChanged;
    }

    private void SessionStateChanged(object? sender, CorsairSessionState e)
    {
        if (e != CorsairSessionState.Closed) return;
        Provider.SessionStateChanged -= SessionStateChanged;

        IsInitialized = false;
    }
}