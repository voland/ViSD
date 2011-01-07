﻿/*
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
        public class VimHandler: ITextAreaInputHandler{
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
                
                public VimHandler( TextArea ta ) {
                        TextArea = ta;
                        _txtarea.KeyDown+=KeyDown;
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
                
                public TextArea TextArea {
                        set {
                                _txtarea=value;
                        }
                        get {
                                return _txtarea;
                        }
                }
                
                private void KeyDown(object sender, KeyEventArgs e) {
                        e.Handled = ActualMode.ServeKey(e.Key, e.KeyboardDevice.Modifiers);
                }
                
                //                private bool ServeKey( KeyEventArgs e ){
                //                        bool Handled=true;
                //                        string key = KeyDecoder(e);
                //                        switch ( state ){
                //                                case State.Insert:
                //                                        break;
                //                                case State.Replace:
                //                                        switch ( e.Key){
                //                                                case Key.Escape:
                //                                                        state= State.Command;
                //                                                        Handled=true;
                //                                                        break;
                //                                                default:
                //                                                        Handled=false;
                //                                                        break;
                //                                        }
                //                                        break;
                //                                case State.Command:
                //                                        if ( !MoveIfMovement(key)){
                //                                                switch (key){
                //                                                        case "Oem1": //":"
                //                                                                state = State.CmdLine;
                //                                                                CmdString = ":";
                //                                                                break;
                //                                                        case "A":
                //                                                                CurEOL();
                //                                                                goto case "i";
                //                                                        case "a":
                //                                                                CurRight();
                //                                                                goto case "i";
                //                                                        case "i":
                //                                                                state = State.Insert;
                //                                                                break;
                //                                                        case "I":
                //                                                                CurBOL();
                //                                                                state = State.Insert;
                //                                                                break;
                //                                                        case "R":
                //                                                                state = State.Replace;
                //                                                                break;
                //                                                        case "x":
                //                                                                Delete();
                //                                                                break;
                //                                                        case "X":
                //                                                                Backspace();
                //                                                                break;
                //                                                        case "J":
                //                                                                JoinLines();
                //                                                                break;
                //                                                        case "o":
                //                                                                if (ctrl(e)){
                //                                                                        Back();
                //                                                                        break;
                //                                                                }else{
                //                                                                        CurEOL();
                //                                                                        TextArea.PerformTextInput("\n");
                //                                                                }
                //                                                                goto case "i";
                //                                                        case "C":
                //                                                                DelEOL();
                //                                                                goto case "i";
                //                                                        case "D":
                //                                                                DelEOL();
                //                                                                break;
                //                                                        case "O":
                //                                                                CurUP();
                //                                                                CurEOL();
                //                                                                TextArea.PerformTextInput("\n");
                //                                                                goto case "i";
                //                                                        case "u":
                //                                                                Undo();
                //                                                                break;
                //                                                        case "r":
                //                                                                if (ctrl(e)) Redo();
                //                                                                break;
                //                                                        case "v":
                //                                                                CurVisStarted = TextArea.Caret.Offset;
                //                                                                SelectVisual( CurVisStarted, CurVisStarted);
                //                                                                state = State.Visual;
                //                                                                break;
                //                                                        case "V":
                //                                                                CurVisStarted = TextArea.Caret.Offset;
                //                                                                SelectVisualLine(CurVisStarted, CurVisStarted);
                //                                                                state = State.VisualLine;
                //                                                                break;
                //                                                        case "LeftShift":
                //                                                        case "RightShift":
                //                                                        case "system":
                //                                                        case "leftctrl":
                //                                                        case "rightctrl":
                //                                                                break;
                //                                                        default:
                //                                                                if ( key.Length>0) assert(key);
                //                                                                break;
                //                                                }
                //                                        }
                //                                        break;
                //                                case State.Visual:
                //                                        if (MoveIfMovement(key)){
                //                                                SelectVisual( CurVisStarted, TextArea.Caret.Offset);
                //                                        }else{
                //                                                ApplyActionToSelection( key);
                //                                        }
                //                                        Handled = true;
                //                                        break;
                //                                case State.VisualLine:
                //                                        if (MoveIfMovement(key)){
                //                                                SelectVisualLine( CurVisStarted, TextArea.Caret.Offset);
                //                                        }else{
                //                                                ApplyActionToSelection( key);
                //                                        }
                //                                        Handled = true;
                //                                        break;
                //                                case State.CmdLine:
                //                                        assert(e.Key.ToString());
                //                                        switch ( e.Key ){
                //                                                case Key.Escape:
                //                                                        state= State.Command;
                //                                                        CmdString="";
                //                                                        break;
                //                                                case Key.Delete:
                //                                                case Key.Back:
                //                                                        CmdString = CmdString.Remove(CmdString.Length-1);
                //                                                        break;
                //                                                case Key.Enter:
                //                                                        state = State.Command;
                //                                                        string temp = CmdString;
                //                                                        CmdString="";
                //                                                        RunCommandLine(temp);
                //                                                        break;
                //                                                default:
                //                                                        if (key.Length==1) CmdString+=key;
                //                                                        break;
                //                                        }
                //                                        Handled = true;
                //                                        if (CmdString.Length==0) state = State.Command;
                //                                        break;
                //                        }
                //                        return Handled;
                //                }
                //                private void RunCommandLine( String cmd ){
                //                        switch (cmd){
                //                                case ":w":
                //                                        System.Windows.Forms.MessageBox.Show(cmd);
                //                                        break;
                //                                case ":mak":
                //                                        break;
                //                        }
                //                }
                //                private void ApplyActionToSelection(String key){
                //                        switch ( key){
                //                                case "V":
                //                                        if ( state == State.Visual ){
                //                                                state = State.VisualLine;
                //                                                RemoveSelection();
                //                                                SelectVisualLine(CurVisStarted, TextArea.Caret.Offset);
                //                                        }
                //                                        else goto case "esc";
                //                                        break;
                //                                case "v":
                //                                        if ( state == State.VisualLine ) {
                //                                                state = State.Visual;
                //                                                RemoveSelection();
                //                                                SelectVisual(CurVisStarted, TextArea.Caret.Offset);
                //                                        }
                //                                        else goto case "esc";
                //                                        break;
                //                                case "esc":
                //                                        RemoveSelection();
                //                                        state = State.Command;
                //                                        break;
                //                                case "x":
                //                                case "d":
                //                                        break;
                //                                case "X":
                //                                case "D":
                //                                        break;
                //                                case "c":
                //                                case "s":
                //                                        break;
                //                                case "C":
                //                                case "S":
                //                                        break;
                //                                case "p":
                //                                        break;
                //                                case "P":
                //                                        break;
                //                                case "y":
                //                                        break;
                //                                case "Y":
                //                                        break;
                //                                default:
                //                                        assert( key);
                //                                        break;
                //                        }
                //                }
                //                /// <summary>
                //                /// moves cursor depending on command
                //                /// </summary>
                //                /// <param name="key">key in string</param>
                //                /// <returns>teturn true if moved false if not</returns>
                //                private bool MoveIfMovement( String key){
                //                        switch (key){
                //                                case "down":
                //                                case "j":
                //                                        CurDown();
                //                                        break;
                //                                case "up":
                //                                case "k":
                //                                        CurUP();
                //                                        break;
                //                                case "left":
                //                                case "h":
                //                                        CurLeft();
                //                                        break;
                //                                case "right":
                //                                case "l":
                //                                        CurRight();
                //                                        break;
                //                                case "w":
                //                                        CurRightWord();
                //                                        break;
                //                                case "W":
                //                                        break;
                //                                case "e":
                //                                        break;
                //                                case "E":
                //                                        break;
                //                                case "b":
                //                                        CurLeftWord();
                //                                        break;
                //                                case "B":
                //                                        break;
                //                                default:
                //                                        return false;
                //                        }
                //                        return true;
                //                }
//
//
                //                private void SelectVisual(int start, int end){
                //                        TextArea.Selection = TextArea.Selection.StartSelectionOrSetEndpoint( start, end );
                //                }
//
                //                private void SelectVisualLine( int start, int end){
                //                        if ( start > end ) {
                //                                int temp = end;
                //                                end = start;
                //                                start = temp;
                //                        }
                //                        // get offset at the start and end of start line and end line
                //                        int start2 = TextArea.Document.GetLineByOffset(start).Offset;
                //                        int end2 = TextArea.Document.GetLineByOffset(end).EndOffset;
                //                        SelectVisual(start2, end2);
                //                }
                //                private void JoinLines(){
                //                        int cur = TextArea.Caret.Offset;
                //                        CurEOL();
                //                        TextArea.PerformTextInput(" ");
                //                        while (IsEmptyUnderCur()) Delete();
                //                        TextArea.Caret.Offset = cur;
                //                }
//
                //                private void RemoveSelection(){
                //                        TextArea.Selection = ICSharpCode.AvalonEdit.Editing.Selection.Empty;
                //                }
//

                //                private void DelEOL(){
                //                        System.Windows.Documents.EditingCommands.SelectToLineEnd.Execute(null, TextArea);
                //                        Delete();
                //                }
                //                private void CurEOL(){
                //                        System.Windows.Documents.EditingCommands.MoveToLineEnd.Execute(null, TextArea);
                //                }
                //                private void CurBOL(){
                //                        System.Windows.Documents.EditingCommands.MoveToLineStart.Execute(null, TextArea);
                //                }
//
                //                private void Undo(){
                //                        System.Windows.Input.ApplicationCommands.Undo.Execute(null, TextArea);
                //                }
                //                private void Redo(){
                //                        System.Windows.Input.ApplicationCommands.Redo.Execute(null, TextArea);
                //                }
//
                //                private void CurUP(){
                //                        System.Windows.Documents.EditingCommands.MoveUpByLine.Execute(null, TextArea);
                //                }
//
                //                private void CurDown(){
                //                        System.Windows.Documents.EditingCommands.MoveDownByLine.Execute(null, TextArea);
                //                }
                //                private void Delete(){
                //                        System.Windows.Documents.EditingCommands.Delete.Execute(null, TextArea);
                //                }
                //                private void Backspace(){
                //                        System.Windows.Documents.EditingCommands.Backspace.Execute(null, TextArea);
                //                }
//
//
//
                //                private String KeyDecoder( KeyEventArgs e ){
                //                        bool CapLet = ( e.KeyboardDevice.Modifiers == ModifierKeys.Shift );     //stands for capital letter
                //                        string letter = KeyConv.ConvertToString(e.Key);
                //                        if ( !CapLet ){
                //                                return letter.ToLower();
                //                        }
                //                        return letter;
                //                }
//
                //                private bool ctrl( KeyEventArgs e ){
                //                        if ( e.KeyboardDevice.Modifiers == ModifierKeys.Control ) return true;
                //                        return false;
                //                }
//
                //                private void assert(String message){
                //                        WorkbenchSingleton.Workbench.StatusBar.SetMessage(message, false, null);
                //                }
//
                //                //fields
                //                private String CmdString{
                //                        set {
                //                                if ( value == ":") TextArea.ActiveInputHandler = this;
                //                                if ( value == "" ) TextArea.ActiveInputHandler = TextArea.DefaultInputHandler;
                //                                _cmdString = value;
                //                                assert(_cmdString);
                //                        }
                //                        get{
                //                                return _cmdString;
                //                        }
                //                }
                //                private String _cmdString;
                //                private int CurVisStarted;
                //                private numbercolector nc;
                private TextArea _txtarea;
                //                private State state{
                //                        set{
                //                                switch ( value ){
                //                                        case State.Insert:
                //                                                assert("-- INSERT --");
                //                                                break;
                //                                        case State.Command:
                //                                                assert("-- COMMAND --");
                //                                                break;
                //                                        case State.Visual:
                //                                        case State.VisualLine:
                //                                                assert("-- VISUAL --");
                //                                                break;
                //                                }
                //                                VimGlobal.state = value;
                //                        }
                //                        get{
                //                                return VimGlobal.state;
                //                        }
                //                }
//
                
                public void Attach() {
                }
                
                public void Detach() {
                }
        }
}
