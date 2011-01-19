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
        /// Description of CmdBackspace.
        /// </summary>
        public class CmdBackspace:IViCommand{
                private TextArea ta;
                public CmdBackspace(){
                }
                
                public void Execute(object arg){
                        ta = arg as TextArea;
                        if ( CanExecute() ){
                                ViSDGlobalCount.UpdLastUsed( this, arg );
                                System.Windows.Documents.EditingCommands.Backspace.Execute(
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
