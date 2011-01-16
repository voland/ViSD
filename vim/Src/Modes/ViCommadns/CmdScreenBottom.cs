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
        /// Description of CmdScreenBottom.
        /// </summary>
        public class CmdScreenBottom:IViCommand{
                private TextArea ta;
                
                public CmdScreenBottom(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalCount.ResetAll();
                        ta = arg as TextArea;
                        if ( ta!=null ){
                                double TopLine = ta.TextView.ScrollOffset.Y;
                                foreach( VisualLine vl in ta.TextView.VisualLines){
                                        if (((vl.VisualTop +2*vl.Height)>=(TopLine+ta.TextView.ActualHeight))||
                                            ((vl.VisualTop +1*vl.Height)>=(ta.TextView.DocumentHeight))) {
                                                ta.Caret.Line = vl.LastDocumentLine.LineNumber;
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