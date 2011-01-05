/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-05
 * Godzina: 09:08
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Windows.Input;

namespace ViSD.Modes {
        /// <summary>
        /// Description of Interface1.
        /// </summary>
        public interface IMode {
                bool ServeKey( Key k, ModifierKeys mk );
                void Atached();
                void Detached();
        }
}
