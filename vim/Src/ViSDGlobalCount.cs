/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-15
 * Godzina: 18:18
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Windows.Input;
using ViSD.Modes.ViCommadns;

namespace ViSD{
        /// <summary>
        /// This class works like a counter while typeing numbers before command
        /// </summary>
        public class ViSDGlobalCount{
                static ViSDGlobalCount(){
                        _number = 0;
                        KeyConv = new KeyConverter();
                }
                /// <summary>
                /// Function adds number
                /// </summary>
                /// <param name="k">Key</param>
                /// <returns>returns true if acepteed</returns>
                public static bool AddNumber( Key k, ModifierKeys m){
                        if ( m != ModifierKeys.None) return false;
                        if ((k < Key.D0)||(k>Key.D9)) return false;
                        _number*=10;
                        string nr = KeyDecoder(k,m);
                        _number+= System.Convert.ToInt32(nr, 10);
                        if (_number == 0) return false;
                        return true;
                }
                /// <summary>
                /// Resets internal No
                /// </summary>
                public static void RstNo(){
                        _number=0;
                }
                private static String KeyDecoder( Key k, ModifierKeys m ){
                        bool CapLet = ( m == ModifierKeys.Shift );     //stands for capital letter
                        string letter = KeyConv.ConvertToString(k);
                        if ( !CapLet ){
                                return letter.ToLower();
                        }
                        return letter;
                }
                
                public static int Number{
                        get {
                                if (_number==0) return 1;
                                return _number;
                        }
                        set {
                                _number = value;
                        }
                }
                
                public static void Process(){
                        if ( LastUsedArgument !=null ){
                                if ( LastUsedCommand!=null){
                                        int r = _number -1;
                                        _number=0;
                                        while ( r-->0){
                                                LastUsedCommand.Execute(LastUsedArgument);
                                        }
                                        ResetAll();
                                }
                        }
                }
                
                public static void ResetAll(){
                        ResetCommand();
                        RstNo();
                }
                
                public static void ResetCommand(){
                        _lastusedargument=null;
                        _lastusedcommand=null;
                }
                
                private static KeyConverter KeyConv;
                public static int _number;
                
                public static ViSD.Modes.ViCommadns.IViCommand LastUsedCommand{
                        get{
                                return _lastusedcommand;
                        }
                }
                
                public static Object LastUsedArgument{
                        get{
                                return _lastusedargument;
                        }
                }
                
                public static void UpdLastUsed( IViCommand c, Object a){
                        _lastusedcommand = c;
                        _lastusedargument = a;
                        if ( !c.GetType().IsDefined(typeof(MovementAttribute), false)){
                                LastUsedCommandForDot = c;
                                LastUsedArgumentForDot = a;
                        }
                        
                }
                
                private static ViSD.Modes.ViCommadns.IViCommand _lastusedcommand;
                private static Object _lastusedargument;
                
                public static ViSD.Modes.ViCommadns.IViCommand LastUsedCommandForDot;
                public static Object LastUsedArgumentForDot;

        }
}
