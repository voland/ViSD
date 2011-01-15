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
                }
                
                public static void Process(){
                        if ( LastUsedArgument !=null ){
                                if ( LastUsedCommand!=null){
                                        int r = _number -1;
                                        _number=0;
                                        while ( r-->0){
                                                LastUsedCommand.Execute(LastUsedArgument);
                                        }
                                        ResetCommand();
                                }
                        }
                }
                
                public static void ResetAll(){
                        ResetCommand();
                        RstNo();
                }
                
                public static void ResetCommand(){
                        LastUsedCommand=null;
                        LastUsedArgument=null;
                }
                
                private static KeyConverter KeyConv;
                private static int _number;
                public static ViSD.Modes.ViCommadns.IViCommand LastUsedCommand;
                public static Object LastUsedArgument;
        }
}
