/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2/8/2011
 * Time: 10:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ViSD.Modes.ViCommadns;
using ViSD.Modes.ViCommadns.VisualCommands;
using System.Windows.Input;

//FIXME: 0 key in visual mode doesnt work properly
//FIXME: on mouse click move selection to that point

namespace ViSD.Modes {
	/// <summary>
	/// Description of VisualLineMode.
	/// </summary>
	public class VisualLineMode:MoveMode {
		private int CurBeginPos;
		public VisualLineMode(VimHandler vh):base(vh) {
			CurBeginPos=0;
			IViCommand cmd = new CmdGoToCommandMode();
			AddCommand( cmd, Key.Escape, ModifierKeys.None );
			AddCommand( cmd, Key.Escape, ModifierKeys.Shift );
			AddCommand( new CmdYank(), Key.Y, ModifierKeys.Shift);
			AddCommand( new CmdYank(), Key.Y, ModifierKeys.None);
			IViCommand CutCmd = new CmdCut();
			AddCommand( CutCmd, Key.D, ModifierKeys.None );
			AddCommand( CutCmd, Key.D, ModifierKeys.Shift );
			AddCommand( CutCmd, Key.X, ModifierKeys.None );
			AddCommand( CutCmd, Key.X, ModifierKeys.Shift );
			AddCommand( new CmdPaste(), Key.P, ModifierKeys.Shift);
			AddCommand( new CmdPasteCopy(), Key.P, ModifierKeys.None);
			IViCommand rep = new CmdReplaceString();
			AddCommand( rep, Key.C, ModifierKeys.None);
			AddCommand( rep, Key.C, ModifierKeys.Shift);
			AddCommand( rep, Key.S, ModifierKeys.None);
			AddCommand( rep, Key.S, ModifierKeys.Shift);
			AddCommand( new CmdReplaceChar(), Key.R, ModifierKeys.None);
			
			RestKeys = new CmdNothing();
		}
		
		public override void Atached() {
			base.Atached();
			CurBeginPos = vh.TextArea.Caret.Offset;
			SelectVisual( CurBeginPos, CurBeginPos );
		}
		
		public override void Detached() {
			base.Detached();
			RemoveSelection();
			vh.TextArea.Caret.Offset = CurBeginPos;
		}
		
		public override bool ServeKey(System.Windows.Input.Key k, System.Windows.Input.ModifierKeys mk) {
			bool result = base.ServeKey(k, mk);
			ViSDGlobalCount.Process();
			int CurEndPos = vh.TextArea.Caret.Offset;
			SelectVisual( CurBeginPos, CurEndPos );
			return result;
		}
		
		private void SelectVisual(int start, int end){
			if ( ViSDGlobalState.State == State.VisualLine ){
				if ( start > end ) {
					int temp = start;
					start = end;
					end = temp;
				}
				if ( end < (vh.TextArea.Document.Text.Length -1)) end++;
				int start2 = vh.TextArea.Document.GetLineByOffset(start).Offset;
				int end2 = vh.TextArea.Document.GetLineByOffset(end).EndOffset;
				vh.TextArea.Selection = vh.TextArea.Selection.StartSelectionOrSetEndpoint( start2, end2+2 );
			} else if ( ViSDGlobalState.State == State.ArgumentMode ){
				//do nothing
			} else{
				RemoveSelection();
			}
		}
		
		private void RemoveSelection(){
			vh.TextArea.Selection = ICSharpCode.AvalonEdit.Editing.Selection.Empty;
		}
	}
}
