/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2/12/2011
 * Time: 1:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns.VisualCommands
{
	/// <summary>
	/// Description of CmdPasteCopy.
	/// </summary>
	public class CmdPasteCopy:IViCommand {
		public CmdPasteCopy() {
		}
		
		public void Execute(object arg) {
			TextArea ta;
			if (( ta = arg as TextArea )!=null ){
				ViSDGlobalClipBoard.PasteCopy( ta );
				ViSDGlobalState.State = State.Command;
				ViSDGlobalCount.ResetAll();
			}
		}
		
		public bool CanExecute() {
			return true;
		}
	}
}
