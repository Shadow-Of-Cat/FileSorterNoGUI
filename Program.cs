
using System.IO;
using System.Linq;

// ...

DirectoryInfo DirIn = new DirectoryInfo("C:/Users/user/Downloads"); //old directory

DirectoryInfo DirOut = new DirectoryInfo("E:/Загрузки/Форматы"); //new directory
//DirectoryInfo[] subdirs = DirIn.GetDirectories();

string [] AllFiles=System.IO.Directory.GetFiles(DirIn.FullName); 
if (AllFiles.Length==0) //no files in directory
    return;

 string FileExtensions=null; 
foreach(string s in AllFiles) //for each file in directory
{
    FileExtensions+=(Path.GetExtension(s))+" ";
   
}
    FileExtensions=string.Join(" ",FileExtensions.Split(new char[] { ' ' }).Distinct()); //remove duplicate .extensions
 Console.WriteLine(FileExtensions);
 foreach (string s  in FileExtensions.Split(' '))    //for each extension
 {
  DirOut = new DirectoryInfo(DirOut.FullName+s+"/"); //create new directory
  Console.WriteLine(DirOut);
    DirOut.Create();
    AllFiles=System.IO.Directory.GetFiles(DirIn.FullName,"*"+s);
        foreach (string file in AllFiles)                           //for each file in directory with .extension
        {

            File.Move(file,DirOut.FullName+Path.GetFileName(file));    //move file to new directory
        }

 }

