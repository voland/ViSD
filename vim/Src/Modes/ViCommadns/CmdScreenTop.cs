/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-11
 * Godzina: 18:37
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Rendering;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdScreenTop.
        /// </summary>
        [Movement]
        public class CmdScreenTop:IViCommand{
                private TextArea ta;
                
                public CmdScreenTop(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalCount.ResetAll();
                        ta = arg as TextArea;
                        if ( ta!=null ){
                                double TopLine = ta.TextView.ScrollOffset.Y;
                                foreach( VisualLine vl in ta.TextView.VisualLines){
                                        if ( vl.VisualTop>=TopLine) {
                                                ta.Caret.Line = vl.FirstDocumentLine.LineNumber;
                                                return;
                                        }
                                }
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}