/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-19
 * Godzina: 19:53
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdDelete.
        /// </summary>
        public class CmdDelete:IViCommand{
                private TextArea ta;
                public CmdDelete(){
                }
                
                public void Execute(object arg){
                        ta = arg as TextArea;
                        if ( CanExecute() ){
                                ViSDGlobalCount.UpdLastUsed( this, arg );
                                System.Windows.Documents.EditingCommands.Delete.Execute(
                                        null, ta);
                        }
                }
                
                public bool CanExecute(){
                        if ( ta!=null )
                                if ( ta.Caret.Offset< ta.Document.TextLength )
                                        return true;
                        return false;
                }
        }
}
