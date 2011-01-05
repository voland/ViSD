/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-05
 * Godzina: 09:18
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of IViCommand.
        /// </summary>
        public interface IViCommand {
                void Execute( Object arg );
                bool CanExecute();
        }
}
