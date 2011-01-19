/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-16
 * Godzina: 23:53
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdGoToLine.
        /// </summary>
        [Movement]
        public class CmdGoToLine:IViCommand{
                public CmdGoToLine(){
                }
                
                public void Execute(object arg){
                        TextArea ta = arg as TextArea;
                        if ( ta!=null ){
                                if ( ViSDGlobalCount._number == 0 ){
                                        ta.Caret.Line = ta.Document.Lines.Count;
                                        ta.Caret.BringCaretToView();
                                }else{
                                        if ( ViSDGlobalCount._number<= ta.Document.LineCount ){
                                                ta.Caret.Line = ViSDGlobalCount._number;
                                                ta.Caret.BringCaretToView();
                                        }
                                }
                                ViSDGlobalCount.ResetAll();
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}