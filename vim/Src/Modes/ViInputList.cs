/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-05
 * Godzina: 14:04
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using ViSD.Modes.ViCommadns;
using System.Windows.Input;


namespace ViSD.Modes
{
        /// <summary>
        /// Description of ViInputList.
        /// </summary>
        public class ViInputList:IEnumerable{
                private ArrayList inputList;
                public ViInputList(){
                        inputList = new ArrayList();
                }
                
                public ViInputBinding GetAt( int idx ){
                        return (ViInputBinding)inputList[idx];
                }
                
                public IEnumerator GetEnumerator()                {
                        return inputList.GetEnumerator();
                }
                
                public void Add(IViCommand vc, Key k, ModifierKeys mk){
                        inputList.Add(new ViInputBinding(vc, k, mk));
                }
        }
}
