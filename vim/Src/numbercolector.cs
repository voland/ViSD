/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2010-12-29
 * Godzina: 17:43
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Windows.Input;

namespace Vim
{
        /// <summary>
        /// Description of numbercolector.
        /// </summary>
        public class numbercolector{
                public numbercolector(){
                        _number = 0;
                        KeyConv = new KeyConverter();
                }
                /// <summary>
                /// funkcja dodaje cyfre do liczy
                /// </summary>
                /// <param name="k">Key</param>
                /// <returns>returns true if acepteed</returns>
                public bool AddNumber( KeyEventArgs e){
                        if ( e.KeyboardDevice.Modifiers != ModifierKeys.None) return false;
                        if ((e.Key < Key.D0)||(e.Key>Key.D9)) return false;
                        _number*=10;
                        string nr = KeyDecoder( e);
                        _number+= System.Convert.ToInt32(nr, 10);
                        return true;
                }
                
                public void RstNo(){
                        _number=0;
                }
                
                public override string ToString(){
                        return Number.ToString();
                }
                
                public String KeyDecoder( KeyEventArgs e ){
                        bool CapLet = ( e.KeyboardDevice.Modifiers == ModifierKeys.Shift );     //stands for capital letter
                        string letter = KeyConv.ConvertToString(e.Key);
                        if ( !CapLet ){
                                return letter.ToLower();
                        }
                        return letter;
                }
                public int Number{
                        get {
                                int temp;
                                if (_number==0) temp=1;
                                else temp = _number;
                                _number=0;
                                return temp;
                        }
                }
                
                KeyConverter KeyConv;
                private int _number;
        }
}
