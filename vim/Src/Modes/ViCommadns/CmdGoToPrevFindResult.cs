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
        /// Description of CmdGoToPrevFindResult.
        /// </summary>
        [Movement]
        public class CmdGoToPrevFindResult:IViCommand{
                private int startoffset;
                private TextArea ta;
                private String word="";
                private StringComparison sc;
                
                public CmdGoToPrevFindResult(){
                }
                
                //TODO: when caret moves besides visible layout of editor scroolbar must follow caret
                public void Execute(object arg){
                        ViSDGlobalCount.LastUsedArgument = arg;
                        ViSDGlobalCount.LastUsedCommand = this;
                        ta = arg as TextArea;
                        if ( ta != null){
                                word = ViSDGlobalWordSearch.SearchedWord;
                                sc= GetStringComparisonType(word);
                                if ( word.Length>0){
                                        startoffset = ta.Caret.Offset;
                                        int result = GetPrev();
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
                private int GetPrev(){
                        if ( ta.Document.TextLength>=word.Length){
                                int offset = startoffset-1;
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
                                        offset--;
                                        if ( offset<0 ) offset=ta.Document.TextLength-1;
                                }while( offset!=(startoffset-1));
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