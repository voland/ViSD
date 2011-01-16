/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-08
 * Godzina: 17:32
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.IO;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.SharpDevelop;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.AvalonEdit.Editing;

//do comend
using System.Windows.Documents;
using System.Windows.Input;
using ViSD.Modes;
using ViSD.Modes.ViCommadns.ArgumentCommands;
using ViSD.Modes.ViCommadns;

namespace ViSD
{
        /// <summary>
        /// Description of ViSDGlobalCharSearch.
        /// </summary>
        public static class ViSDGlobalCharSearch{
                public static IViCommand LastSearchedMethod;
                public static Object LastSeatchedArgument;
        }
	
}
