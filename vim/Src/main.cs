// Gpl code created by Arkadiusz Gil (Voland)
//TODO: Custom caret 
//TODO: history
//TODO: find replace
//TODO: Komendy D i C na koncu lini nie dzialaja poprawnie
//TODO: Join Lies doesn work properly if empty line below
//TODO: macro

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
                                        case State.Replace:
                                                        ta.ActiveInputHandler = new Replace( ta );
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
