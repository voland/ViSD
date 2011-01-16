/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-16
 * Godzina: 23:40
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdRepeatLastAction.
        /// </summary>
        public class CmdRepeatLastAction:IViCommand{
                public CmdRepeatLastAction(){
                }
                
                public void Execute(object arg){
                        if ( CanExecute() ){
                                ViSDGlobalCount.LastUsedCommand.Execute( ViSDGlobalCount.LastUsedArgument );
                        }
                }
                
                public bool CanExecute(){
                        if ((ViSDGlobalCount.LastUsedCommand!=null)&&(ViSDGlobalCount.LastUsedArgument!=null))
                                return true;
                        else
                                return false;
                }
        }
}
