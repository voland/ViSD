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
        /// Description of CmdGetArgGoToBookmark.
        /// </summary>
        //TODO: add difrent reaction for "'" and "`"
        public class CmdGetArgGoToBookmark:IViCommand{
                public CmdGetArgGoToBookmark(){
                }
                
                public void Execute(object arg){
                        TextArea ta = arg as TextArea;
                        if ( ta!=null){
                                VimHandler vh = ta.ActiveInputHandler as VimHandler;
                                if ( vh!= null){
                                        vh.ArgumentMode.ServeArgumentCmd = new CmdGoToBookmark();
                                        ViSDGlobalState.State= State.ArgumentMode;
                                }
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
