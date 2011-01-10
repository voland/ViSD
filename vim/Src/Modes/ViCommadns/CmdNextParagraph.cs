/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-10
 * Godzina: 21:15
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdNextParagraph.
        /// </summary>
        public class CmdNextParagraph:IViCommand{
                public CmdNextParagraph(){
                }
                
                public void Execute(object arg){
                        TextArea ta = arg as TextArea;
                        if ( ta!=null ){
                                System.Windows.Documents.EditingCommands.MoveDownByParagraph.Execute(null, ta);
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
