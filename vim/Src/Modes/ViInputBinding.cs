/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-05
 * Godzina: 09:36
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ViSD.Modes.ViCommadns;
using System.Windows.Input;

namespace ViSD.Modes
{
        /// <summary>
        /// Description of ViInputBinding.
        /// </summary>
        public class ViInputBinding {
                private Key key;
                private ModifierKeys modkey;
                private IViCommand command;
                public ViInputBinding(IViCommand vc, Key k, ModifierKeys mk) {
                        key = k;
                        command = vc;
                        modkey = mk;
                }
                public bool ExeIfKey( Object o, Key k, ModifierKeys mk){
                        if ( k == key ) if ( mk == modkey ) {
                                command.Execute(o);
                                return true;
                        }
                        return false;
                }
        }
}
