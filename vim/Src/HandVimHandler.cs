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
                public readonly CommandMode CommandMode;
                public readonly InsertMode InsertMode;
                public readonly ArgumentMode ArgumentMode;
                private IMode _mode;
                
                public readonly String FileName;
                
                public VimHandler( TextArea ta, String FileName ):base(ta) {
                        this.FileName = FileName;
                        CommandMode = new CommandMode(this);
                        InsertMode = new InsertMode(this);
                        ArgumentMode = new ArgumentMode(this);
                        
                        ViSDGlobalState.StateChanged+= delegate(object sender, State s) {
                                ActualMode = GetModeByState(s);
                        };
                        
                        ActualMode = GetModeByState(ViSDGlobalState.State);
                }
                
                private void KeyDown(object sender, KeyEventArgs e) {
                        e.Handled = ActualMode.ServeKey(e.Key, e.KeyboardDevice.Modifiers);
                        ViSDGlobalCount.Process();
                }
                
                public override void Attach() {
                        base.Attach();
                        TextArea.KeyDown+=KeyDown;
                }
                
                public override void Detach() {
                        base.Detach();
                        TextArea.KeyDown-=KeyDown;
                }
                
                private IMode GetModeByState( State s ){
                        switch( s ){
                                case State.Insert:
                                        return InsertMode;
                                case State.Command:
                                        return CommandMode;
                                case State.ArgumentMode:
                                        return ArgumentMode;
                                default:
                                        return CommandMode;
                        }
                }
        }
}
