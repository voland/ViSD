// Gpl code created by Arkadiusz Gil (Voland)
//TODO: Custom caret class
//TODO: Class motion
//TODO: Class counter
//TODO: Class history
//TODO: class keylogger for repeat actions
//TODO: class find replace
//TODO: class macro
//TODO: class find char
//TODO: clas command line

using System;
using System.IO;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.SharpDevelop;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit;

//do comend
using System.Windows.Documents;
using System.Windows.Input;
using ViSD.Modes;

namespace ViSD {
        
        // SharpDevelop creates one instance of Visd for each text editor.
        public class Visd : DefaultLanguageBinding {
                TextArea ta;
                VimHandler vh;
                TextEditor te;
                
                public Visd(){
                        ViSDGlobalState.StateChanged+= delegate(object sender, State s) {
                                switch ( s){
                                        case State.FindWord:
                                                if ( ta.IsFocused )
                                                        ta.ActiveInputHandler = new IncrementalSearch( ta, LogicalDirection.Forward);
                                                break;
                                        case State.FindWordBack:
                                                if ( ta.IsFocused )
                                                        ta.ActiveInputHandler = new IncrementalSearch( ta, LogicalDirection.Backward);
                                                break;
                                        default:
                                                ta.ActiveInputHandler = vh;
                                                break;
                                }
                        };
                }
                
                public override void Attach(ITextEditor editor) {
                        base.Attach(editor);
                        te = editor.GetService(typeof(TextEditor)) as TextEditor;
                        if ( te !=null){
                                ta = te.TextArea;
                                vh = new VimHandler(ta, editor.FileName);
                                ta.ActiveInputHandler = vh;
                        }
                }
                
                public override void Detach() {
                        base.Detach();
                }
        }
}
