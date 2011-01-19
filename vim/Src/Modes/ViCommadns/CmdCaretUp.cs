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
        [Movement]
        public class CmdCaretUp:IViCommand {
                public CmdCaretUp() {
                }
                
                void IViCommand.Execute(object arg) {
                        ViSDGlobalCount.UpdLastUsed( this, arg );
                        TextArea ta = arg as TextArea;
                        if ( ta!=null ){
                                System.Windows.Documents.EditingCommands.MoveUpByLine.Execute(null, ta);
                        }
                        
                }
                
                bool IViCommand.CanExecute() {
                        return true;
                }
        }
}
