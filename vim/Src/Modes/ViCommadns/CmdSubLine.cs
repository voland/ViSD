/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2011-01-23
 * Time: 19:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
	/// <summary>
	/// Description of CmdSubLine.
	/// </summary>
	[Movement]
	public class CmdSubLine:CmdDelEOL {
		public CmdSubLine() {
		}
		public override void Execute(object arg) {
			if ( arg is TextArea ){
				(arg as TextArea).Caret.Column=0;
			}
			System.Windows.Documents.EditingCommands.MoveToLineStart.Execute(null, arg as TextArea);
			base.Execute(arg);
		}
	}
}
