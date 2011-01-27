/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-08
 * Godzina: 17:35
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD{
        /// <summary>
        /// Enum Type describing State of Vi Editor
        /// </summary>
	public enum State {
		Command,
		Insert,
		FindWord,
		FindWordBack,
		ArgumentMode,
		Replace
	}
}
