/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-07
 * Godzina: 08:49
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdGetArgTillChar.
        /// </summary>
        public class CmdGetArgTillChar:IViCommand{
                public CmdGetArgTillChar(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalCount.ResetCommand();
                        TextArea ta = arg as TextArea;
                        if ( ta!=null){
                                VimHandler vh = ta.ActiveInputHandler as VimHandler;
                                if ( vh!= null){
                                        vh.ArgumentMode.ServeArgumentCmd = new ArgumentCommands.CmdTillChar();
                                        ViSDGlobalState.State= State.ArgumentMode;
                                }
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
