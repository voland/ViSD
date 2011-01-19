/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-19
 * Godzina: 21:37
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdOpenBelow.
        /// </summary>
        [Movement]
        public class CmdOpenBelow:CmdWithTools{
                IViCommand moveeol;
                
                public CmdOpenBelow(){
                        moveeol = new CmdEOL();
                }
                
                public override void Execute( Object arg ){
                        base.Execute(arg);
                        moveeol.Execute( arg );
                        TextArea.PerformTextInput("\n");
                }
        }
}
