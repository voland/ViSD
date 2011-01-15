/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: voland
 * Data: 2011-01-13
 * Godzina: 20:41
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ICSharpCode.SharpDevelop.Gui;
using System.ComponentModel;
using System.Reflection;
using ICSharpCode.SharpDevelop.Bookmarks;

//TODO: Add integration withy shar develop bookmarks

namespace ViSD.Bookmarks{
        /// <summary>
        /// Description of ViSDGlobalBookmarks.
        /// </summary>
        public static class ViSDGlobalBookmarks{
                public static BookmarkCollection Bookmarks;
                private static String bookmarkfilename;
                private static String path;
                private static String completepath{
                        get{
                                return path+bookmarkfilename;
                        }
                }
                
                static ViSDGlobalBookmarks(){
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        
                        bookmarkfilename = "bookmarks.visd";
                        path = assembly.Location;
                        path = path.Remove(path.LastIndexOf(@"\")+1);
                        
                        WorkbenchSingleton.MainWindow.Closing+= delegate(object sender, CancelEventArgs e) {
                                Save();
                        };
                        
                        Load();
                }
                
                public static void Load(){
                        try{
                                using ( FileStream fs = new FileStream( completepath, FileMode.Open)){
                                        BinaryFormatter bf = new BinaryFormatter();
                                        Bookmarks = (BookmarkCollection)bf.Deserialize(fs);
                                }
                        }catch{
                                Bookmarks = new BookmarkCollection();
                        }
                }
                
                public static void ShowBookmarks(){
                        String lala = " ";
                        foreach ( ViSDBookmark b in Bookmarks ){
                                lala += String.Format( "{0}, {1}, {2}\n", b.Bookmark, b.FileName, b.Line);
                                
                        }
                        System.Windows.Forms.MessageBox.Show(lala);
                }
                
                public static void Save(){
                        using ( FileStream fs = new FileStream(completepath, FileMode.Create)){
                                BinaryFormatter bf = new BinaryFormatter();
                                try{
                                        bf.Serialize( fs, Bookmarks);
                                }catch{
                                }finally{
                                        fs.Close();
                                }
                        }
                }
        }
}