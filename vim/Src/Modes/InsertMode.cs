/*
 * Created by SharpDevelop.
 * User: malwi
 * Date: 2011-01-06
 * Time: 15:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ViSD.Modes.ViCommadns;
using System.Windows.Input;

namespace ViSD.Modes
{
	/// <summary>
	/// Description of InsertMode.
	/// </summary>
	public class InsertMode:BasicMode{
		public InsertMode(VimHandler vh):base(vh){
			AddCommand( new CmdGoToCommandMode(), Key.Escape, ModifierKeys.None);
		}
	}
}
