using System.Text;

Console.Write("Enter filename: ");
string filename = Console.ReadLine()!;
Console.Write("Enter the path: ");
string path = Console.ReadLine()!;
FileStream? fstream = null;
if (Directory.Exists(path))
{
    if (Directory.GetFiles(path).Contains(path + "\\" + filename))
    {
        fstream = File.OpenRead(path + "\\" + filename);
    }
    else
    {
        foreach (var subdirectory in Directory.GetDirectories(path))
        {
            string newPath = new DirectoryInfo(subdirectory).FullName;
            if (Directory.GetFiles(newPath).Contains(newPath + "\\" + filename))
            {
                fstream = File.OpenRead(newPath + "\\" + filename);
                break;
            }
        }
    }

    byte[] buffer = new byte[fstream!.Length];
    fstream.Read(buffer, 0, buffer.Length);
    string textFromFile = Encoding.Default.GetString(buffer);
    Console.WriteLine(textFromFile);
}