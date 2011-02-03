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

namespace ViSD.Modes.ViCommadns {
        //FIXME: this command should always start where the text starts
        [Movement]
        /// <summary>
        /// Description of CmdInsertBOLPrepeare.
        /// </summary>
        public class CmdInsertBOLPrepeare:IViCommand{
                public CmdInsertBOLPrepeare(){
                }
                
                void IViCommand.Execute(object arg){
                        if ( arg is TextArea ){
                        	(arg as TextArea).Caret.Column=0;
                        }
                        System.Windows.Documents.EditingCommands.MoveToLineStart.Execute(null, arg as TextArea);
                }
                
                bool IViCommand.CanExecute(){
                        return true;
                }
        }
}
