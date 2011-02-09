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
using System.Windows.Input;

//FIXME: 0 key in visual mode doesnt work properly

namespace ViSD.Modes {
	/// <summary>
	/// Description of VisualMode.
	/// </summary>
	public class VisualMode:MoveMode {
		private int CurBeginPos;
		public VisualMode(VimHandler vh):base(vh) {
			CurBeginPos=0;
			IViCommand cmd = new CmdGoToCommandMode();
			AddCommand( cmd, Key.Escape, ModifierKeys.None );
			AddCommand( cmd, Key.Escape, ModifierKeys.Shift );
			RestKeys = new CmdNothing();
		}
		
		public override void Atached() {
			base.Atached();
			CurBeginPos = vh.TextArea.Caret.Offset;
		}
		
		public override void Detached() {
			base.Detached();
			RemoveSelection();
		}
		
		public override bool ServeKey(System.Windows.Input.Key k, System.Windows.Input.ModifierKeys mk) {
			bool result = base.ServeKey(k, mk);
			ViSDGlobalCount.Process();
			int CurEndPos = vh.TextArea.Caret.Offset;
			SelectVisual( CurBeginPos, CurEndPos );
			return result;
		}
		
		private void SelectVisual(int start, int end){
			if ( start > end ) {
				int temp = start;
				start = end;
				end = temp;
			}
			if ( end < (vh.TextArea.Document.Text.Length -1)) end++;
			vh.TextArea.Selection = vh.TextArea.Selection.StartSelectionOrSetEndpoint( start, end );
		}
		
		private void RemoveSelection(){
			vh.TextArea.Selection = ICSharpCode.AvalonEdit.Editing.Selection.Empty;
		}
	}
}
