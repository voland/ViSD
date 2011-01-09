/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-08
 * Godzina: 17:39
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Collections.Generic;

namespace ViSD
{
        /// <summary>
        /// Description of ViSDGlobalWordSearch.
        /// </summary>
        public static class ViSDGlobalWordSearch{
                public static String SearchedWord{
                        set{
                                _searchword = value;
                                if ( _history.Count == 0 )
                                        _history.Add( value );
                                else
                                        if ( _history[_history.Count-1] != value)
                                                _history.Add( value );
                        }
                        get{
                                return _searchword;
                        }
                }
                public static List<String> History{
                        get{
                                return _history;
                        }
                }
                private static String _searchword;
                private static List<String> _history = new List<string>();
                
        }
}
