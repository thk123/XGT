using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XGT.PCInput
{
    public static class KeyboardManager
    {
        private static KeyboardState mCurrentKeyboardState, mPreviousKeyboardState;
        private static int[] keyDuration;

        /// <summary>
        /// The current state of the keyboard as of the last time the update method was caled
        /// </summary>
        public static KeyboardState CurrentKeyboardState
        {
            get
            {
                return mCurrentKeyboardState;
            }
        }

        /// <summary>
        /// The state of the keyboard from the time before the last update call
        /// </summary>
        public static KeyboardState PreviousKeyboardState
        {
            get
            {
                return mPreviousKeyboardState;
            }
        }

        /// <summary>
        /// Occurs when any key on the keyboard is pressed
        /// </summary>
        public static event EventHandler KeyPressed = delegate{};

        #region Individual Key Events
        public static event EventHandler AKeyPressed = delegate { };
        public static event EventHandler BKeyPressed = delegate { };
        public static event EventHandler CKeyPressed = delegate { };
        public static event EventHandler DKeyPressed = delegate { };
        public static event EventHandler EKeyPressed = delegate { };
        public static event EventHandler FKeyPressed = delegate { };
        public static event EventHandler GKeyPressed = delegate { };
        public static event EventHandler HKeyPressed = delegate { };
        public static event EventHandler IKeyPressed = delegate { };
        public static event EventHandler JKeyPressed = delegate { };
        public static event EventHandler KKeyPressed = delegate { };
        public static event EventHandler LKeyPressed = delegate { };
        public static event EventHandler MKeyPressed = delegate { };
        public static event EventHandler NKeyPressed = delegate { };
        public static event EventHandler OKeyPressed = delegate { };
        public static event EventHandler PKeyPressed = delegate { };
        public static event EventHandler QKeyPressed = delegate { };
        public static event EventHandler RKeyPressed = delegate { };
        public static event EventHandler SKeyPressed = delegate { };
        public static event EventHandler TKeyPressed = delegate { };
        public static event EventHandler UKeyPressed = delegate { };
        public static event EventHandler VKeyPressed = delegate { };
        public static event EventHandler WKeyPressed = delegate { };
        public static event EventHandler XKeyPressed = delegate { };
        public static event EventHandler YKeyPressed = delegate { };
        public static event EventHandler ZKeyPressed = delegate { };
        public static event EventHandler EscapeKeyPressed = delegate { };
        public static event EventHandler LWinKeyPressed = delegate { };
        public static event EventHandler RWinKeyPressed = delegate { };
        public static event EventHandler AppsKeyPressed = delegate { };
        public static event EventHandler NumPad0KeyPressed = delegate { };
        public static event EventHandler NumPad1KeyPressed = delegate { };
        public static event EventHandler NumPad2KeyPressed = delegate { };
        public static event EventHandler NumPad3KeyPressed = delegate { };
        public static event EventHandler NumPad4KeyPressed = delegate { };
        public static event EventHandler NumPad5KeyPressed = delegate { };
        public static event EventHandler NumPad6KeyPressed = delegate { };
        public static event EventHandler NumPad7KeyPressed = delegate { };
        public static event EventHandler NumPad8KeyPressed = delegate { };
        public static event EventHandler NumPad9KeyPressed = delegate { };
        public static event EventHandler MultiplyKeyPressed = delegate { };
        public static event EventHandler AddKeyPressed = delegate { };
        public static event EventHandler SeparatorKeyPressed = delegate { };
        public static event EventHandler SubtractKeyPressed = delegate { };
        public static event EventHandler DecimalKeyPressed = delegate { };
        public static event EventHandler DivideKeyPressed = delegate { };
        public static event EventHandler F1KeyPressed = delegate { };
        public static event EventHandler F2KeyPressed = delegate { };
        public static event EventHandler F3KeyPressed = delegate { };
        public static event EventHandler F4KeyPressed = delegate { };
        public static event EventHandler F5KeyPressed = delegate { };
        public static event EventHandler F6KeyPressed = delegate { };
        public static event EventHandler F7KeyPressed = delegate { };
        public static event EventHandler F8KeyPressed = delegate { };
        public static event EventHandler F9KeyPressed = delegate { };
        public static event EventHandler F10KeyPressed = delegate { };
        public static event EventHandler F11KeyPressed = delegate { };
        public static event EventHandler F12KeyPressed = delegate { };
        public static event EventHandler F13KeyPressed = delegate { };
        public static event EventHandler F14KeyPressed = delegate { };
        public static event EventHandler F15KeyPressed = delegate { };
        public static event EventHandler F16KeyPressed = delegate { };
        public static event EventHandler F17KeyPressed = delegate { };
        public static event EventHandler F18KeyPressed = delegate { };
        public static event EventHandler F19KeyPressed = delegate { };
        public static event EventHandler F20KeyPressed = delegate { };
        public static event EventHandler F21KeyPressed = delegate { };
        public static event EventHandler F22KeyPressed = delegate { };
        public static event EventHandler F23KeyPressed = delegate { };
        public static event EventHandler F24KeyPressed = delegate { };
        public static event EventHandler NumLockKeyPressed = delegate { };
        public static event EventHandler ScrollKeyPressed = delegate { };
        public static event EventHandler LShiftKeyKeyPressed = delegate { };
        public static event EventHandler RShiftKeyKeyPressed = delegate { };
        public static event EventHandler LControlKeyKeyPressed = delegate { };
        public static event EventHandler RControlKeyKeyPressed = delegate { };
        public static event EventHandler LMenuKeyPressed = delegate { };
        public static event EventHandler RMenuKeyPressed = delegate { };
        public static event EventHandler BrowserBackKeyPressed = delegate { };
        public static event EventHandler BrowserForwardKeyPressed = delegate { };
        public static event EventHandler BrowserRefreshKeyPressed = delegate { };
        public static event EventHandler BrowserStopKeyPressed = delegate { };
        public static event EventHandler BrowserSearchKeyPressed = delegate { };
        public static event EventHandler BrowserFavoritesKeyPressed = delegate { };
        public static event EventHandler BrowserHomeKeyPressed = delegate { };
        public static event EventHandler VolumeMuteKeyPressed = delegate { };
        public static event EventHandler VolumeDownKeyPressed = delegate { };
        public static event EventHandler VolumeUpKeyPressed = delegate { };
        public static event EventHandler MediaNextTrackKeyPressed = delegate { };
        public static event EventHandler MediaPreviousTrackKeyPressed = delegate { };
        public static event EventHandler MediaStopKeyPressed = delegate { };
        public static event EventHandler MediaPlayPauseKeyPressed = delegate { };
        public static event EventHandler LaunchMailKeyPressed = delegate { };
        public static event EventHandler SelectMediaKeyPressed = delegate { };
        public static event EventHandler LaunchApplication1KeyPressed = delegate { };
        public static event EventHandler LaunchApplication2KeyPressed = delegate { };
        public static event EventHandler Oem1KeyPressed = delegate { };
        public static event EventHandler OemplusKeyPressed = delegate { };
        public static event EventHandler OemcommaKeyPressed = delegate { };
        public static event EventHandler OemMinusKeyPressed = delegate { };
        public static event EventHandler OemPeriodKeyPressed = delegate { };
        public static event EventHandler OemQuestionKeyPressed = delegate { };
        public static event EventHandler OemtildeKeyPressed = delegate { };
        public static event EventHandler OemOpenBracketsKeyPressed = delegate { };
        public static event EventHandler Oem5KeyPressed = delegate { };
        public static event EventHandler Oem6KeyPressed = delegate { };
        public static event EventHandler Oem7KeyPressed = delegate { };
        public static event EventHandler Oem8KeyPressed = delegate { };
        public static event EventHandler AttnKeyPressed = delegate { };
        public static event EventHandler CrselKeyPressed = delegate { };
        public static event EventHandler ExselKeyPressed = delegate { };
        public static event EventHandler EraseEofKeyPressed = delegate { };
        public static event EventHandler PlayKeyPressed = delegate { };
        public static event EventHandler ZoomKeyPressed = delegate { };
        #endregion

        /// <summary>
        /// Initalse the KeyboardManager - must be called before the update function
        /// </summary>
        public static void Init()
        {
            mCurrentKeyboardState = Keyboard.GetState();
            mPreviousKeyboardState = Keyboard.GetState();
           
            keyDuration = new int[(int)Keys.Zoom+1];
        }

        /// <summary>
        /// Update the Keyboard set and fires any events
        /// </summary>
        /// <param name="gameTime">A reference to the current gameTime instance, used for maintaining how long keys have been pressed for</param>
        public static void Update(GameTime gameTime)
        {
            mPreviousKeyboardState = mCurrentKeyboardState;
            mCurrentKeyboardState = Keyboard.GetState();
            for (int keyId = 0; keyId < (int)Keys.Zoom; keyId++)
            {
                if (mCurrentKeyboardState.IsKeyDown((Keys)keyId))
                {
                    if (keyDuration[keyId] == 0)
                    {
                        KeyPressed(null, new KeyPressedEventArgs((Keys)keyId));
                        handleKeyPress((Keys)keyId);
                    }
                    keyDuration[keyId] += gameTime.ElapsedGameTime.Milliseconds;
                }
                else
                {
                    keyDuration[keyId] = 0;
                }
            }
        }

        /// <summary>
        /// Gets the amount of time a key has been pressed in miliseconds
        /// </summary>
        /// <param name="lKey">The key to check</param>
        /// <returns>The time in miliseconds the key has been pressed for (0 means not pressed)</returns>
        public static int GetTimePressed(Keys lKey)
        {
            return keyDuration[(int)lKey];
        }

        private static void handleKeyPress(Keys keyPressed)
        {
            switch (keyPressed.ToString())
            {
                case "A":
                    AKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "B":
                    BKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "C":
                    CKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "D":
                    DKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "E":
                    EKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F":
                    FKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "G":
                    GKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "H":
                    HKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "I":
                    IKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "J":
                    JKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "K":
                    KKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "L":
                    LKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "M":
                    MKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "N":
                    NKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "O":
                    OKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "P":
                    PKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Q":
                    QKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "R":
                    RKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "S":
                    SKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "T":
                    TKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "U":
                    UKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "V":
                    VKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "W":
                    WKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "X":
                    XKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Y":
                    YKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Z":
                    ZKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Escape":
                    EscapeKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "LWin":
                    LWinKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "RWin":
                    RWinKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Apps":
                    AppsKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "NumPad0":
                    NumPad0KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "NumPad1":
                    NumPad1KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "NumPad2":
                    NumPad2KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "NumPad3":
                    NumPad3KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "NumPad4":
                    NumPad4KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "NumPad5":
                    NumPad5KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "NumPad6":
                    NumPad6KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "NumPad7":
                    NumPad7KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "NumPad8":
                    NumPad8KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "NumPad9":
                    NumPad9KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Multiply":
                    MultiplyKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Add":
                    AddKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Separator":
                    SeparatorKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Subtract":
                    SubtractKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Decimal":
                    DecimalKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Divide":
                    DivideKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F1":
                    F1KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F2":
                    F2KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F3":
                    F3KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F4":
                    F4KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F5":
                    F5KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F6":
                    F6KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F7":
                    F7KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F8":
                    F8KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F9":
                    F9KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F10":
                    F10KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F11":
                    F11KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F12":
                    F12KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F13":
                    F13KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F14":
                    F14KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F15":
                    F15KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F16":
                    F16KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F17":
                    F17KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F18":
                    F18KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F19":
                    F19KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F20":
                    F20KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F21":
                    F21KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F22":
                    F22KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F23":
                    F23KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "F24":
                    F24KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "NumLock":
                    NumLockKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Scroll":
                    ScrollKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "LShiftKey":
                    LShiftKeyKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "RShiftKey":
                    RShiftKeyKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "LControlKey":
                    LControlKeyKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "RControlKey":
                    RControlKeyKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "LMenu":
                    LMenuKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "RMenu":
                    RMenuKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "BrowserBack":
                    BrowserBackKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "BrowserForward":
                    BrowserForwardKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "BrowserRefresh":
                    BrowserRefreshKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "BrowserStop":
                    BrowserStopKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "BrowserSearch":
                    BrowserSearchKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "BrowserFavorites":
                    BrowserFavoritesKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "BrowserHome":
                    BrowserHomeKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "VolumeMute":
                    VolumeMuteKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "VolumeDown":
                    VolumeDownKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "VolumeUp":
                    VolumeUpKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "MediaNextTrack":
                    MediaNextTrackKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "MediaPreviousTrack":
                    MediaPreviousTrackKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "MediaStop":
                    MediaStopKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "MediaPlayPause":
                    MediaPlayPauseKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "LaunchMail":
                    LaunchMailKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "SelectMedia":
                    SelectMediaKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "LaunchApplication1":
                    LaunchApplication1KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "LaunchApplication2":
                    LaunchApplication2KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Oem1":
                    Oem1KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Oemplus":
                    OemplusKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Oemcomma":
                    OemcommaKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "OemMinus":
                    OemMinusKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "OemPeriod":
                    OemPeriodKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "OemQuestion":
                    OemQuestionKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Oemtilde":
                    OemtildeKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "OemOpenBrackets":
                    OemOpenBracketsKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Oem5":
                    Oem5KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Oem6":
                    Oem6KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Oem7":
                    Oem7KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Oem8":
                    Oem8KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Attn":
                    AttnKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Crsel":
                    CrselKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Exsel":
                    ExselKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "EraseEof":
                    EraseEofKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Play":
                    PlayKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

                case "Zoom":
                    ZoomKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;

            }
        }
    }
}
