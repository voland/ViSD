/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2/8/2011
 * Time: 9:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ViSD.Modes.ViCommadns {
	/// <summary>
	/// Description of CmdServeEsc.
	/// </summary>
	public class CmdServeEsc:IViCommand{
		public CmdServeEsc() {
		}
		
		public void Execute(object arg) {
			ViSDGlobalCount.ResetAll();
		}
		
		public bool CanExecute() {
			return true;
		}
	}
} 