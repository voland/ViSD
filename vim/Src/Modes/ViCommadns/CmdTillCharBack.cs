/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-07
 * Godzina: 08:50
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdTillCharBack.
        /// </summary>
        public class CmdTillCharBack:IViCommand{
                public CmdTillCharBack(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalState.State = State.TillCharBack;
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
