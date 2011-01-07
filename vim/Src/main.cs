// Gpl code created by Arkadiusz Gil (Voland)
//TODO: Custom caret class
//TODO: Class motion
//TODO: Class counter
//TODO: Class history
//TODO: class keylogger for repeat actions
//TODO: class find replace
//TODO: class macro
//TODO: class find char
//TODO: clas command line

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

namespace ViSD {
	
	public enum State {
		Command,
		Insert,
		FindChar,
		FindCharBack,
		TillChar,
		TillCharBack
	}
        
        public static class ViSDGlobalCharSearch{
                public static IMode LastSearchMode;
                public static Key LastSearchedKey;
                public static ModifierKeys LastSearchedModifier;
        }
	
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
	

	// SharpDevelop creates one instance of EmbeddedImageLanguageBinding for each text editor.
	public class Visd : DefaultLanguageBinding {
		TextArea ta;
		
		public override void Attach(ITextEditor editor) {
			base.Attach(editor);
			ta = editor.GetService(typeof(TextArea)) as TextArea;
			if ( ta !=null){
				new VimHandler( ta );
			}
		}
		
		public override void Detach() {
			base.Detach();
		}
		
		private void assert( String s){
			System.Windows.Forms.MessageBox.Show( s);
		}
		
	}
}
