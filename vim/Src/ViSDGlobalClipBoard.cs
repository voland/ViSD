/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2/12/2011
 * Time: 8:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes {
	/// <summary>
	/// Description of ViSDGlobalClipBoard.
	/// </summary>
	public class ViSDGlobalClipBoard {
		private static string _buffer="";
		
		public static void PasteCopy( TextArea ta ){
			string temp = ta.Selection.GetText( ta.Document );
			ta.Selection.ReplaceSelectionWithText( ta, _buffer );
			_buffer = temp;
		}
		
		public static void Paste( TextArea ta ){
			ta.Selection.ReplaceSelectionWithText( ta, _buffer );
		}
		
		public static void CopySelected( TextArea ta ){
			_buffer = ta.Selection.GetText( ta.Document );
		}
		
		public static void Copy( String text ){
			_buffer = text;
		}
	}
}
