/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-06
 * Godzina: 22:32
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdNextWord.
        /// </summary>
        public class CmdNextWord:IViCommand{
                public CmdNextWord(){
                }
                
                void IViCommand.Execute(object arg){
                        ViSDGlobalCount.LastUsedCommand = this;
                        ViSDGlobalCount.LastUsedArgument = arg;
                        System.Windows.Documents.EditingCommands.MoveRightByWord.Execute(null, arg as TextArea);
                }
                
                bool IViCommand.CanExecute(){
                        return true;
                }
        }
}
