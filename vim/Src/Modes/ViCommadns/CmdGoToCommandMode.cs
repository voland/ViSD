/*
 * Created by SharpDevelop.
 * User: malwi
 * Date: 2011-01-06
 * Time: 15:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
	/// <summary>
	/// Description of GoToCommandMode.
	/// </summary>
	public class CmdGoToCommandMode:IViCommand{
		public CmdGoToCommandMode(){
		}
		
		public void Execute(object arg){
	                ViSDGlobalCount.ResetAll();
			ViSDGlobalState.State = State.Command;
		}
		
		public bool CanExecute(){
			return true;
		}
	}
}
