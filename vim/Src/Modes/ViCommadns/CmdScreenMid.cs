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
        /// Description of CmdScreenMid.
        /// </summary>
        [Movement]
        public class CmdScreenMid:IViCommand{
                private TextArea ta;
                
                public CmdScreenMid(){
                }
                
                public void Execute(object arg){
                        ViSDGlobalCount.ResetAll();
                        ta = arg as TextArea;
                        int begin=-1;
                        int end=-1;
                        if ( ta!=null ){
                                double TopLine = ta.TextView.ScrollOffset.Y;
                                foreach( VisualLine vl in ta.TextView.VisualLines){
                                        if ( begin == -1 ){
                                                if ( vl.VisualTop>=TopLine) {
                                                        begin = vl.FirstDocumentLine.LineNumber;
                                                }
                                        } else{
                                                if (((vl.VisualTop +2*vl.Height)>=(TopLine+ta.TextView.ActualHeight))||
                                                    ((vl.VisualTop +1*vl.Height)>=(ta.TextView.DocumentHeight))) {
                                                        end = vl.LastDocumentLine.LineNumber;
                                                        break;
                                                }
                                        }
                                }
                                if ( (begin >=0)&&( end >=0)){
                                        ta.Caret.Line = begin + (end - begin)/2;
                                        return;
                                }
                        }
                }
                
                public bool CanExecute(){
                        return true;
                }
        }
}