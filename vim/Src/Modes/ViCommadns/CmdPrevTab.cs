/*
 * Created by SharpDevelop.
 * User: malwi
 * Date: 2011-01-06
 * Time: 14:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ICSharpCode.SharpDevelop.Commands;

namespace ViSD.Modes.ViCommadns{
	/// <summary>
	/// Description of CmdPrevTab.
	/// </summary>
	public class CmdPrevTab:IViCommand{
		private SelectPrevWindow spw;
		public CmdPrevTab(){
			spw = new SelectPrevWindow();
		}
		
		void IViCommand.Execute(object arg)	{
			spw.Run();
		}
		
		bool IViCommand.CanExecute(){
			return true;
		}
	}
}
