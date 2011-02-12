/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2/12/2011
 * Time: 11:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns.VisualCommands
{
	/// <summary>
	/// Description of CmdCut.
	/// </summary>
	public class CmdCut:IViCommand {
		public CmdCut() {
		}
		
		public void Execute(object arg) {
			TextArea ta;
			if (( ta = arg as TextArea )!=null ){
				ViSDGlobalClipBoard.CopySelected( ta );
				ta.Selection.ReplaceSelectionWithText( ta, "" ); //remove selection
				ViSDGlobalState.State = State.Command;
				ViSDGlobalCount.ResetAll();
			}
		}
		
		public bool CanExecute() {
			return true;
		}
	}
}
