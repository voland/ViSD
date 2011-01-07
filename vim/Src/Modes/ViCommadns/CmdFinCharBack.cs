/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-07
 * Godzina: 00:54
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdFinCharBack.
        /// </summary>
        public class CmdFinCharBack:IViCommand
        {
                public CmdFinCharBack(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalState.State = State.FindCharBack;
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
