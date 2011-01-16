/*
 * Created by SharpDevelop.
 * User: malwi
 * Date: 2011-01-06
 * Time: 13:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ICSharpCode.SharpDevelop.Commands;


namespace ViSD.Modes.ViCommadns
{
	/// <summary>
	/// Description of CmdNextTab.
	/// </summary>
	public class CmdNextTab:IViCommand{
		private SelectNextWindow snw;
		public CmdNextTab(){
			snw = new SelectNextWindow();
		}
		
		void IViCommand.Execute(object arg){
		        ViSDGlobalCount.ResetCommand();
			snw.Run();
		}
		
		bool IViCommand.CanExecute(){
			return true;
		}
	}
}
