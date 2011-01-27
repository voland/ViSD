/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2011-01-25
 * Time: 21:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
	/// <summary>
	/// Description of CmdReplaceMode.
	/// </summary>
	public class CmdReplaceMode:IViCommand {
		public CmdReplaceMode() {
		}
		
		public void Execute(object arg) {
			ViSDGlobalState.State = State.Replace;
		}
		
		public bool CanExecute() {
			return true;
		}
	}
}
