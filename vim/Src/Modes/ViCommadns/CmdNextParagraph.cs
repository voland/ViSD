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
using ICSharpCode.AvalonEdit.Document;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdNextParagraph.
        /// </summary>
        public class CmdNextParagraph:IViCommand{
                private TextArea ta;
                public CmdNextParagraph(){
                }
                
                public void Execute(object arg){
                        ta = arg as TextArea;
                        if ( ta!=null ){
                                ViSDGlobalCount.LastUsedCommand = this;
                                ViSDGlobalCount.LastUsedArgument = arg;
                                int line = ta.Caret.Line;
                                int i;
                                if ( ta.Caret.Line< ta.Document.LineCount)
                                        i=ta.Caret.Line+1;
                                else
                                        i=1;
                                for ( ; i!=ta.Caret.Line; i++){
                                        if ( i>ta.Document.Lines.Count ) i=1;
                                        if ( IsEmpty(ta.Document.Lines[i-1])) {
                                                ta.Caret.Line = ta.Document.Lines[i-1].LineNumber;
                                                ta.Caret.BringCaretToView();
                                                return;
                                        }
                                }
                        }else{
                                ViSDGlobalCount.ResetAll();
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
                
                private bool IsEmpty( DocumentLine dl ){
                        for ( int i = dl.Offset; i<dl.EndOffset; i++){
                                char ch = ta.Document.GetCharAt(i);
                                if ((ch!=' ')&&(ch!='\t')) return false;
                        }
                        return true;
                }
        }
}
