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
                public InsertMode(VimHandler vh):base(vh){
                        AddCommand( new CmdGoToCommandMode(), Key.Escape, ModifierKeys.None);
                        base.Ataching += AtachingEventHandler;
                        base.Detaching += DetachingEventHandler;
                }
                
                private void AtachingEventHandler( Object sender, EventArgs e){
                        vh.TextArea.TextEntered +=TextEnteringEventHandler;
                }
                
                private void DetachingEventHandler( Object sender, EventArgs e){
                        vh.TextArea.TextEntered -=TextEnteringEventHandler;
                        if ( vh.TextArea.IsFocused ){
                                ViSDGlobalCount.LastUsedCommand = new CmdServeViSDGlobalText();
                                ViSDGlobalCount.LastUsedArgument = vh.TextArea;
                                ViSDGlobalCount.Process();
                        }
                }
                
                private void TextEnteringEventHandler( Object sender, TextCompositionEventArgs e){
                        if ( e.Text.Length >0){
                                ViSDGlobalText.Text+=e.Text;
                        }
                }
        }
}
