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
                public static IViCommand MoveCursor;
                public static Object MoveCursorArg;
                public static string Text;
                
                public static void Reset(){
                        MoveCursor = null;
                        MoveCursorArg = null;
                }
        }
}
