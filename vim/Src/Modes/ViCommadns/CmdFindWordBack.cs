/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-08
 * Godzina: 22:55
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdFindWordBack.
        /// </summary>
        public class CmdFindWordBack:IViCommand{
                public CmdFindWordBack(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalState.State = State.FindWordBack;
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
