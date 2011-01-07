/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-06
 * Godzina: 23:26
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.SharpDevelop.Commands;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdFullScreen.
        /// </summary>
        public class CmdFullScreen:IViCommand{
                ToggleFullscreenCommand tfsc;
                
                public CmdFullScreen(){
                        tfsc = new ToggleFullscreenCommand();
                }
                
                public void Execute(object arg){
                        tfsc.Run();
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
