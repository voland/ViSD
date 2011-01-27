/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2011-01-27
 * Time: 21:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
	/// <summary>
	/// Description of CmdRepeatReplace.
	/// </summary>
	public class CmdRepeatReplace:IViCommand {
		public CmdRepeatReplace() {
		}
		
		public void Execute(object arg) {
			TextArea ta = arg as TextArea;
			if ( ta!=null ){
				if ( (ta.Document.TextLength - ta.Caret.Offset) > ViSDGlobalText.Text.Length){
					ta.Document.Replace( ta.Caret.Offset, ViSDGlobalText.Text.Length, ViSDGlobalText.Text);
				}
			}
		}
		
		public bool CanExecute() {
			return true;
		}
	}
}
