/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2011-01-23
 * Time: 19:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes.ViCommadns
{
	/// <summary>
	/// Description of CmdDelEOL.
	/// </summary>
	public class CmdDelEOL:CmdWithTools {
		public CmdDelEOL() {
		}
		
		public override void Execute(object arg) {
			TextArea =  arg as TextArea;
			if ( TextArea!= null ){
				base.Execute( TextArea );
				if (CanExecute()){
					ViSDGlobalCount.UpdLastUsed( this, arg );
					DelEOL();
				}
			}
		}
		
	}
}
