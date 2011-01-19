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
        /// Description of CmdEndWordBig.
        /// </summary>
        [Movement]
        public class CmdEndWordBig:CmdWithTools{
                public CmdEndWordBig():base(){
                }
                
                public override void Execute(object arg){
                        ViSDGlobalCount.UpdLastUsed( this, arg );
                        base.Execute(arg);
                        while ( IsEmptyUnderCur() ) CurRightWord();
                        do {
                                CurRightWord();
                        } while( !IsEmptyBeforeCur());
                        while( IsEmptyBeforeCur()) {
                                CurLeft();
                        }
                        CurLeft();
                }
        }
}
