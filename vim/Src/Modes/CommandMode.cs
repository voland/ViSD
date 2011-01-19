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
        public class CommandMode:MoveMode{
                public CommandMode(VimHandler vh):base(vh){
                        AddCommand( new CmdGoToInsertMode(), Key.I, ModifierKeys.None);
                        AddCommand( new CmdRepeatLastAction(), Key.OemPeriod, ModifierKeys.None);
                        AddCommand( new CmdGetArgReplaceChar(), Key.R, ModifierKeys.None);
                        AddCommand( new CmdDelete(), Key.X, ModifierKeys.None);
                        AddCommand( new CmdBackspace(), Key.X, ModifierKeys.Shift);
                        AddCommand( new CmdJoinLines(), Key.J, ModifierKeys.Shift);
                        AddCommand( new CmdAppend(), Key.A, ModifierKeys.None);
                        AddCommand( new CmdAppendEOL(), Key.A, ModifierKeys.Shift);
                        AddCommand( new CmdInsertBOL(), Key.I, ModifierKeys.Shift);
                        RestKeys = new CmdNothing();
                }
        }
}
