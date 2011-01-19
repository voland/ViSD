/*
 * Created by SharpDevelop.
 * User: malwi
 * Date: 2011-01-06
 * Time: 15:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ViSD.Modes.ViCommadns;
using System.Windows.Input;

namespace ViSD.Modes
{
        /// <summary>
        /// Description of InsertMode.
        /// </summary>
        public class InsertMode:BasicMode{
                private int CurOnBegin;
                private int LenOnBegin;
                
                public InsertMode(VimHandler vh):base(vh){
                        AddCommand( new CmdGoToCommandMode(), Key.Escape, ModifierKeys.None);
                        base.Ataching += AtachingEventHandler;
                        base.Detaching += DetachingEventHandler;
                }
                
                private void AtachingEventHandler( Object sender, EventArgs e){
                        CurOnBegin = vh.TextArea.Caret.Offset;
                }
                
                private void DetachingEventHandler( Object sender, EventArgs e){
                        if ( vh.TextArea.IsFocused ){
                                LenOnBegin = vh.TextArea.Caret.Offset - CurOnBegin;
                                if (LenOnBegin>0){
                                        ViSDGlobalText.Text = vh.TextArea.Document.GetText(
                                                CurOnBegin, LenOnBegin);
                                        ViSDGlobalCount.UpdLastUsed(
                                                new CmdServeViSDGlobalText(),
                                                vh.TextArea );
                                        ViSDGlobalCount.Process();
                                }
                        }
                }
        }
}
