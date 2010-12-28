/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2010-12-28
 * Godzina: 14:53
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace Vim{
        /// <summary>
        /// This is Vim handler which should be added to TextArea.ActiveInputHandler
        /// </summary>
        public class VimHandler:ITextAreaInputHandler{
                
                public TextArea TextArea {
                        set {
                                txtarea=value;
                        }
                        get {
                                return txtarea;
                        }
                }
                
                public void Attach(){
                        txtarea.KeyDown+=KeyDown;
                }
                
                public void Detach(){
                        txtarea.KeyDown-=KeyDown;
                }
                
                private void KeyDown(object sender, KeyEventArgs e) {
                        assert("zalozmy ze dziala");
                }
                
                private void assert(String message){
                        System.Windows.Forms.MessageBox.Show(message);
                }
                
                //fields
                TextArea txtarea;
        }
}
