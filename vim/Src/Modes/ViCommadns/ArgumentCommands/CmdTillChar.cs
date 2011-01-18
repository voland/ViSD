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
        /// Description of CmdTillChar.
        /// </summary>
        [Movement]
        public class CmdTillChar:IViCommand{
                public CmdTillChar(){
                }
                
                public void Execute(object arg){
                        ArgumentMode am = arg as ArgumentMode;
                        if ( am!=null){
                                TextArea ta  = am.vh.TextArea;
                                if ( ta !=null){
                                        ViSDGlobalCount.LastUsedCommand = this;
                                        ViSDGlobalCount.LastUsedArgument = arg;
                                        ViSDGlobalCharSearch.LastSeatchedArgument = am;
                                        ViSDGlobalCharSearch.LastSearchedMethod = this;
                                        int caret = ta.Caret.Offset;
                                        caret++;
                                        String key = String.Format("{0}", am.Argument);
                                        char ch = ta.Document.GetCharAt(caret);
                                        while ( String.Format("{0}", ch) != key ){
                                                caret++;
                                                ch = ta.Document.GetCharAt(caret);
                                                if ((ch=='\x0d')||(ch=='\x0a')) {
                                                        return;
                                                }
                                        }
                                        caret--;
                                        ta.Caret.Offset = caret;
                                }
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
