/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2/12/2011
 * Time: 9:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns.VisualCommands
{
	/// <summary>
	/// Description of CmdYank.
	/// </summary>
	public class CmdYank:IViCommand {
		public CmdYank() {
		}
		
		public void Execute(object arg) {
			TextArea ta;
			if (( ta = arg as TextArea )!=null ){
				ViSDGlobalClipBoard.CopySelected( ta );
				ViSDGlobalState.State = State.Command;
				ViSDGlobalCount.ResetAll();
			}
		}
		
		public bool CanExecute() {
			return true;
		}
	}
}
