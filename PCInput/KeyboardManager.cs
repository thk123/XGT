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
        /// Occurs once when any key on the keyboard is pressed
        /// </summary>
        public static event EventHandler KeyPressed = delegate { };
        /// <summary>
        /// Occurs when any key on the keyboard is held
        /// </summary>
        public static event EventHandler KeyHeld = delegate { };

        #region Individual Key Pressed Events
        public static event EventHandler BackKeyPressed = delegate { };
        public static event EventHandler TabKeyPressed = delegate { };
        public static event EventHandler EnterKeyPressed = delegate { };
        public static event EventHandler PauseKeyPressed = delegate { };
        public static event EventHandler CapsLockKeyPressed = delegate { };
        public static event EventHandler KanaKeyPressed = delegate { };
        public static event EventHandler KanjiKeyPressed = delegate { };
        public static event EventHandler EscapeKeyPressed = delegate { };
        public static event EventHandler ImeConvertKeyPressed = delegate { };
        public static event EventHandler ImeNoConvertKeyPressed = delegate { };
        public static event EventHandler SpaceKeyPressed = delegate { };
        public static event EventHandler PageUpKeyPressed = delegate { };
        public static event EventHandler PageDownKeyPressed = delegate { };
        public static event EventHandler EndKeyPressed = delegate { };
        public static event EventHandler HomeKeyPressed = delegate { };
        public static event EventHandler LeftKeyPressed = delegate { };
        public static event EventHandler UpKeyPressed = delegate { };
        public static event EventHandler RightKeyPressed = delegate { };
        public static event EventHandler DownKeyPressed = delegate { };
        public static event EventHandler SelectKeyPressed = delegate { };
        public static event EventHandler PrintKeyPressed = delegate { };
        public static event EventHandler ExecuteKeyPressed = delegate { };
        public static event EventHandler PrintScreenKeyPressed = delegate { };
        public static event EventHandler InsertKeyPressed = delegate { };
        public static event EventHandler DeleteKeyPressed = delegate { };
        public static event EventHandler HelpKeyPressed = delegate { };
        public static event EventHandler D0KeyPressed = delegate { };
        public static event EventHandler D1KeyPressed = delegate { };
        public static event EventHandler D2KeyPressed = delegate { };
        public static event EventHandler D3KeyPressed = delegate { };
        public static event EventHandler D4KeyPressed = delegate { };
        public static event EventHandler D5KeyPressed = delegate { };
        public static event EventHandler D6KeyPressed = delegate { };
        public static event EventHandler D7KeyPressed = delegate { };
        public static event EventHandler D8KeyPressed = delegate { };
        public static event EventHandler D9KeyPressed = delegate { };
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
        public static event EventHandler LeftWindowsKeyPressed = delegate { };
        public static event EventHandler RightWindowsKeyPressed = delegate { };
        public static event EventHandler AppsKeyPressed = delegate { };
        public static event EventHandler SleepKeyPressed = delegate { };
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
        public static event EventHandler LeftShiftKeyPressed = delegate { };
        public static event EventHandler RightShiftKeyPressed = delegate { };
        public static event EventHandler LeftControlKeyPressed = delegate { };
        public static event EventHandler RightControlKeyPressed = delegate { };
        public static event EventHandler LeftAltKeyPressed = delegate { };
        public static event EventHandler RightAltKeyPressed = delegate { };
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
        public static event EventHandler OemSemicolonKeyPressed = delegate { };
        public static event EventHandler OemPlusKeyPressed = delegate { };
        public static event EventHandler OemCommaKeyPressed = delegate { };
        public static event EventHandler OemMinusKeyPressed = delegate { };
        public static event EventHandler OemPeriodKeyPressed = delegate { };
        public static event EventHandler OemQuestionKeyPressed = delegate { };
        public static event EventHandler OemTildeKeyPressed = delegate { };
        public static event EventHandler ChatPadGreenKeyPressed = delegate { };
        public static event EventHandler ChatPadOrangeKeyPressed = delegate { };
        public static event EventHandler OemOpenBracketsKeyPressed = delegate { };
        public static event EventHandler OemPipeKeyPressed = delegate { };
        public static event EventHandler OemCloseBracketsKeyPressed = delegate { };
        public static event EventHandler OemQuotesKeyPressed = delegate { };
        public static event EventHandler Oem8KeyPressed = delegate { };
        public static event EventHandler OemBackslashKeyPressed = delegate { };
        public static event EventHandler ProcessKeyKeyPressed = delegate { };
        public static event EventHandler OemCopyKeyPressed = delegate { };
        public static event EventHandler OemAutoKeyPressed = delegate { };
        public static event EventHandler OemEnlWKeyPressed = delegate { };
        public static event EventHandler AttnKeyPressed = delegate { };
        public static event EventHandler CrselKeyPressed = delegate { };
        public static event EventHandler ExselKeyPressed = delegate { };
        public static event EventHandler EraseEofKeyPressed = delegate { };
        public static event EventHandler PlayKeyPressed = delegate { };
        public static event EventHandler ZoomKeyPressed = delegate { };
        #endregion

        #region Key held events
        public static event EventHandler NoneKeyHeld = delegate { };
        public static event EventHandler BackKeyHeld = delegate { };
        public static event EventHandler TabKeyHeld = delegate { };
        public static event EventHandler EnterKeyHeld = delegate { };
        public static event EventHandler PauseKeyHeld = delegate { };
        public static event EventHandler CapsLockKeyHeld = delegate { };
        public static event EventHandler KanaKeyHeld = delegate { };
        public static event EventHandler KanjiKeyHeld = delegate { };
        public static event EventHandler EscapeKeyHeld = delegate { };
        public static event EventHandler ImeConvertKeyHeld = delegate { };
        public static event EventHandler ImeNoConvertKeyHeld = delegate { };
        public static event EventHandler SpaceKeyHeld = delegate { };
        public static event EventHandler PageUpKeyHeld = delegate { };
        public static event EventHandler PageDownKeyHeld = delegate { };
        public static event EventHandler EndKeyHeld = delegate { };
        public static event EventHandler HomeKeyHeld = delegate { };
        public static event EventHandler LeftKeyHeld = delegate { };
        public static event EventHandler UpKeyHeld = delegate { };
        public static event EventHandler RightKeyHeld = delegate { };
        public static event EventHandler DownKeyHeld = delegate { };
        public static event EventHandler SelectKeyHeld = delegate { };
        public static event EventHandler PrintKeyHeld = delegate { };
        public static event EventHandler ExecuteKeyHeld = delegate { };
        public static event EventHandler PrintScreenKeyHeld = delegate { };
        public static event EventHandler InsertKeyHeld = delegate { };
        public static event EventHandler DeleteKeyHeld = delegate { };
        public static event EventHandler HelpKeyHeld = delegate { };
        public static event EventHandler D0KeyHeld = delegate { };
        public static event EventHandler D1KeyHeld = delegate { };
        public static event EventHandler D2KeyHeld = delegate { };
        public static event EventHandler D3KeyHeld = delegate { };
        public static event EventHandler D4KeyHeld = delegate { };
        public static event EventHandler D5KeyHeld = delegate { };
        public static event EventHandler D6KeyHeld = delegate { };
        public static event EventHandler D7KeyHeld = delegate { };
        public static event EventHandler D8KeyHeld = delegate { };
        public static event EventHandler D9KeyHeld = delegate { };
        public static event EventHandler AKeyHeld = delegate { };
        public static event EventHandler BKeyHeld = delegate { };
        public static event EventHandler CKeyHeld = delegate { };
        public static event EventHandler DKeyHeld = delegate { };
        public static event EventHandler EKeyHeld = delegate { };
        public static event EventHandler FKeyHeld = delegate { };
        public static event EventHandler GKeyHeld = delegate { };
        public static event EventHandler HKeyHeld = delegate { };
        public static event EventHandler IKeyHeld = delegate { };
        public static event EventHandler JKeyHeld = delegate { };
        public static event EventHandler KKeyHeld = delegate { };
        public static event EventHandler LKeyHeld = delegate { };
        public static event EventHandler MKeyHeld = delegate { };
        public static event EventHandler NKeyHeld = delegate { };
        public static event EventHandler OKeyHeld = delegate { };
        public static event EventHandler PKeyHeld = delegate { };
        public static event EventHandler QKeyHeld = delegate { };
        public static event EventHandler RKeyHeld = delegate { };
        public static event EventHandler SKeyHeld = delegate { };
        public static event EventHandler TKeyHeld = delegate { };
        public static event EventHandler UKeyHeld = delegate { };
        public static event EventHandler VKeyHeld = delegate { };
        public static event EventHandler WKeyHeld = delegate { };
        public static event EventHandler XKeyHeld = delegate { };
        public static event EventHandler YKeyHeld = delegate { };
        public static event EventHandler ZKeyHeld = delegate { };
        public static event EventHandler LeftWindowsKeyHeld = delegate { };
        public static event EventHandler RightWindowsKeyHeld = delegate { };
        public static event EventHandler AppsKeyHeld = delegate { };
        public static event EventHandler SleepKeyHeld = delegate { };
        public static event EventHandler NumPad0KeyHeld = delegate { };
        public static event EventHandler NumPad1KeyHeld = delegate { };
        public static event EventHandler NumPad2KeyHeld = delegate { };
        public static event EventHandler NumPad3KeyHeld = delegate { };
        public static event EventHandler NumPad4KeyHeld = delegate { };
        public static event EventHandler NumPad5KeyHeld = delegate { };
        public static event EventHandler NumPad6KeyHeld = delegate { };
        public static event EventHandler NumPad7KeyHeld = delegate { };
        public static event EventHandler NumPad8KeyHeld = delegate { };
        public static event EventHandler NumPad9KeyHeld = delegate { };
        public static event EventHandler MultiplyKeyHeld = delegate { };
        public static event EventHandler AddKeyHeld = delegate { };
        public static event EventHandler SeparatorKeyHeld = delegate { };
        public static event EventHandler SubtractKeyHeld = delegate { };
        public static event EventHandler DecimalKeyHeld = delegate { };
        public static event EventHandler DivideKeyHeld = delegate { };
        public static event EventHandler F1KeyHeld = delegate { };
        public static event EventHandler F2KeyHeld = delegate { };
        public static event EventHandler F3KeyHeld = delegate { };
        public static event EventHandler F4KeyHeld = delegate { };
        public static event EventHandler F5KeyHeld = delegate { };
        public static event EventHandler F6KeyHeld = delegate { };
        public static event EventHandler F7KeyHeld = delegate { };
        public static event EventHandler F8KeyHeld = delegate { };
        public static event EventHandler F9KeyHeld = delegate { };
        public static event EventHandler F10KeyHeld = delegate { };
        public static event EventHandler F11KeyHeld = delegate { };
        public static event EventHandler F12KeyHeld = delegate { };
        public static event EventHandler F13KeyHeld = delegate { };
        public static event EventHandler F14KeyHeld = delegate { };
        public static event EventHandler F15KeyHeld = delegate { };
        public static event EventHandler F16KeyHeld = delegate { };
        public static event EventHandler F17KeyHeld = delegate { };
        public static event EventHandler F18KeyHeld = delegate { };
        public static event EventHandler F19KeyHeld = delegate { };
        public static event EventHandler F20KeyHeld = delegate { };
        public static event EventHandler F21KeyHeld = delegate { };
        public static event EventHandler F22KeyHeld = delegate { };
        public static event EventHandler F23KeyHeld = delegate { };
        public static event EventHandler F24KeyHeld = delegate { };
        public static event EventHandler NumLockKeyHeld = delegate { };
        public static event EventHandler ScrollKeyHeld = delegate { };
        public static event EventHandler LeftShiftKeyHeld = delegate { };
        public static event EventHandler RightShiftKeyHeld = delegate { };
        public static event EventHandler LeftControlKeyHeld = delegate { };
        public static event EventHandler RightControlKeyHeld = delegate { };
        public static event EventHandler LeftAltKeyHeld = delegate { };
        public static event EventHandler RightAltKeyHeld = delegate { };
        public static event EventHandler BrowserBackKeyHeld = delegate { };
        public static event EventHandler BrowserForwardKeyHeld = delegate { };
        public static event EventHandler BrowserRefreshKeyHeld = delegate { };
        public static event EventHandler BrowserStopKeyHeld = delegate { };
        public static event EventHandler BrowserSearchKeyHeld = delegate { };
        public static event EventHandler BrowserFavoritesKeyHeld = delegate { };
        public static event EventHandler BrowserHomeKeyHeld = delegate { };
        public static event EventHandler VolumeMuteKeyHeld = delegate { };
        public static event EventHandler VolumeDownKeyHeld = delegate { };
        public static event EventHandler VolumeUpKeyHeld = delegate { };
        public static event EventHandler MediaNextTrackKeyHeld = delegate { };
        public static event EventHandler MediaPreviousTrackKeyHeld = delegate { };
        public static event EventHandler MediaStopKeyHeld = delegate { };
        public static event EventHandler MediaPlayPauseKeyHeld = delegate { };
        public static event EventHandler LaunchMailKeyHeld = delegate { };
        public static event EventHandler SelectMediaKeyHeld = delegate { };
        public static event EventHandler LaunchApplication1KeyHeld = delegate { };
        public static event EventHandler LaunchApplication2KeyHeld = delegate { };
        public static event EventHandler OemSemicolonKeyHeld = delegate { };
        public static event EventHandler OemPlusKeyHeld = delegate { };
        public static event EventHandler OemCommaKeyHeld = delegate { };
        public static event EventHandler OemMinusKeyHeld = delegate { };
        public static event EventHandler OemPeriodKeyHeld = delegate { };
        public static event EventHandler OemQuestionKeyHeld = delegate { };
        public static event EventHandler OemTildeKeyHeld = delegate { };
        public static event EventHandler ChatPadGreenKeyHeld = delegate { };
        public static event EventHandler ChatPadOrangeKeyHeld = delegate { };
        public static event EventHandler OemOpenBracketsKeyHeld = delegate { };
        public static event EventHandler OemPipeKeyHeld = delegate { };
        public static event EventHandler OemCloseBracketsKeyHeld = delegate { };
        public static event EventHandler OemQuotesKeyHeld = delegate { };
        public static event EventHandler Oem8KeyHeld = delegate { };
        public static event EventHandler OemBackslashKeyHeld = delegate { };
        public static event EventHandler ProcessKeyKeyHeld = delegate { };
        public static event EventHandler OemCopyKeyHeld = delegate { };
        public static event EventHandler OemAutoKeyHeld = delegate { };
        public static event EventHandler OemEnlWKeyHeld = delegate { };
        public static event EventHandler AttnKeyHeld = delegate { };
        public static event EventHandler CrselKeyHeld = delegate { };
        public static event EventHandler ExselKeyHeld = delegate { };
        public static event EventHandler EraseEofKeyHeld = delegate { };
        public static event EventHandler PlayKeyHeld = delegate { };
        public static event EventHandler ZoomKeyHeld = delegate { };
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
                    KeyHeld(null, new KeyPressedEventArgs((Keys)keyId));
                    handleKeyHeld((Keys)keyId);
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
                case "Back":
                    BackKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Tab":
                    TabKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Enter":
                    EnterKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Pause":
                    PauseKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "CapsLock":
                    CapsLockKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Kana":
                    KanaKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Kanji":
                    KanjiKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Escape":
                    EscapeKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "ImeConvert":
                    ImeConvertKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "ImeNoConvert":
                    ImeNoConvertKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Space":
                    SpaceKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "PageUp":
                    PageUpKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "PageDown":
                    PageDownKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "End":
                    EndKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Home":
                    HomeKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Left":
                    LeftKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Up":
                    UpKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Right":
                    RightKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Down":
                    DownKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Select":
                    SelectKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Print":
                    PrintKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Execute":
                    ExecuteKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "PrintScreen":
                    PrintScreenKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Insert":
                    InsertKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Delete":
                    DeleteKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Help":
                    HelpKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "D0":
                    D0KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "D1":
                    D1KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "D2":
                    D2KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "D3":
                    D3KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "D4":
                    D4KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "D5":
                    D5KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "D6":
                    D6KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "D7":
                    D7KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "D8":
                    D8KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "D9":
                    D9KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
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
                case "LeftWindows":
                    LeftWindowsKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "RightWindows":
                    RightWindowsKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Apps":
                    AppsKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Sleep":
                    SleepKeyPressed(null, new KeyPressedEventArgs(keyPressed));
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
                case "LeftShift":
                    LeftShiftKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "RightShift":
                    RightShiftKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "LeftControl":
                    LeftControlKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "RightControl":
                    RightControlKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "LeftAlt":
                    LeftAltKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "RightAlt":
                    RightAltKeyPressed(null, new KeyPressedEventArgs(keyPressed));
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
                case "OemSemicolon":
                    OemSemicolonKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "OemPlus":
                    OemPlusKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "OemComma":
                    OemCommaKeyPressed(null, new KeyPressedEventArgs(keyPressed));
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
                case "OemTilde":
                    OemTildeKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "ChatPadGreen":
                    ChatPadGreenKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "ChatPadOrange":
                    ChatPadOrangeKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "OemOpenBrackets":
                    OemOpenBracketsKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "OemPipe":
                    OemPipeKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "OemCloseBrackets":
                    OemCloseBracketsKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "OemQuotes":
                    OemQuotesKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "Oem8":
                    Oem8KeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "OemBackslash":
                    OemBackslashKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "ProcessKey":
                    ProcessKeyKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "OemCopy":
                    OemCopyKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "OemAuto":
                    OemAutoKeyPressed(null, new KeyPressedEventArgs(keyPressed));
                    break;
                case "OemEnlW":
                    OemEnlWKeyPressed(null, new KeyPressedEventArgs(keyPressed));
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

        private static void handleKeyHeld(Keys keyHeld)
        {
            switch (keyHeld.ToString())
            {
                case "Back":
                    BackKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Tab":
                    TabKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Enter":
                    EnterKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Pause":
                    PauseKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "CapsLock":
                    CapsLockKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Kana":
                    KanaKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Kanji":
                    KanjiKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Escape":
                    EscapeKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "ImeConvert":
                    ImeConvertKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "ImeNoConvert":
                    ImeNoConvertKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Space":
                    SpaceKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "PageUp":
                    PageUpKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "PageDown":
                    PageDownKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "End":
                    EndKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Home":
                    HomeKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Left":
                    LeftKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Up":
                    UpKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Right":
                    RightKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Down":
                    DownKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Select":
                    SelectKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Print":
                    PrintKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Execute":
                    ExecuteKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "PrintScreen":
                    PrintScreenKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Insert":
                    InsertKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Delete":
                    DeleteKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Help":
                    HelpKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "D0":
                    D0KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "D1":
                    D1KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "D2":
                    D2KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "D3":
                    D3KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "D4":
                    D4KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "D5":
                    D5KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "D6":
                    D6KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "D7":
                    D7KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "D8":
                    D8KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "D9":
                    D9KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "A":
                    AKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "B":
                    BKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "C":
                    CKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "D":
                    DKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "E":
                    EKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F":
                    FKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "G":
                    GKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "H":
                    HKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "I":
                    IKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "J":
                    JKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "K":
                    KKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "L":
                    LKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "M":
                    MKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "N":
                    NKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "O":
                    OKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "P":
                    PKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Q":
                    QKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "R":
                    RKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "S":
                    SKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "T":
                    TKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "U":
                    UKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "V":
                    VKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "W":
                    WKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "X":
                    XKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Y":
                    YKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Z":
                    ZKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "LeftWindows":
                    LeftWindowsKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "RightWindows":
                    RightWindowsKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Apps":
                    AppsKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Sleep":
                    SleepKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "NumPad0":
                    NumPad0KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "NumPad1":
                    NumPad1KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "NumPad2":
                    NumPad2KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "NumPad3":
                    NumPad3KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "NumPad4":
                    NumPad4KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "NumPad5":
                    NumPad5KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "NumPad6":
                    NumPad6KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "NumPad7":
                    NumPad7KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "NumPad8":
                    NumPad8KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "NumPad9":
                    NumPad9KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Multiply":
                    MultiplyKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Add":
                    AddKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Separator":
                    SeparatorKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Subtract":
                    SubtractKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Decimal":
                    DecimalKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Divide":
                    DivideKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F1":
                    F1KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F2":
                    F2KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F3":
                    F3KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F4":
                    F4KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F5":
                    F5KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F6":
                    F6KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F7":
                    F7KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F8":
                    F8KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F9":
                    F9KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F10":
                    F10KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F11":
                    F11KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F12":
                    F12KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F13":
                    F13KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F14":
                    F14KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F15":
                    F15KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F16":
                    F16KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F17":
                    F17KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F18":
                    F18KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F19":
                    F19KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F20":
                    F20KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F21":
                    F21KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F22":
                    F22KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F23":
                    F23KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "F24":
                    F24KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "NumLock":
                    NumLockKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Scroll":
                    ScrollKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "LeftShift":
                    LeftShiftKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "RightShift":
                    RightShiftKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "LeftControl":
                    LeftControlKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "RightControl":
                    RightControlKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "LeftAlt":
                    LeftAltKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "RightAlt":
                    RightAltKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "BrowserBack":
                    BrowserBackKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "BrowserForward":
                    BrowserForwardKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "BrowserRefresh":
                    BrowserRefreshKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "BrowserStop":
                    BrowserStopKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "BrowserSearch":
                    BrowserSearchKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "BrowserFavorites":
                    BrowserFavoritesKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "BrowserHome":
                    BrowserHomeKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "VolumeMute":
                    VolumeMuteKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "VolumeDown":
                    VolumeDownKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "VolumeUp":
                    VolumeUpKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "MediaNextTrack":
                    MediaNextTrackKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "MediaPreviousTrack":
                    MediaPreviousTrackKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "MediaStop":
                    MediaStopKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "MediaPlayPause":
                    MediaPlayPauseKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "LaunchMail":
                    LaunchMailKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "SelectMedia":
                    SelectMediaKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "LaunchApplication1":
                    LaunchApplication1KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "LaunchApplication2":
                    LaunchApplication2KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemSemicolon":
                    OemSemicolonKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemPlus":
                    OemPlusKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemComma":
                    OemCommaKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemMinus":
                    OemMinusKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemPeriod":
                    OemPeriodKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemQuestion":
                    OemQuestionKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemTilde":
                    OemTildeKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "ChatPadGreen":
                    ChatPadGreenKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "ChatPadOrange":
                    ChatPadOrangeKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemOpenBrackets":
                    OemOpenBracketsKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemPipe":
                    OemPipeKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemCloseBrackets":
                    OemCloseBracketsKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemQuotes":
                    OemQuotesKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Oem8":
                    Oem8KeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemBackslash":
                    OemBackslashKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "ProcessKey":
                    ProcessKeyKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemCopy":
                    OemCopyKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemAuto":
                    OemAutoKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "OemEnlW":
                    OemEnlWKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Attn":
                    AttnKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Crsel":
                    CrselKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Exsel":
                    ExselKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "EraseEof":
                    EraseEofKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Play":
                    PlayKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
                case "Zoom":
                    ZoomKeyHeld(null, new KeyHeldEventArgs(keyHeld, keyDuration[(int)keyHeld]));
                    break;
            }
        }
    }
}
