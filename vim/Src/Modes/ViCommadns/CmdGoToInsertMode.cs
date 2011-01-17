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
	/// Description of CmdGoToInsertMode.
	/// </summary>
	public class CmdGoToInsertMode:IViCommand{
		public CmdGoToInsertMode(){
		}
		
		public void Execute(object arg){
	                ViSDGlobalCount.ResetCommand();
	                ViSDGlobalText.Text="";
	                ViSDGlobalText.Reset();
			ViSDGlobalState.State= State.Insert;
		}
		
		public bool CanExecute(){
			return true;
		}
	}
}
