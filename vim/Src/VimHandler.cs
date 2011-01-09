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
using System.Windows.Input;
using ICSharpCode.SharpDevelop.Gui;
using ViSD.Modes;

namespace ViSD{
        /// <summary>
        /// public enum that represents the state of texteditor in vim mode
        /// </summary>
        /// <summary>
        /// This is Vim handler which should be added to TextArea.ActiveInputHandler
        /// </summary>
        public class VimHandler:TextAreaDefaultInputHandler{
                public IMode ActualMode{
                        set{
                                if ( _mode!=null ) _mode.Detached();
                                _mode=value;
                                _mode.Atached();
                        }
                        get{
                                return _mode;
                        }
                }
                private CommandMode CommandMode;
                private InsertMode InsertMode;
                private FindCharMode FindCharMode;
                private FindCharModeBack FindCharModeBack;
                private TillCharMode TillCharMode;
                private TillCharModeBack TillCharModeBack;
                
                
                private IMode _mode;
                
                public VimHandler( TextArea ta ):base(ta) {
                        CommandMode = new CommandMode(this);
                        InsertMode = new InsertMode(this);
                        FindCharMode = new FindCharMode(this);
                        FindCharModeBack = new FindCharModeBack(this);
                        TillCharMode = new TillCharMode(this);
                        TillCharModeBack = new TillCharModeBack(this);
                        
                        ViSDGlobalState.StateChanged+= delegate(object sender, State s) {
                                switch( s ){
                                        case State.Insert:
                                                ActualMode = InsertMode;
                                                break;
                                        case State.Command:
                                                ActualMode = CommandMode;
                                                break;
                                        case State.FindChar:
                                                ActualMode = FindCharMode;
                                                break;
                                        case State.FindCharBack:
                                                ActualMode = FindCharModeBack;
                                                break;
                                        case State.TillChar:
                                                ActualMode = TillCharMode;
                                                break;
                                        case State.TillCharBack:
                                                ActualMode= TillCharModeBack;
                                                break;
                                                
                                }
                        };
                        ViSDGlobalState.State = State.Command;
                }
                
                private void KeyDown(object sender, KeyEventArgs e) {
                        e.Handled = ActualMode.ServeKey(e.Key, e.KeyboardDevice.Modifiers);
                }
                
                public override void Attach() {
                        base.Attach();
                        TextArea.KeyDown+=KeyDown;
                }
                
                public override void Detach() {
                        base.Detach();
                        TextArea.KeyDown-=KeyDown;
                }
        }
}
