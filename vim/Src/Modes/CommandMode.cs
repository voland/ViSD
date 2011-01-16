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
                        RestKeys = new CmdNothing();
                }
        }
}
