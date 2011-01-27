/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2011-01-25
 * Time: 21:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Input;

using ICSharpCode.AvalonEdit.Editing;

namespace ViSD
{
	/// <summary>
	/// Description of Replace.
	/// </summary>
	public class Replace:ITextAreaInputHandler {
		private List<string> text = new List<string>();
		private TextArea textArea;
		private int curbegin;
		
		public Replace(TextArea textArea) {
			this.textArea = textArea;
		}
		
		public TextArea TextArea {
			get {
				return textArea;
			}
		}
		
		public void Attach() {
			textArea.TextEntering += TextEnteredHandler;
			textArea.KeyDown += KeyDownHandler;
			curbegin = textArea.Caret.Offset;
		}
		
		public void Detach() {
			textArea.TextEntering -= TextEnteredHandler;
			textArea.KeyDown -= KeyDownHandler;
		}
		
		private void TextEnteredHandler(object sender, TextCompositionEventArgs e) {
			text.Add(textArea.Document.GetText( textArea.Caret.Offset, 1));
			textArea.Document.Replace( textArea.Caret.Offset, e.Text.Length, e.Text);
			textArea.Caret.Offset++;
			e.Handled=true;
		}
		
		public void KeyDownHandler(object sender, KeyEventArgs e) {
			if ( e.Key == Key.Back ){
				e.Handled = true;
				if ( text.Count == 0) StopReplace();
				else{
					CurLeft();
					textArea.Document.Replace( textArea.Caret.Offset, 1, text[text.Count-1]);
					text.RemoveAt( text.Count - 1 );
				}
			}
			if ( e.Key == Key.Escape ){
				StopReplace();
			}
		}
		
		protected void Delete(){
			System.Windows.Documents.EditingCommands.Delete.Execute(null, textArea);
		}
		
		protected void CurLeft(){
			if ( textArea.Caret.Offset>0) textArea.Caret.Offset--;
		}
		
		public void StopReplace(){
			int len = textArea.Caret.Offset - curbegin;
			if ( len > 0 ){
				ViSDGlobalText.Text = textArea.Document.GetText( curbegin, len );
			}
			textArea.Caret.Offset = curbegin;
			ViSDGlobalCount.UpdLastUsed( new ViSD.Modes.ViCommadns.CmdRepeatReplace(), textArea);
			ViSDGlobalState.State = ViSDGlobalState.PrevState;
		}

	}
}
