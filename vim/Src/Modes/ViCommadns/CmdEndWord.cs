/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-06
 * Godzina: 22:36
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdEndWord.
        /// </summary>
        public class CmdEndWord:CmdWithTools{
                public CmdEndWord(){
                }
                
                public override void Execute(object arg){
                        base.Execute(arg);
                        while ( IsEmptyUnderCur() ) CurRightWord();
                        CurRightWord();
                        while( IsEmptyBeforeCur()){
                                CurLeft();
                        }
                        CurLeft();
                }
        }
}
