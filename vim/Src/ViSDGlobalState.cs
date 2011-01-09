/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-08
 * Godzina: 17:29
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.IO;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.SharpDevelop;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.AvalonEdit.Editing;

//do comend
using System.Windows.Documents;
using System.Windows.Input;
using ViSD.Modes;

namespace ViSD{
        /// <summary>
        /// Description of ViSDGlobalState.
        /// </summary>
	public static class ViSDGlobalState{
		public static State State{
			get {
				return _state;
			}
			set {
                                _prevstate = _state;
				_state = value;
				String message;
				message = String.Format("-- {0} --", value.ToString());
				StatusBar(message);
				if ( StateChanged!=null)
					StateChanged( null, value);
			}
		}
                
                public static State PrevState{
                        get {
                                return _prevstate;
                        }
                }
                private static State _prevstate;
		
		private static void StatusBar(String message){
			WorkbenchSingleton.Workbench.StatusBar.SetMessage(message, false, null);
		}
		
		private static State _state;
		public delegate void DelegateStateChanged(Object sender, State s);
		public static event DelegateStateChanged StateChanged;
	}
}
