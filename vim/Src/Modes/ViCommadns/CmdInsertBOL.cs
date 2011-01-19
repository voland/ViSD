/*
 * Created by SharpDevelop.
 * User: malwi
 * Date: 2011-01-06
 * Time: 15:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ViSD.Modes.ViCommadns
{
        /// <summary>
        /// Description of CmdInsertBOL.
        /// </summary>
        public class CmdInsertBOL:CmdWithTools{
                private IViCommand movecur;
                public CmdInsertBOL(){
                        movecur = new CmdBOLSoft();
                }
                
                public override void Execute(object arg){
                        ViSDGlobalCount.ResetCommand();
                        ViSDGlobalText.UpdateMove( movecur, arg );
                        movecur.Execute( arg );
                        ViSDGlobalState.State= State.Insert;
                }
        }
}
