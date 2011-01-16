/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-06
 * Godzina: 22:43
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns{
        /// <summary>
        /// Description of CmdPrevWordBig.
        /// </summary>
        public class CmdPrevWordBig:CmdWithTools{
                public CmdPrevWordBig():base(){
                }
                
                public override void Execute(object arg){
                        ViSDGlobalCount.LastUsedCommand = this;
                        ViSDGlobalCount.LastUsedArgument = arg;
                        base.Execute(arg);
                        do {
                                CurLeftWord();
                        } while( !IsEmptyBeforeCur());
                }
        }
}
