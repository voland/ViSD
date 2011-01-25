/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2011-01-25
 * Time: 19:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
	/// <summary>
	/// Description of CmdSubChar.
	/// </summary>
	[Movement]
	public class CmdSubChar:CmdWithTools {
		public CmdSubChar() {
		}
		
		public override void Execute(object arg) {
			base.Execute(arg);
			Delete();
		}
	}
}
