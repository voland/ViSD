/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-05
 * Godzina: 09:51
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Collections.Generic;
using ViSD.Modes.ViCommadns;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.Editing;

namespace ViSD.Modes {
	/// <summary>
	/// Description of BasicMode.
	/// </summary>
	public class BasicMode:IMode{
		protected ViInputList ViInputList = new ViInputList();
		VimHandler vh;
		protected IViCommand PendingCommand;
		public IViCommand RestKeys;
		
		public BasicMode(VimHandler vh) {
			this.vh = vh;
			AddCommand(new CmdNextTab(), Key.PageDown, ModifierKeys.Control);
			AddCommand( new CmdPrevTab(), Key.PageUp, ModifierKeys.Control);
		}
		
		public void AddCommand(IViCommand vc, Key k, ModifierKeys mk){
			ViInputList.Add( vc, k, mk);
		}
		/// <summary>
		/// Serves keypressed
		/// </summary>
		/// <param name="k"></param>
		/// <param name="mk">return true if key was served otheervise false</param>
		/// <returns></returns>
		bool IMode.ServeKey(Key k, ModifierKeys mk) {
			foreach ( ViInputBinding vib in ViInputList ){
				if ( vib.ExeIfKey(vh.TextArea, k, mk) == true ) return true;
			}
			if (RestKeys!=null) {
				RestKeys.Execute(vh.TextArea);
				return true;
			}
			return false;
		}
		
		void IMode.Atached(){
			if ( PendingCommand != null ) PendingCommand.Execute(vh.TextArea);
			PendingCommand= null;
			if ( Ataching!= null) Ataching( this, new EventArgs());
		}
		
		void IMode.Detached(){
			if (Detaching !=null) Detaching(this, new EventArgs());
		}
		
		public delegate void Tached( Object o, EventArgs e);
		public event Tached Ataching;
		public event Tached Detaching;
		
	}
}
