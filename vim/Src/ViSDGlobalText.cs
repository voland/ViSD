/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-17
 * Godzina: 19:51
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ViSD.Modes.ViCommadns;

namespace ViSD
{
        /// <summary>
        /// Description of ViSDGlobalText.
        /// </summary>
        public class ViSDGlobalText{
                
                public static IViCommand MoveCursor{
                        get {return _MoveCursor;}
                }
                private static IViCommand _MoveCursor;
                
                public static Object MoveCursorArg{
                        get {return _MoveCursorArg;}
                }
                private static Object _MoveCursorArg;
                
                public static string Text;
                
                public static void Reset(){
                        _MoveCursor = null;
                        _MoveCursorArg = null;
                }
                
                public static void UpdateMove( IViCommand c, Object a){
                        _MoveCursor = c;
                        _MoveCursorArg = a;
                }
        }
}
