﻿using System.ComponentModel;
using System.Windows.Controls;
using Aurora.EffectsEngine;
using Aurora.Profiles;
using Aurora.Settings.Layers.Controls;
using Aurora.Settings.Overrides;
using Newtonsoft.Json;

namespace Aurora.Settings.Layers
{
    public class PercentGradientLayerHandlerProperties : PercentLayerHandlerProperties<PercentGradientLayerHandlerProperties>
    {
        public PercentGradientLayerHandlerProperties()
        { }
        public PercentGradientLayerHandlerProperties(bool empty = false) : base(empty) { }

        [LogicOverridable("Gradient")]
        public EffectBrush _Gradient { get; set; }
        [JsonIgnore]
        public EffectBrush Gradient => Logic._Gradient ?? _Gradient ?? new EffectBrush().SetBrushType(EffectBrush.BrushType.Linear);

        public override void Default()
        {
            base.Default();
            _Gradient = new EffectBrush().SetBrushType(EffectBrush.BrushType.Linear);
        }
    }

    [LogicOverrideIgnoreProperty("_PrimaryColor")]
    [LogicOverrideIgnoreProperty("_SecondaryColor")]
    [LayerHandlerMeta(Name = "Percent (Gradient)", IsDefault = true)]
    public class PercentGradientLayerHandler : PercentLayerHandler<PercentGradientLayerHandlerProperties>
    {
        
        protected override UserControl CreateControl()
        {
            return new Control_PercentGradientLayer(this);
        }

        protected override void PropertiesChanged(object sender, PropertyChangedEventArgs args)
        {
            base.PropertiesChanged(sender, args);
            Invalidated = true;
        }
        public override EffectLayer Render(IGameState state)
        {
            if (Invalidated)
            {
                EffectLayer.Clear();
            }
            Invalidated = false;
            
            var value = Properties.Logic._Value ?? state.GetNumber(Properties.VariablePath);
            var maxvalue = Properties.Logic._MaxValue ?? state.GetNumber(Properties.MaxVariablePath);

            EffectLayer.PercentEffect(Properties.Gradient.GetColorSpectrum(), Properties.Sequence, value, maxvalue, Properties.PercentType, Properties.BlinkThreshold, Properties.BlinkDirection);
            return EffectLayer;
        }

        public override void SetApplication(Application profile)
        {
            if (profile != null)
            {
                if (!double.TryParse(Properties._VariablePath, out _) && !string.IsNullOrWhiteSpace(Properties._VariablePath) && !profile.ParameterLookup.IsValidParameter(Properties._VariablePath))
                    Properties._VariablePath = string.Empty;

                if (!double.TryParse(Properties._MaxVariablePath, out _) && !string.IsNullOrWhiteSpace(Properties._MaxVariablePath) && !profile.ParameterLookup.IsValidParameter(Properties._MaxVariablePath))
                    Properties._MaxVariablePath = string.Empty;
            }
            (Control as Control_PercentGradientLayer).SetApplication(profile);
            Application = profile;
        }

        public override void Dispose()
        {
            EffectLayer.Dispose();
            base.Dispose();
        }
    }
}
