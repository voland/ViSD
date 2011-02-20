/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-15
 * Godzina: 11:48
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Windows.Input;
using ViSD.Modes.ViCommadns;

namespace ViSD.Modes
{
	/// <summary>
	/// Description of ArgumentMode.
	/// </summary>
	public class ArgumentMode:BasicMode{
		public IViCommand ServeArgumentCmd;
		
		public char Argument{
			get{
				return _argument;
			}
		}
		
		private char _argument;
		
		public ArgumentMode(VimHandler vh):base(vh){
			base.Ataching += AtachingEventHandler;
			base.Detaching += DetachingEventHandler;
		}
		
		private void AtachingEventHandler( Object sender, EventArgs e){
			vh.TextArea.TextEntering +=TextEnteringEventHandler;
			ViCommadns.VisualCommands.CmdRepeatReplaceChar rc =
				ServeArgumentCmd as ViCommadns.VisualCommands.CmdRepeatReplaceChar;
			if  ( rc != null ){
				vh.TextArea.Selection = vh.TextArea.Selection.StartSelectionOrSetEndpoint(
					vh.TextArea.Caret.Offset,
					vh.TextArea.Caret.Offset + rc.lettersToDelete
				);
			}
		}
		
		private void DetachingEventHandler( Object sender, EventArgs e){
			vh.TextArea.TextEntering -=TextEnteringEventHandler;
		}
		
		private void TextEnteringEventHandler( Object sender, TextCompositionEventArgs e){
			vh.TextArea.Selection = ICSharpCode.AvalonEdit.Editing.Selection.Empty;
			if ( e.Text.Length >0){
				_argument = e.Text.ToCharArray()[0];
				ViSDGlobalText.Text = e.Text;
				if ( ServeArgumentCmd!=null){
					ServeArgumentCmd.Execute(this);
					ServeArgumentCmd=null;
				}
				e.Handled= true;
				ViSDGlobalCount.Process();
				ViSDGlobalState.State = State.Command;
			}
		}
	}
}
