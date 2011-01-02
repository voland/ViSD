/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2010-12-25
 * Godzina: 19:01
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 * TODO: zrobic tak aby vim mode mogbyc wlaczony ma pasku zadan i aby wybor ten byl zapamietany
 * TODO: dodac plik do eksperymentow i wymyslic cos by preladowanie plugina bylo szybsze
 * TODO: zrobic prostokatna ikone przy command mode
 * TODO: zaiplementowac command BAR
 * TODO: zaimplementowac reszte komend
 */

using System;
using System.Text;
using System.Windows.Input;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.AddIn;

namespace Vim{

        public class ToolCommand1 : AbstractMenuCommand	{
                AvalonEditViewContent tecp;
                
                public ToolCommand1(){
                        //System.Windows.Forms.MessageBox.Show("Constructor!!!");
                }
                
                public override void Run(){
                        
                        // Here an example that shows how to access the current text document:
                        tecp = WorkbenchSingleton.Workbench.ActiveContent as AvalonEditViewContent;
                        //add vim functionality to every opened document
                        WorkbenchSingleton.Workbench.ViewOpened += delegate(object sender, ViewContentEventArgs e) {
                                AvalonEditViewContent aevc = e.Content as AvalonEditViewContent;
                                if ( aevc !=null)
                                        new VimHandler( aevc.CodeEditor.ActiveTextEditor.TextArea );
                        };
                        
//                        if (tecp == null) {
//                                // active content is not a text editor control
//                                System.Windows.Forms.MessageBox.Show("shit this is not a text editor at all! Bitch!");
//                                return;
//                        }else{
//                                new VimHandler( tecp.CodeEditor.ActiveTextEditor.TextArea );
//                        }
                }
                
                

        }
}

