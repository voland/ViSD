﻿/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-06
 * Godzina: 22:35
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdNextWordBig.
        /// </summary>
        public class CmdNextWordBig:CmdWithTools{
                public CmdNextWordBig():base(){
                }
                
                public override void Execute(object arg){
                        ViSDGlobalCount.LastUsedCommand = this;
                        ViSDGlobalCount.LastUsedArgument = arg;
                        base.Execute(arg);
                        do {
                                CurRightWord();
                        } while( !IsEmptyBeforeCur());

                }
        }
}
