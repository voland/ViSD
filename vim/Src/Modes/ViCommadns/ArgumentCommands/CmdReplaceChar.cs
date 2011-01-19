/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-16
 * Godzina: 21:38
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;
using System.Windows.Input;

namespace ViSD.Modes.ViCommadns.ArgumentCommands
{
        /// <summary>
        /// Description of CmdReplaceChar.
        /// </summary>
        public class CmdReplaceChar:IViCommand{
                public CmdReplaceChar(){
                }
                
                public void Execute(object arg){
                        ArgumentMode am = arg as ArgumentMode;
                        if ( am!=null){
                                TextArea ta  = am.vh.TextArea;
                                if ( ta !=null){
                                        ViSDGlobalCount.UpdLastUsed( this, arg );
                                        String key = String.Format("{0}", am.Argument);
                                        am.vh.TextArea.Document.Replace(am.vh.TextArea.Caret.Offset,
                                                                        1,
                                                                        key);
                                }
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
