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
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.AvalonEdit.Editing;

//do comend
using System.Windows.Documents;
using System.Windows.Input;

namespace ViSD {
        
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
        

        // SharpDevelop creates one instance of EmbeddedImageLanguageBinding for each text editor.
        public class Visd : DefaultLanguageBinding {
                TextArea ta;
                
                public override void Attach(ITextEditor editor) {
                        base.Attach(editor);
                        ta = editor.GetService(typeof(TextArea)) as TextArea;
                        if ( ta !=null){
                                new VimHandler( ta );
                        }
                }
                
                public override void Detach() {
                        base.Detach();
                }
                
                private void assert( String s){
                        System.Windows.Forms.MessageBox.Show( s);
                }
                
        }
}
