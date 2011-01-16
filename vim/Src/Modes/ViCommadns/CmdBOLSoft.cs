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
        /// Description of CmdBOLSoft.
        /// </summary>
        public class CmdBOLSoft:IViCommand{
                public CmdBOLSoft(){
                }
                
                void IViCommand.Execute(object arg){
                        ViSDGlobalCount.ResetAll();
                        System.Windows.Documents.EditingCommands.MoveToLineStart.Execute(null, arg as TextArea);
                }
                
                bool IViCommand.CanExecute(){
                        return true;
                }
        }
}
