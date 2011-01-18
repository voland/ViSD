/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-10
 * Godzina: 19:33
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdPrevIdent.
        /// </summary>
        [Movement]
        public class CmdPrevIdent:IViCommand{
                TextArea ta;
                CmdGoToPrevFindResult cmdf;
                public CmdPrevIdent(){
                        cmdf = new CmdGoToPrevFindResult();
                }
                
                public void Execute(object arg){
                        ta = arg as TextArea;
                        int begin, end, caret;
                        if ( ta!=null){
                                if (CanExecute()){
                                        ViSDGlobalCount.LastUsedCommand = cmdf;
                                        ViSDGlobalCount.LastUsedArgument = ta;
                                        
                                        caret = ta.Caret.Offset;
                                        while( IsLetter( caret-1 )) caret--;
                                        begin = caret;
                                        while( IsLetter(caret+1)) caret++;
                                        end = caret;
                                        int lenght =  end - begin + 1;
                                        ViSDGlobalWordSearch.SearchedWord=ta.Document.GetText( begin, lenght);
                                        if ( begin>0)
                                                ta.Caret.Offset = begin-1;
                                        else
                                                ta.Caret.Offset = ta.Document.TextLength-1;
                                        cmdf.Execute(ta);
                                }else{
                                        ViSDGlobalCount.ResetAll();
                                }
                        }
                }
                
                public bool CanExecute(){
                        if ( ta!=null){
                                int caret = ta.Caret.Offset;
                                return IsLetter( caret );
                        }
                        return false;
                }
                
                private bool IsLetter(int offset){
                        if ( offset<0) return false;
                        if ( offset>=ta.Document.TextLength) return false;
                        if ( ta!=null){
                                char ch = ta.Document.GetCharAt(offset);
                                return IsLetter(ch);
                        }
                        return false;
                }
                
                private bool IsLetter(char ch){
                        if ( ch=='_') return true;
                        if (((ch>='0')&&(ch<='9'))||((ch>='a')&&(ch<='z'))||((ch>='A')&&(ch<='Z')))
                                return true;
                        else
                                return false;
                }
        }
}
