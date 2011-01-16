/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-07
 * Godzina: 15:20
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.SharpDevelop.Editor.Search;
using System.Collections.Generic;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdFindWord.
        /// </summary>
        public class CmdFindWord:IViCommand{
                public CmdFindWord(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalCount.ResetCommand();
                        ViSDGlobalState.State = State.FindWord;
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
