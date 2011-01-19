
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
        /// Description of CmdPrevParagraph.
        /// </summary>
        [Movement]
        public class CmdPrevParagraph:IViCommand{
                private TextArea ta;
                public CmdPrevParagraph(){
                }
                
                public void Execute(object arg){
                        ta = arg as TextArea;
                        if ( ta!=null ){
                                ViSDGlobalCount.UpdLastUsed( this, arg );
                                int line = ta.Caret.Line;
                                int i;
                                if ( ta.Caret.Line>1)
                                        i=ta.Caret.Line-1;
                                else
                                        i=ta.Document.Lines.Count;
                                for ( ; i!=ta.Caret.Line; i--){
                                        if ( i==0 ) i=ta.Document.Lines.Count;
                                        if ( IsEmpty(ta.Document.Lines[i-1])) {
                                                ta.Caret.Line = ta.Document.Lines[i-1].LineNumber;
                                                ta.Caret.BringCaretToView();
                                                return;
                                        }
                                }
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
