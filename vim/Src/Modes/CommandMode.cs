/*
 * Created by SharpDevelop.
 * User: malwi
 * Date: 2011-01-06
 * Time: 14:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ViSD.Modes.ViCommadns;
using System.Windows.Input;

namespace ViSD.Modes
{
	/// <summary>
	/// Description of CommandMode.
	/// </summary>
	public class CommandMode:BasicMode	{
		public CommandMode(VimHandler vh):base(vh){
			AddCommand( new CmdGoToInsertMode(), Key.I, ModifierKeys.None);
			AddCommand( new CmdCaretDown(), Key.J, ModifierKeys.None);
			AddCommand( new CmdCaretUp(), Key.K, ModifierKeys.None);
			AddCommand( new CmdCaretLeft(), Key.H, ModifierKeys.None);
			AddCommand( new CmdCaretRight(), Key.L, ModifierKeys.None);
		}
	}
}
