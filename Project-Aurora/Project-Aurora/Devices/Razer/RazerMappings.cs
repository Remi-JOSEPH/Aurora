﻿using Colore.Effects.Keyboard;
using Colore.Effects.Mouse;
using System.Collections.Generic;

namespace Aurora.Devices.Razer
{
    public static class RazerMappings
    {
        public static readonly Dictionary<DeviceKeys, Key> keyboardDictionary = new Dictionary<DeviceKeys, Key>()
        {
            [DeviceKeys.ESC] = Key.Escape,
            [DeviceKeys.F1] = Key.F1,
            [DeviceKeys.F2] = Key.F2,
            [DeviceKeys.F3] = Key.F3,
            [DeviceKeys.F4] = Key.F4,
            [DeviceKeys.F5] = Key.F5,
            [DeviceKeys.F6] = Key.F6,
            [DeviceKeys.F7] = Key.F7,
            [DeviceKeys.F8] = Key.F8,
            [DeviceKeys.F9] = Key.F9,
            [DeviceKeys.F10] = Key.F10,
            [DeviceKeys.F11] = Key.F11,
            [DeviceKeys.F12] = Key.F12,
            [DeviceKeys.PRINT_SCREEN] = Key.PrintScreen,
            [DeviceKeys.SCROLL_LOCK] = Key.Scroll,
            [DeviceKeys.PAUSE_BREAK] = Key.Pause,
            [DeviceKeys.LOGO] = Key.Logo,
            //[DeviceKeys.JpnYen] = Key.JpnYen,
            // [DeviceKeys.KorPipe] = Key.KorPipe,
            [DeviceKeys.G1] = Key.Macro1,
            [DeviceKeys.TILDE] = Key.OemTilde,
            [DeviceKeys.ONE] = Key.D1,
            [DeviceKeys.TWO] = Key.D2,
            [DeviceKeys.THREE] = Key.D3,
            [DeviceKeys.FOUR] = Key.D4,
            [DeviceKeys.FIVE] = Key.D5,
            [DeviceKeys.SIX] = Key.D6,
            [DeviceKeys.SEVEN] = Key.D7,
            [DeviceKeys.EIGHT] = Key.D8,
            [DeviceKeys.NINE] = Key.D9,
            [DeviceKeys.ZERO] = Key.D0,
            [DeviceKeys.MINUS] = Key.OemMinus,
            [DeviceKeys.EQUALS] = Key.OemEquals,
            [DeviceKeys.BACKSPACE] = Key.Backspace,
            [DeviceKeys.INSERT] = Key.Insert,
            [DeviceKeys.HOME] = Key.Home,
            [DeviceKeys.PAGE_UP] = Key.PageUp,
            [DeviceKeys.NUM_LOCK] = Key.NumLock,
            [DeviceKeys.NUM_SLASH] = Key.NumDivide,
            [DeviceKeys.NUM_ASTERISK] = Key.NumMultiply,
            [DeviceKeys.NUM_MINUS] = Key.NumSubtract,
            [DeviceKeys.G2] = Key.Macro2,
            [DeviceKeys.TAB] = Key.Tab,
            [DeviceKeys.Q] = Key.Q,
            [DeviceKeys.W] = Key.W,
            [DeviceKeys.E] = Key.E,
            [DeviceKeys.R] = Key.R,
            [DeviceKeys.T] = Key.T,
            [DeviceKeys.Y] = Key.Y,
            [DeviceKeys.U] = Key.U,
            [DeviceKeys.I] = Key.I,
            [DeviceKeys.O] = Key.O,
            [DeviceKeys.P] = Key.P,
            [DeviceKeys.OPEN_BRACKET] = Key.OemLeftBracket,
            [DeviceKeys.CLOSE_BRACKET] = Key.OemRightBracket,
            [DeviceKeys.BACKSLASH] = Key.OemBackslash,
            [DeviceKeys.DELETE] = Key.Delete,
            [DeviceKeys.END] = Key.End,
            [DeviceKeys.PAGE_DOWN] = Key.PageDown,
            [DeviceKeys.NUM_SEVEN] = Key.Num7,
            [DeviceKeys.NUM_EIGHT] = Key.Num8,
            [DeviceKeys.NUM_NINE] = Key.Num9,
            [DeviceKeys.NUM_PLUS] = Key.NumAdd,
            [DeviceKeys.G3] = Key.Macro3,
            [DeviceKeys.CAPS_LOCK] = Key.CapsLock,
            [DeviceKeys.A] = Key.A,
            [DeviceKeys.S] = Key.S,
            [DeviceKeys.D] = Key.D,
            [DeviceKeys.F] = Key.F,
            [DeviceKeys.G] = Key.G,
            [DeviceKeys.H] = Key.H,
            [DeviceKeys.J] = Key.J,
            [DeviceKeys.K] = Key.K,
            [DeviceKeys.L] = Key.L,
            [DeviceKeys.SEMICOLON] = Key.OemSemicolon,
            [DeviceKeys.APOSTROPHE] = Key.OemApostrophe,
            [DeviceKeys.HASHTAG] = Key.EurPound,
            //[DeviceKeys.Kor2] = Key.Kor2,
            [DeviceKeys.ENTER] = Key.Enter,
            [DeviceKeys.NUM_FOUR] = Key.Num4,
            [DeviceKeys.NUM_FIVE] = Key.Num5,
            [DeviceKeys.NUM_SIX] = Key.Num6,
            [DeviceKeys.G4] = Key.Macro4,
            [DeviceKeys.LEFT_SHIFT] = Key.LeftShift,
            [DeviceKeys.BACKSLASH_UK] = Key.EurBackslash,
            //[DeviceKeys.Kor3] = Key.Kor3,
            [DeviceKeys.Z] = Key.Z,
            [DeviceKeys.X] = Key.X,
            [DeviceKeys.C] = Key.C,
            [DeviceKeys.V] = Key.V,
            [DeviceKeys.B] = Key.B,
            [DeviceKeys.N] = Key.N,
            [DeviceKeys.M] = Key.M,
            [DeviceKeys.COMMA] = Key.OemComma,
            [DeviceKeys.PERIOD] = Key.OemPeriod,
            [DeviceKeys.FORWARD_SLASH] = Key.OemSlash,
            //[DeviceKeys.JpnSlash] = Key.JpnSlash,
            //[DeviceKeys.Kor4] = Key.Kor4,
            [DeviceKeys.RIGHT_SHIFT] = Key.RightShift,
            [DeviceKeys.ARROW_UP] = Key.Up,
            [DeviceKeys.NUM_ONE] = Key.Num1,
            [DeviceKeys.NUM_TWO] = Key.Num2,
            [DeviceKeys.NUM_THREE] = Key.Num3,
            [DeviceKeys.NUM_ENTER] = Key.NumEnter,
            [DeviceKeys.G5] = Key.Macro5,
            [DeviceKeys.LEFT_CONTROL] = Key.LeftControl,
            [DeviceKeys.LEFT_WINDOWS] = Key.LeftWindows,
            [DeviceKeys.LEFT_ALT] = Key.LeftAlt,
            // [DeviceKeys.Jpn3] = Key.Jpn3,
            //  [DeviceKeys.Kor5] = Key.Kor5,
            [DeviceKeys.SPACE] = Key.Space,
            //  [DeviceKeys.Jpn4] = Key.Jpn4,
            //[DeviceKeys.Kor6] = Key.Kor6,
            //[DeviceKeys.Jpn5] = Key.Jpn5,
            //[DeviceKeys.Kor7] = Key.Kor7,
            [DeviceKeys.RIGHT_ALT] = Key.RightAlt,
            [DeviceKeys.FN_Key] = Key.Function,
            [DeviceKeys.APPLICATION_SELECT] = Key.RightMenu,
            [DeviceKeys.RIGHT_CONTROL] = Key.RightControl,
            [DeviceKeys.ARROW_LEFT] = Key.Left,
            [DeviceKeys.ARROW_DOWN] = Key.Down,
            [DeviceKeys.ARROW_RIGHT] = Key.Right,
            [DeviceKeys.NUM_ZERO] = Key.Num0,
            [DeviceKeys.NUM_PERIOD] = Key.NumDecimal,//
        };
        public static readonly Dictionary<DeviceKeys, int> mousepadDictionary = new Dictionary<DeviceKeys, int>()
        {
            [DeviceKeys.MOUSEPADLIGHT1] = 14,
            [DeviceKeys.MOUSEPADLIGHT2] = 13,
            [DeviceKeys.MOUSEPADLIGHT3] = 12,
            [DeviceKeys.MOUSEPADLIGHT4] = 11,
            [DeviceKeys.MOUSEPADLIGHT5] = 10,
            [DeviceKeys.MOUSEPADLIGHT6] = 9,
            [DeviceKeys.MOUSEPADLIGHT7] = 8,
            [DeviceKeys.MOUSEPADLIGHT8] = 7,
            [DeviceKeys.MOUSEPADLIGHT9] = 6,
            [DeviceKeys.MOUSEPADLIGHT10] = 5,
            [DeviceKeys.MOUSEPADLIGHT11] = 4,
            [DeviceKeys.MOUSEPADLIGHT12] = 3,
            [DeviceKeys.MOUSEPADLIGHT13] = 2,
            [DeviceKeys.MOUSEPADLIGHT14] = 1,
            [DeviceKeys.MOUSEPADLIGHT15] = 0,
        };
        public static readonly Dictionary<DeviceKeys, GridLed> mouseDictionary = new Dictionary<DeviceKeys, GridLed>()
        {
            [DeviceKeys.Peripheral_ScrollWheel] = GridLed.ScrollWheel,
            [DeviceKeys.Peripheral_Logo] = GridLed.Logo,
            [DeviceKeys.Peripheral] = GridLed.Backlight,//???
            [DeviceKeys.PERIPHERAL_LIGHT1] = GridLed.LeftSide1,
            [DeviceKeys.PERIPHERAL_LIGHT2] = GridLed.LeftSide2,
            [DeviceKeys.PERIPHERAL_LIGHT3] = GridLed.LeftSide3,
            [DeviceKeys.PERIPHERAL_LIGHT4] = GridLed.LeftSide4,
            [DeviceKeys.PERIPHERAL_LIGHT5] = GridLed.LeftSide5,
            [DeviceKeys.PERIPHERAL_LIGHT6] = GridLed.LeftSide6,
            [DeviceKeys.PERIPHERAL_LIGHT7] = GridLed.LeftSide7,
            [DeviceKeys.PERIPHERAL_LIGHT8] = GridLed.Bottom1,
            [DeviceKeys.PERIPHERAL_LIGHT9] = GridLed.Bottom2,
            [DeviceKeys.PERIPHERAL_LIGHT10] = GridLed.Bottom3,
            [DeviceKeys.PERIPHERAL_LIGHT11] = GridLed.Bottom4,
            [DeviceKeys.PERIPHERAL_LIGHT12] = GridLed.Bottom5,
            [DeviceKeys.PERIPHERAL_LIGHT13] = GridLed.RightSide1,
            [DeviceKeys.PERIPHERAL_LIGHT14] = GridLed.RightSide2,
            [DeviceKeys.PERIPHERAL_LIGHT15] = GridLed.RightSide3,
            [DeviceKeys.PERIPHERAL_LIGHT16] = GridLed.RightSide4,
            [DeviceKeys.PERIPHERAL_LIGHT17] = GridLed.RightSide5,
            [DeviceKeys.PERIPHERAL_LIGHT18] = GridLed.RightSide6,
            [DeviceKeys.PERIPHERAL_LIGHT19] = GridLed.RightSide7
        };
    }
}
