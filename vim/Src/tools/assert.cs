/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-17
 * Godzina: 20:34
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD
{
        /// <summary>
        /// Description of assert.
        /// </summary>
        public class assert
        {
                public assert()
                {
                }
                public static void Assert(String s){
                        System.Windows.Forms.MessageBox.Show(s);
                }
        }
}
