/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-15
 * Godzina: 12:28
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.SharpDevelop.Bookmarks;

namespace ViSD.Modes.ViCommadns.ArgumentCommands
{
        /// <summary>
        /// Description of CmdToogleBookmark.
        /// </summary>
        public class CmdToogleBookmark:IViCommand{
                
                public CmdToogleBookmark(){
                }
                
                public void Execute(object arg){
                        ArgumentMode am = arg as ArgumentMode;
                        if ( am != null ) {
                                int line = am.vh.TextArea.Caret.Line;
                                String filename = am.vh.FileName;
                                char bookmark = am.Argument;
                                Bookmarks.ViSDGlobalBookmarks.Bookmarks.Add( bookmark, filename, line);
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
