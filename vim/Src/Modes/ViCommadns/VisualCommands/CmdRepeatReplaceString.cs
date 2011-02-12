/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2/12/2011
 * Time: 2:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns.VisualCommands
{
	/// <summary>
	/// Description of CmdRepeatReplaceString.
	/// </summary>
	public class CmdRepeatReplaceString:IViCommand {
		private int lettersToDelete=0;
		public CmdRepeatReplaceString(int ltd) {
			lettersToDelete = ltd;
		}
		
		public void Execute(object arg) {
			TextArea ta;
			if (( ta = arg as TextArea)!=null){
				if (lettersToDelete>0){
					if (( ta.Caret.Offset + lettersToDelete) >= ta.Document.TextLength){
						lettersToDelete = ta.Document.TextLength - ta.Caret.Offset;
					}
					ta.Document.Remove( ta.Caret.Offset, lettersToDelete );
				}
			}
		}
		
		public bool CanExecute() {
			return true;
		}
	}
}
