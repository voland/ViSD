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

namespace Vim{
        /// <summary>
        /// public enum that represents the state of texteditor in vim mode
        /// </summary>
        public enum State {
                Unknown = 0,
                Normal,
                Command,
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
        
        /// <summary>
        /// This is Vim handler which should be added to TextArea.ActiveInputHandler
        /// </summary>
        public class VimHandler{
                
                public VimHandler( TextArea ta ) {
                        TextArea = ta;
                        _txtarea.KeyDown+=KeyDown;
                        state = State.Command;
                        nc = new numbercolector();
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
                        bool Handled = true;
                        if ( !nc.AddNumber(e)){
                                int rep = nc.Number;
                                while ( (rep--)>0)
                                        Handled = ServeKey( e);
                        }
                        e.Handled = Handled;
                }
                
                private bool ServeKey( KeyEventArgs e ){
                        bool Handled=true;
                        string key = KeyDecoder(e);
                        switch ( state ){
                                case State.Insert:
                                        switch ( e.Key){
                                                case Key.Escape:
                                                        state= State.Command;
                                                        Handled=true;
                                                        break;
                                                default:
                                                        Handled=false;
                                                        break;
                                        }
                                        break;
                                        
                                case State.Replace:
                                        switch ( e.Key){
                                                case Key.Escape:
                                                        state= State.Command;
                                                        Handled=true;
                                                        break;
                                                default:
                                                        Handled=false;
                                                        break;
                                        }
                                        break;
                                case State.Command:
                                        if ( !MoveIfMovement(key)){
                                                switch (key){
                                                        case "A":
                                                                CurEOL();
                                                                goto case "i";
                                                        case "a":
                                                                CurRight();
                                                                goto case "i";
                                                        case "i":
                                                                state = State.Insert;
                                                                break;
                                                        case "I":
                                                                CurBOL();
                                                                state = State.Insert;
                                                                break;
                                                        case "R":
                                                                state = State.Replace;
                                                                break;
                                                        case "x":
                                                                Delete();
                                                                break;
                                                        case "X":
                                                                Backspace();
                                                                break;
                                                        case "o":
                                                                CurEOL();
                                                                TextArea.PerformTextInput("\n");
                                                                goto case "i";
                                                        case "C":
                                                                DelEOL();
                                                                goto case "i";
                                                        case "D":
                                                                DelEOL();
                                                                break;
                                                        case "O":
                                                                CurUP();
                                                                CurEOL();
                                                                TextArea.PerformTextInput("\n");
                                                                goto case "i";
                                                        case "v":
                                                                CurVisStarted = TextArea.Caret.Offset;
                                                                SelectVisual( CurVisStarted, CurVisStarted);
                                                                state = State.Visual;
                                                                break;
                                                        case "V":
                                                                CurVisStarted = TextArea.Caret.Offset;
                                                                SelectVisualLine(CurVisStarted, CurVisStarted);
                                                                state = State.VisualLine;
                                                                break;
                                                        case "LeftShift":
                                                        case "RightShift":
                                                        case "system":
                                                        case "leftctrl":
                                                        case "rightctrl":
                                                                break;
                                                        default:
                                                                if ( key.Length>0) assert(key);
                                                                break;
                                                }
                                        }
                                        break;
                                case State.Visual:
                                        if (MoveIfMovement(key)){
                                                SelectVisual( CurVisStarted, TextArea.Caret.Offset);
                                        }else{
                                                ApplyActionToSelection( key);
                                        }
                                        Handled = true;
                                        break;
                                case State.VisualLine:
                                        if (MoveIfMovement(key)){
                                                SelectVisualLine( CurVisStarted, TextArea.Caret.Offset);
                                        }else{
                                                ApplyActionToSelection( key);
                                        }
                                        Handled = true;
                                        break;
                        }
                        return Handled;
                }
                private void ApplyActionToSelection(String key){
                        switch ( key){
                                case "V":
                                        if ( state == State.Visual ){
                                                state = State.VisualLine;
                                                RemoveSelection();
                                                SelectVisualLine(CurVisStarted, TextArea.Caret.Offset);
                                        }
                                        else goto case "esc";
                                        break;
                                case "v":
                                        if ( state == State.VisualLine ) {
                                                state = State.Visual;
                                                RemoveSelection();
                                                SelectVisual(CurVisStarted, TextArea.Caret.Offset);
                                        }
                                        else goto case "esc";
                                        break;
                                case "esc":
                                        RemoveSelection();
                                        state = State.Command;
                                        break;
                                case "x":
                                case "d":
                                        break;
                                case "X":
                                case "D":
                                        break;
                                case "c":
                                case "s":
                                        break;
                                case "C":
                                case "S":
                                        break;
                                case "p":
                                        break;
                                case "P":
                                        break;
                                case "y":
                                        break;
                                case "Y":
                                        break;
                                default:
                                        assert( key);
                                        break;
                        }
                }
                /// <summary>
                /// moves cursor depending on command
                /// </summary>
                /// <param name="key">key in string</param>
                /// <returns>teturn true if moved false if not</returns>
                private bool MoveIfMovement( String key){
                        switch (key){
                                case "down":
                                case "j":
                                        CurDown();
                                        break;
                                case "up":
                                case "k":
                                        CurUP();
                                        break;
                                case "left":
                                case "h":
                                        CurLeft();
                                        break;
                                case "right":
                                case "l":
                                        CurRight();
                                        break;
                                case "w":
                                        CurRightWord();
                                        break;
                                case "W":
                                        do {
                                                CurRightWord();
                                        } while( !IsEmptyBeforeCur());
                                        break;
                                case "e":
                                        while ( IsEmptyUnderCur() ) CurRightWord();
                                        CurRightWord();
                                        while( IsEmptyBeforeCur()){
                                                CurLeft();
                                        }
                                        break;
                                case "E":
                                        while ( IsEmptyUnderCur() ) CurRightWord();
                                        do {
                                                CurRightWord();
                                        } while( !IsEmptyBeforeCur());
                                        while( IsEmptyBeforeCur()) {
                                                CurLeft();
                                        }
                                        break;
                                case "b":
                                        CurLeftWord();
                                        break;
                                case "B":
                                        do {
                                                CurLeftWord();
                                        } while( !IsEmptyBeforeCur());
                                        break;
                                default:
                                        return false;
                        }
                        return true;
                }
                
                private bool IsEmptyUnderCur(){
                        int caret = TextArea.Caret.Offset;
                        if  (( caret >= TextArea.Document.TextLength )||(caret<0)) return false;
                        char ch = TextArea.Document.GetCharAt(caret);
                        if (( ch == ' ' )||(ch=='\t')||(ch=='\x0d')||(ch=='\x0a')) return true;
                        return false;
                }
                
                private bool IsEmptyBeforeCur(){
                        int caret = TextArea.Caret.Offset;
                        caret--;
                        char ch='a'; //losowo 'a' ale to nie ma znaczenia w tym momencie
                        if (caret>=0){
                                ch = TextArea.Document.GetCharAt(caret);
                        } else {
                                return true;
                        }
                        if (( ch == ' ' )||(ch=='\t')||(ch=='\x0d')||(ch=='\x0a')) return true;
                        return false;
                }
                
                private void SelectVisual(int start, int end){
                        TextArea.Selection = TextArea.Selection.StartSelectionOrSetEndpoint( start, end );
                }
                
                private void SelectVisualLine( int start, int end){
                        if ( start > end ) {
                                int temp = end;
                                end = start;
                                start = temp;
                        }
                        // get offset at the start and end of start line and end line
                        int start2 = TextArea.Document.GetLineByOffset(start).Offset;
                        int end2 = TextArea.Document.GetLineByOffset(end).EndOffset;
                        SelectVisual(start2, end2);
                }
                
                private void RemoveSelection(){
                        TextArea.Selection = ICSharpCode.AvalonEdit.Editing.Selection.Empty;
                }

                private void DelEOL(){
                        System.Windows.Documents.EditingCommands.SelectToLineEnd.Execute(null, TextArea);
                        Delete();
                }
                private void CurEOL(){
                        System.Windows.Documents.EditingCommands.MoveToLineEnd.Execute(null, TextArea);
                }
                private void CurBOL(){
                        System.Windows.Documents.EditingCommands.MoveToLineStart.Execute(null, TextArea);
                }
                private void CurLeft(){
                        System.Windows.Documents.EditingCommands.MoveLeftByCharacter.Execute(null, TextArea);
                }
                
                private void CurRight(){
                        System.Windows.Documents.EditingCommands.MoveRightByCharacter.Execute(null, TextArea);
                }
                
                private void CurLeftWord(){
                        System.Windows.Documents.EditingCommands.MoveLeftByWord.Execute(null, TextArea);
                }
                
                private void CurRightWord(){
                        System.Windows.Documents.EditingCommands.MoveRightByWord.Execute(null, TextArea);
                }
                
                private void CurUP(){
                        System.Windows.Documents.EditingCommands.MoveUpByLine.Execute(null, TextArea);
                }
                
                private void CurDown(){
                        System.Windows.Documents.EditingCommands.MoveDownByLine.Execute(null, TextArea);
                }
                private void Delete(){
                        System.Windows.Documents.EditingCommands.Delete.Execute(null, TextArea);
                }
                private void Backspace(){
                        System.Windows.Documents.EditingCommands.Backspace.Execute(null, TextArea);
                }
                
                
                
                private String KeyDecoder( KeyEventArgs e ){
                        bool CapLet = ( e.KeyboardDevice.Modifiers == ModifierKeys.Shift );     //stands for capital letter
                        string letter = KeyConv.ConvertToString(e.Key);
                        if ( !CapLet ){
                                return letter.ToLower();
                        }
                        return letter;
                }
                
                private void assert(String message){
                        WorkbenchSingleton.Workbench.StatusBar.SetMessage(message, false, null);
                }
                
                //fields
                private int CurVisStarted;
                private numbercolector nc;
                private TextArea _txtarea;
                private State state;
                private KeyConverter KeyConv = new KeyConverter();
                
        }
}
