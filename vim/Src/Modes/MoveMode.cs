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
	public class MoveMode:BasicMode	{
		public MoveMode(VimHandler vh):base(vh){
			AddCommand( new CmdCaretDown(), Key.J, ModifierKeys.None);
			AddCommand( new CmdCaretUp(), Key.K, ModifierKeys.None);
			AddCommand( new CmdCaretLeft(), Key.H, ModifierKeys.None);
			AddCommand( new CmdCaretRight(), Key.L, ModifierKeys.None);
			AddCommand( new CmdNextWord(), Key.W, ModifierKeys.None);
			AddCommand( new CmdNextWordBig(), Key.W, ModifierKeys.Shift);
			AddCommand( new CmdPrevWord(), Key.B, ModifierKeys.None);
			AddCommand( new CmdPrevWordBig(), Key.B, ModifierKeys.Shift);
			AddCommand( new CmdEndWord(), Key.E, ModifierKeys.None);
			AddCommand( new CmdEndWordBig(), Key.E, ModifierKeys.Shift);
			AddCommand( new CmdFindChar(), Key.F, ModifierKeys.None);
			AddCommand( new CmdFinCharBack(), Key.F, ModifierKeys.Shift);
			AddCommand( new CmdTillChar(), Key.T, ModifierKeys.None);
			AddCommand( new CmdTillCharBack(), Key.T, ModifierKeys.Shift);
			AddCommand( new CmdGoToMatchingBace(), Key.D5, ModifierKeys.Shift);
			AddCommand( new CmdRepeatFindTillChar(), Key.Oem1, ModifierKeys.None);
			AddCommand( new CmdFindWord(), Key.OemQuestion, ModifierKeys.None);
		}
	}
}
