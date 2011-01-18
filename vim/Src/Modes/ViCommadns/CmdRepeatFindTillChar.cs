/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-07
 * Godzina: 09:32
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdRepeatFindTillChar.
        /// </summary>
        [Movement]
        public class CmdRepeatFindTillChar:IViCommand{
                public CmdRepeatFindTillChar(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalCount.LastUsedCommand = this;
                        ViSDGlobalCount.LastUsedArgument = arg;
                        if ( CanExecute()){
                                ViSDGlobalCharSearch.LastSearchedMethod.Execute( ViSDGlobalCharSearch.LastSeatchedArgument );
                        }
                }
                
                public bool CanExecute(){
                        if ((ViSDGlobalCharSearch.LastSearchedMethod!=null)&&(ViSDGlobalCharSearch.LastSeatchedArgument!=null))
                                return true;
                        return false;
                }
        }
}
