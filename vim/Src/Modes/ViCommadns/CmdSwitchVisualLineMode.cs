﻿/*
 * Created by SharpDevelop.
 * User: voland
 * Date: 2/9/2011
 * Time: 7:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ViSD.Modes.ViCommadns {
	/// <summary>
	/// Description of CmdSwitchVisualLineMode.
	/// </summary>
	public class CmdSwitchVisualLineMode:IViCommand {
		public CmdSwitchVisualLineMode() {
		}
		
		public void Execute(object arg) {
			ViSDGlobalState.State = State.VisualLine;
		}
		
		public bool CanExecute() {
			return true;
		}
	}
}
