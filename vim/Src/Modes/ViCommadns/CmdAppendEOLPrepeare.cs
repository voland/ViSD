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
        /// Description of CmdAppendEOLPrepeare.
        /// </summary>
        [Movement]
        public class CmdAppendEOLPrepeare:IViCommand{
                public CmdAppendEOLPrepeare(){
                }
                
                void IViCommand.Execute(object arg){
                        System.Windows.Documents.EditingCommands.MoveToLineEnd.Execute(null, arg as TextArea);
                }
                
                bool IViCommand.CanExecute(){
                        return true;
                }
        }
}
