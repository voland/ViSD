/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2010-12-25
 * Godzina: 19:01
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 * TODO: zrobic tak aby vim mode mogbyc wlaczony ma pasku zadan i aby wybor ten byl zapamietany
 * TODO: zrobic prostokatna ikone przy command mode
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

        public enum State {
                Unknown = 0,
                Normal,
                Command,
                CmdLine,
                Delete,
                Yank,
                Visual,
                VisualLine,
                Insert,
                Replace,
                WriteChar,
                Change,
                Indent,
                Unindent,
                G,
                Fold,
                Mark,
                GoToMark,
                NameMacro,
                PlayMacro
        }
        
        public static class VimGlobal{
                public static State state;
        }
        
        
        public class ToolCommand1 : AbstractMenuCommand	{
                //AvalonEditViewContent tecp;
                
                public ToolCommand1(){
//                      :  assert("VimPlugin");
                }
                
                public override void Run(){
                        
                        //add vim functionality to every opened document
                        WorkbenchSingleton.WorkbenchCreated+= delegate(object sender, EventArgs e) {
                                WorkbenchSingleton.Workbench.ViewOpened += delegate(object sender2, ViewContentEventArgs e2) {
                                        AvalonEditViewContent aevc = e2.Content as AvalonEditViewContent;
                                        if ( aevc !=null)
                                                new VimHandler( aevc.CodeEditor.ActiveTextEditor.TextArea );
                                };
                        };
                }
                void assert( String s ){
                        System.Windows.Forms.MessageBox.Show(s);
                }
        }
}

