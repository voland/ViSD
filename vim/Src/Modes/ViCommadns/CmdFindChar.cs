/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-07
 * Godzina: 00:40
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdFindChar.
        /// </summary>
        public class CmdFindChar:IViCommand{
                public CmdFindChar(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalState.State = State.FindChar;
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
