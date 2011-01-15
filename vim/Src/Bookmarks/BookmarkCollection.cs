/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-13
 * Godzina: 20:31
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Collections.Generic;
using System.Collections;

namespace ViSD.Bookmarks
{
        /// <summary>
        /// Description of BookmarkCollection.
        /// </summary>
        [Serializable]
        public class BookmarkCollection:IEnumerable{
                private ArrayList _list;
                
                public BookmarkCollection(){
                        _list = new ArrayList();
                }
                
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
                        return _list.GetEnumerator();
                }
                
                public void Add(char Bookmark, String FileName, int Line){
                        foreach( ViSDBookmark b in _list){
                                if ( b.Bookmark==Bookmark){
                                        if ( b.FileName == FileName){
                                                _list.Remove(b);
                                                break;
                                        }
                                }
                        }
                        _list.Add( new ViSDBookmark( Bookmark, FileName, Line));
                }
        }
}
