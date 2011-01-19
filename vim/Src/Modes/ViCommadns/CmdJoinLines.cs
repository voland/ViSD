/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-19
 * Godzina: 20:07
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns{
        /// <summary>
        /// Description of CmdJoinLines.
        /// </summary>
        public class CmdJoinLines:CmdWithTools{
                public CmdJoinLines(){
                }
                
                public override void Execute(object arg){
                        base.Execute(arg);
                        if ( CanExecute() ){
                                ViSDGlobalCount.UpdLastUsed( this, arg );
                                CurEOL();
                                int cur = TextArea.Caret.Offset;
                                while ( IsEmptyUnder(cur-1) ) cur--;
                                int len = 0;
                                while (IsEmptyUnder(cur + len)) len++;
                                TextArea.Document.Remove( cur, len );
                                TextArea.Caret.Offset = cur;
                                TextArea.PerformTextInput(" ");
                        }
                }
                
                public override bool CanExecute(){
                        if ( TextArea!=null) return true;
                        else return false;
                }
        }
}
