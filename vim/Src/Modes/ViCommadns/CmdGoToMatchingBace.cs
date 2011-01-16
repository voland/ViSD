/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-07
 * Godzina: 09:03
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.SharpDevelop.Editor.Commands;

//TODO: Caret should be on the left of char
namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdGoToMatchingBace.
        /// </summary>
        public class CmdGoToMatchingBace:IViCommand{
                private GoToMatchingBrace mb;
                public CmdGoToMatchingBace(){
                        mb = new GoToMatchingBrace();
                }
                
                public void Execute(object arg){
                        ViSDGlobalCount.ResetAll();
                        mb.Run();
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
