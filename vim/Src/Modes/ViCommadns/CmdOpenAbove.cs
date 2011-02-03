/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-19
 * Godzina: 21:37
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
	/// <summary>
	/// Description of CmdOpenAbove.
	/// </summary>
	[Movement]
	public class CmdOpenAbove:CmdWithTools{
		public CmdOpenAbove(){
		}
		
		public override void Execute( Object arg ){
			base.Execute(arg);
			System.Windows.Documents.EditingCommands.MoveUpByLine.Execute(null, arg as TextArea);
			System.Windows.Documents.EditingCommands.MoveToLineEnd.Execute(null, arg as TextArea);
			TextArea.PerformTextInput("\n");
		}
	}
}
