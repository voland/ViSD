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
	/// Description of CmdRepeatReplaceChar.
	/// </summary>
	public class CmdRepeatReplaceChar:IViCommand {
		public int lettersToDelete=0;
		public CmdRepeatReplaceChar(int ltd) {
			lettersToDelete = ltd;
		}
		
		public void Execute(object arg) {
			ArgumentMode am;
			if (( am = arg as ArgumentMode)!=null){
				TextArea ta;
				if (( ta = am.vh.TextArea)!=null){
					if (lettersToDelete>0){
						if (( ta.Caret.Offset + lettersToDelete) >= ta.Document.TextLength){
							lettersToDelete = ta.Document.TextLength - ta.Caret.Offset;
						}
						//prepeare string
						if ( ViSDGlobalText.Text.Length > 0){
							string s = "";
							for ( int i=0; i<lettersToDelete; i++) s+=ViSDGlobalText.Text;
							ta.Document.Replace( ta.Caret.Offset, lettersToDelete, s);
							ViSDGlobalCount.UpdLastUsed( this, am );
						}
					}
				}
			}
		}
		
		public bool CanExecute() {
			return true;
		}
	}
}
