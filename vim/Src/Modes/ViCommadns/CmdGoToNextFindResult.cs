/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-08
 * Godzina: 17:49
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.SharpDevelop.Gui;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdGoToNextFindResult.
        /// </summary>
        [Movement]
        public class CmdGoToNextFindResult:IViCommand{
                private int startoffset;
                private TextArea ta;
                private String word="";
                private StringComparison sc;

                public CmdGoToNextFindResult(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalCount.UpdLastUsed( this, arg );
                        
                        ta = arg as TextArea;
                        if ( ta != null){
                                word = ViSDGlobalWordSearch.SearchedWord;
                                sc= GetStringComparisonType(word);
                                if ( word.Length>0){
                                        startoffset = ta.Caret.Offset;
                                        int result = GetNext();
                                        if ( result>=0 ) {
                                                Message( "Found: " + word );
                                                ta.Caret.Offset = result;
                                                ta.Caret.BringCaretToView();
                                        }else{
                                                Message( "NotFound: " + word);
                                        }
                                }
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
                
                /// <summary>
                /// Get offset of next ocurence
                /// </summary>
                /// <returns>returns -1 if no next ocurence</returns>
                private int GetNext(){
                        if ( ta.Document.TextLength >= word.Length){
                                int offset = startoffset+1;
                                do{
                                        if ( offset<=(ta.Document.TextLength-word.Length))
                                                if (offset >=0)
                                                        switch ( sc){
                                                case StringComparison.InvariantCulture:
                                                        if ( word==ta.Document.GetText(offset, word.Length)) return offset;
                                                        break;
                                                case StringComparison.InvariantCultureIgnoreCase:
                                                        if ( word.ToUpper() == ta.Document.GetText(offset, word.Length).ToUpper()) return offset;
                                                        break;
                                        }
                                        offset++;
                                        if ( offset>= (ta.Document.TextLength+1-word.Length)) offset=0;
                                }while( offset!=(startoffset+1));
                        }
                        return -1;
                }
                private void Message( String s){
                        WorkbenchSingleton.StatusBar.SetMessage(s);
                }
                
                StringComparison GetStringComparisonType(string find){
                        foreach (char c in find) {
                                if (Char.IsUpper(c)) {
                                        return StringComparison.InvariantCulture;
                                }
                        }
                        return StringComparison.InvariantCultureIgnoreCase;
                }

        }
}
