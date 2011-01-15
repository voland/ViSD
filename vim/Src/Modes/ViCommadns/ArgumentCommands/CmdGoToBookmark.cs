/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-15
 * Godzina: 15:53
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns.ArgumentCommands
{
        /// <summary>
        /// Description of CmdGoToBookmark.
        /// </summary>
        public class CmdGoToBookmark:IViCommand{
                public CmdGoToBookmark(){
                }
                
                public void Execute(object arg){
                        ArgumentMode am = arg as ArgumentMode;
                        if ( am != null ) {
                                int line = am.vh.TextArea.Caret.Line;
                                String filename = am.vh.FileName;
                                char bookmark = am.Argument;
                                foreach ( Bookmarks.ViSDBookmark b in Bookmarks.ViSDGlobalBookmarks.Bookmarks){
                                        if ( b.Bookmark == bookmark){
                                                if ( b.FileName == filename ){
                                                        if ( b.Line<=am.vh.TextArea.Document.Lines.Count){
                                                                am.vh.TextArea.Caret.Line = b.Line;
                                                                am.vh.TextArea.Caret.BringCaretToView();
                                                        }
                                                }
                                        }
                                }
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
