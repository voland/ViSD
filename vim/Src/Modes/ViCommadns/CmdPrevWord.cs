/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-06
 * Godzina: 22:43
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdPrevWord.
        /// </summary>
        public class CmdPrevWord:IViCommand{
                public CmdPrevWord(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalCount.LastUsedCommand = this;
                        ViSDGlobalCount.LastUsedArgument = arg;
                        System.Windows.Documents.EditingCommands.MoveLeftByWord.Execute(null, arg as TextArea);
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
