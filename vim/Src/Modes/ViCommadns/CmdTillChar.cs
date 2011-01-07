/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-07
 * Godzina: 08:49
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdTillChar.
        /// </summary>
        public class CmdTillChar:IViCommand{
                public CmdTillChar(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalState.State = State.TillChar;
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
