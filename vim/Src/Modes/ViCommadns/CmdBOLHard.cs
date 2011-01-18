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
        [Movement]
        /// <summary>
        /// Description of CmdBOLHard.
        /// </summary>
        public class CmdBOLHard:IViCommand{
                public CmdBOLHard(){
                }
                
                void IViCommand.Execute(object arg){
                        ViSDGlobalCount.ResetAll();
                        TextArea ta = arg as TextArea;
                        if ( ta!= null){
                                ta.Caret.Column=0;
                        }
                }
                
                bool IViCommand.CanExecute(){
                        return true;
                }
        }
}
