/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-06
 * Godzina: 22:52
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns{
        /// <summary>
        /// Description of CmdWithTools.
        /// </summary>
        public class CmdWithTools:IViCommand{
                protected TextArea TextArea;
                
                public CmdWithTools(){
                }
                
                public virtual void Execute(object arg){
                        TextArea = arg as TextArea;
                }
                
                public virtual bool CanExecute(){
                        return true;
                }
                
                protected bool IsEmptyUnderCur(){
                        int caret = TextArea.Caret.Offset;
                        if  (( caret >= TextArea.Document.TextLength )||(caret<0)) return false;
                        char ch = TextArea.Document.GetCharAt(caret);
                        if (( ch == ' ' )||(ch=='\t')||(ch=='\x0d')||(ch=='\x0a')) return true;
                        return false;
                }
                
                protected bool IsEmptyUnder( int offset ){
                        int caret = offset;
                        if  (( caret >= TextArea.Document.TextLength )||(caret<0)) return false;
                        char ch = TextArea.Document.GetCharAt(caret);
                        if (( ch == ' ' )||(ch=='\t')||(ch=='\x0d')||(ch=='\x0a')) return true;
                        return false;
                }

                protected bool IsEmptyBeforeCur(){
                        int caret = TextArea.Caret.Offset;
                        caret--;
                        char ch='a'; //losowo 'a' ale to nie ma znaczenia w tym momencie
                        if (caret>=0){
                                ch = TextArea.Document.GetCharAt(caret);
                        } else {
                                return true;
                        }
                        if (( ch == ' ' )||(ch=='\t')||(ch=='\x0d')||(ch=='\x0a')) return true;
                        return false;
                }
                
                protected void CurLeft(){
                        System.Windows.Documents.EditingCommands.MoveLeftByCharacter.Execute(null, TextArea);
                }

                protected void CurRight(){
                        System.Windows.Documents.EditingCommands.MoveRightByCharacter.Execute(null, TextArea);
                }
                
                protected void CurRightWord(){
                        System.Windows.Documents.EditingCommands.MoveRightByWord.Execute(null, TextArea);
                }
                
                protected void CurLeftWord(){
                        System.Windows.Documents.EditingCommands.MoveLeftByWord.Execute(null, TextArea);
                }
                
                protected void CurEOL(){
                        System.Windows.Documents.EditingCommands.MoveToLineEnd.Execute(null, TextArea);
                }
                
                protected void DelEOL(){
                	System.Windows.Documents.EditingCommands.SelectToLineEnd.Execute(null, TextArea);
                	Delete();
                }
                protected void Delete(){
                        System.Windows.Documents.EditingCommands.Delete.Execute(null, TextArea);
                }
                protected void Backspace(){
                        System.Windows.Documents.EditingCommands.Backspace.Execute(null, TextArea);
                }


        }
}
