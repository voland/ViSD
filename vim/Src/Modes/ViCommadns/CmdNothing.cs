/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-06
 * Godzina: 22:24
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdNothing.
        /// </summary>
        public class CmdNothing:IViCommand{
                public CmdNothing(){
                }
                
                void IViCommand.Execute(object arg){
                }
                
                bool IViCommand.CanExecute(){
                        return true;
                }
        }
}
