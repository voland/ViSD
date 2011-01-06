/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-05
 * Godzina: 10:08
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns {
        /// <summary>
        /// Description of CmdCaretDown.
        /// </summary>
        public class CmdCaretRight:IViCommand {
                public CmdCaretRight() {
                }
                
                void IViCommand.Execute(object arg) {
                        TextArea ta = arg as TextArea;
                        if ( ta!=null ){
                                System.Windows.Documents.EditingCommands.MoveRightByCharacter.Execute(null, ta);
                        }
                        
                }
                
                bool IViCommand.CanExecute() {
                        return true;
                }
        }
}
