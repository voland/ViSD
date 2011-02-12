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
	/// Description of CmdReplaceString.
	/// </summary>
	public class CmdReplaceString:IViCommand {
		public CmdReplaceString() {
		}
		
		public void Execute(object arg) {
			TextArea ta;
			if (( ta = arg as TextArea) != null){
				IViCommand rep = new CmdRepeatReplaceString( ta.Selection.Length );
				ViSDGlobalText.UpdateMove( rep, arg );
				ta.Selection.ReplaceSelectionWithText(ta, "");
				ViSDGlobalState.State = State.Insert;
			}
		}
		
		public bool CanExecute() {
			return true;
		}
	}
}
