/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-07
 * Godzina: 00:00
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes{
        /// <summary>
        /// Description of FinCharMode.
        /// </summary>
        public class TillCharMode:BasicMode, IMode{
                public TillCharMode(VimHandler vh):base(vh){
                }
                bool IMode.ServeKey(System.Windows.Input.Key k, System.Windows.Input.ModifierKeys mk){
                        if  ( mk!= System.Windows.Input.ModifierKeys.None) return true;
                        int caret = vh.TextArea.Caret.Offset;
                        caret++;
                        String key = DecodeKey(k, mk);
                        char ch = vh.TextArea.Document.GetCharAt(caret);
                        while ( String.Format("{0}", ch) != key ){
                                caret++;
                                ch = vh.TextArea.Document.GetCharAt(caret);
                                if ((ch=='\x0d')||(ch=='\x0a')) {
                                        ViSDGlobalState.State = ViSDGlobalState.PrevState;
                                        return true;
                                }
                        }
                        caret--;
                        vh.TextArea.Caret.Offset = caret;
                        ViSDGlobalCharSearch.LastSearchMode=this;
                        ViSDGlobalCharSearch.LastSearchedKey=k;
                        ViSDGlobalCharSearch.LastSearchedModifier=mk;
                        ViSDGlobalState.State = ViSDGlobalState.PrevState;
                        return true;
                }
        }
}
