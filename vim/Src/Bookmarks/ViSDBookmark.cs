/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-13
 * Godzina: 20:19
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Bookmarks{
        /// <summary>
        /// Description of ViSDBookmark.
        /// </summary>
        [Serializable]
        public class ViSDBookmark{
                public String FileName{
                        get{
                                return _filename;
                        }
                }
                
                public char Bookmark{
                        get{
                                return _bookmark;
                        }
                }
                
                public int Line{
                        get {
                                return _line;
                        }
                }
                
                private char _bookmark;
                private String _filename;
                private int _line;
                
                public ViSDBookmark(char Bookmark, String FileName, int Line){
                        _bookmark=Bookmark;
                        _filename = FileName;
                        _line=Line;
                }
        }
}
