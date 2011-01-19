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
        //FIXME: open above whle being on first line doesn't work
        /// <summary>
        /// Description of CmdOpenAboveInsert.
        /// </summary>
        public class CmdOpenAboveInsert:CmdWithTools{
                private IViCommand movecur;
                public CmdOpenAboveInsert(){
                        movecur = new CmdOpenAbove();
                }
                
                public override void Execute(object arg){
                        ViSDGlobalCount.ResetCommand();
                        ViSDGlobalText.UpdateMove( movecur, arg );
                        movecur.Execute( arg );
                        ViSDGlobalState.State= State.Insert;
                }
        }
}
