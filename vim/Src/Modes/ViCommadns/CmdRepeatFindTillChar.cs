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
        public class CmdRepeatFindTillChar:IViCommand{
                public CmdRepeatFindTillChar(){
                }
                
                public void Execute(object arg){
                        if ( CanExecute()){
                                ViSDGlobalCharSearch.LastSearchMode.ServeKey( ViSDGlobalCharSearch.LastSearchedKey,
                                                                             ViSDGlobalCharSearch.LastSearchedModifier);
                        }
                }
                
                public bool CanExecute(){
                        if ( ViSDGlobalCharSearch.LastSearchMode !=null) return true;
                        return false;
                }
        }
}
