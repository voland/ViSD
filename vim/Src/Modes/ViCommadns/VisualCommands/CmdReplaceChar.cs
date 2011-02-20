/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2/12/2011
 * Time: 2:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns.VisualCommands
{
	/// <summary>
	/// Description of CmdReplaceChar.
	/// </summary>
	public class CmdReplaceChar:IViCommand {
		public CmdReplaceChar() {
		}
		
		public void Execute(object arg) {
			TextArea ta;
			if ( (ta= arg as TextArea)!=null){
				VimHandler vh = ta.ActiveInputHandler as VimHandler;
				if ( vh!= null){
					Selection sel = ta.Selection;
					vh.ArgumentMode.ServeArgumentCmd = new CmdRepeatReplaceChar( sel.Length);
					ViSDGlobalState.State= State.ArgumentMode;
				}
			}
		}
		
		public bool CanExecute() {
			return true;
		}
	}
}
