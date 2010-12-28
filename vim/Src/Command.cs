/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2010-12-25
 * Godzina: 19:01
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Text;
using System.Windows.Input;
//using System.Windows.Forms;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.AddIn;
//using ICSharpCode.SharpDevelop.DefaultEditor.Gui.Editor;
//using ICSharpCode.TextEditor;

namespace Vim{

        public enum State {
                Unknown = 0,
                Normal,
                Command,
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
        
        public class ToolCommand1 : AbstractMenuCommand	{
                AvalonEditViewContent tecp;
                State state;
                
                KeyConverter KeyConv;
                ICSharpCode.AvalonEdit.TextEditor te;
                
                
                public override void Run(){
                        
                        // Here an example that shows how to access the current text document:
                        tecp = WorkbenchSingleton.Workbench.ActiveContent as AvalonEditViewContent;
                        
                        if (tecp == null) {
                                // active content is not a text editor control
                                System.Windows.Forms.MessageBox.Show("shit this is not a text editor");
                                return;
                        }else{
                                tecp.TextEditor.KeyPress+=editorKeyPressed;
                                state = State.Command;
                                KeyConv = new KeyConverter();
                                te = ICSharpCode.SharpDevelop.Editor.AvalonEdit.AvalonEditTextEditorAdapter.CreateAvalonEditInstance();
                                assert(te.Text);
                        }
                }
                
                public void editorKeyPressed( Object o, KeyEventArgs e){
                        if ( tecp !=null){
                                string key = KeyDecoder(e);
                                bool Handled = true;
                                
                                
                                switch ( state ){
                                        case State.Insert:
                                                switch ( e.Key){
                                                        case Key.Escape:
                                                                state= State.Command;
                                                                Handled=true;
                                                                break;
                                                        default:
                                                                Handled=false;
                                                                break;
                                                }
                                                break;
                                        case State.Command:
                                                switch (key){
                                                        case "A":
                                                                CurEOL();
                                                                goto case "i";
                                                        case "a":
                                                                CurRight();
                                                                goto case "i";
                                                        case "i":
                                                                
                                                                state = State.Insert;
                                                                break;
                                                        case "return":
                                                        case "down":
                                                        case "j":
                                                                CurDown();
                                                                break;
                                                        case "up":
                                                        case "k":
                                                                CurUP();
                                                                break;
                                                        case "left":
                                                        case "h":
                                                                CurLeft();
                                                                break;
                                                        case "right":
                                                        case "l":
                                                                CurRight();
                                                                break;
                                                        case "o":
                                                                CurEOL();
                                                                tecp.CodeEditor.ActiveTextEditor.TextArea.PerformTextInput("\x0d");
                                                                goto case "i";
                                                        case "O":
                                                                CurUP();
                                                                CurEOL();
                                                                tecp.CodeEditor.ActiveTextEditor.TextArea.PerformTextInput("\x0d");
                                                                goto case "i";
                                                        default:
                                                                if ( key.Length>0) assert(key);
                                                                break;
                                                }
                                                break;
                                        case State.Visual:
                                                Handled = true;
                                                break;
                                }
                                e.Handled = Handled;
                        }
                }
                private void CurEOL(){
                        IDocumentLine dl = tecp.TextEditor.Document.GetLine( tecp.Line );
                        tecp.JumpTo(tecp.Line, dl.Length+1);
                }
                private void CurLeft(){
                        l=tecp.Line;
                        c=tecp.Column;
                        c--;
                        cbuf=c;
                        tecp.JumpTo(l,c);
                }
                
                private void CurRight(){
                        l=tecp.Line;
                        c=tecp.Column;
                        c++;
                        cbuf=c;
                        tecp.JumpTo(l,c);
                }
                
                private void CurUP(){
                        l=tecp.Line;
                        l--;
                        if ( cbuf<0)
                                c=tecp.Column;
                        else
                                c=cbuf;
                        tecp.JumpTo(l,c);
                }
                
                private void CurDown(){
                        l=tecp.Line;
                        l++;
                        if ( cbuf<0)
                                c=tecp.Column;
                        else
                                c=cbuf;
                        tecp.JumpTo(l,c);
                }
                
                private String KeyDecoder( KeyEventArgs e ){
                        bool CapLet = ( e.KeyboardDevice.Modifiers == ModifierKeys.Shift );     //stands for capital letter
                        string letter = KeyConv.ConvertToString(e.Key);
                        if ( !CapLet ){
                                return letter.ToLower();
                        }
                        return letter;
                }
                
                private void assert(String message){
                        System.Windows.Forms.MessageBox.Show(message);
                }
                
                //pomocne wspolzedne
                private int l, c;
                private int cbuf=-1;
        }
}

