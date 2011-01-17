/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-17
 * Godzina: 20:14
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
        //FIXME: repeating insert doesnt work properly when autocomplete is done
        /// <summary>
        /// Description of CmdServeViSDGlobalText.
        /// </summary>
        public class CmdServeViSDGlobalText:IViCommand{
                public CmdServeViSDGlobalText(){
                }
                
                public void Execute(object arg){
                        if ( ViSDGlobalText.MoveCursor!=null){
                                if ( ViSDGlobalText.MoveCursorArg!=null){
                                        ViSDGlobalText.MoveCursor.Execute( ViSDGlobalText.MoveCursorArg);
                                }
                        }
                        
                        TextArea ta = arg as TextArea;
                        if ( ta!=null){
                                if ( ViSDGlobalText.Text.Length > 0 ){
                                        ta.PerformTextInput(ViSDGlobalText.Text);
                                }
                        }else{
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}
