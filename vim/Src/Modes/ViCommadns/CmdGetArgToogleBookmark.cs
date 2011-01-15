/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-15
 * Godzina: 12:22
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;
using ViSD.Modes.ViCommadns.ArgumentCommands;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdGetArgToogleBookmark.
        /// </summary>
        public class CmdGetArgToogleBookmark:IViCommand{
                public CmdGetArgToogleBookmark(){
                }
                
                public void Execute(object arg){
                        TextArea ta = arg as TextArea;
                        if ( ta!=null){
                                VimHandler vh = ta.ActiveInputHandler as VimHandler;
                                if ( vh!= null){
                                        vh.ArgumentMode.ServeArgumentCmd = new CmdToogleBookmark();
                                        ViSDGlobalState.State= State.ArgumentMode;
                                }
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
