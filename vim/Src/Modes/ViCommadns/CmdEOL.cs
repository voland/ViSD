/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-06
 * Godzina: 22:32
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdEOL.
        /// </summary>
        [Movement]
        public class CmdEOL:IViCommand{
                public CmdEOL(){
                }
                
                void IViCommand.Execute(object arg){
                        ViSDGlobalCount.ResetAll();
                        System.Windows.Documents.EditingCommands.MoveToLineEnd.Execute(null, arg as TextArea);
                }
                
                bool IViCommand.CanExecute(){
                        return true;
                }
        }
}
