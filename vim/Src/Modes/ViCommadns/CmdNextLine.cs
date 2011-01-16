/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-10
 * Godzina: 20:54
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdNextLine.
        /// </summary>
        public class CmdNextLine:IViCommand{
                private IViCommand Down;
                private IViCommand BolHard;
                private IViCommand Bol;
                public CmdNextLine(){
                        Down = new CmdCaretDown();
                        BolHard = new CmdBOLHard();
                        Bol = new CmdBOLSoft();
                }
                
                public void Execute(object arg){
                        int temp = ViSDGlobalCount.Number;
                        Down.Execute(arg);
                        BolHard.Execute(arg);
                        Bol.Execute(arg);
                        ViSDGlobalCount.Number = temp;
                        ViSDGlobalCount.LastUsedCommand = this;
                        ViSDGlobalCount.LastUsedArgument = arg;
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
