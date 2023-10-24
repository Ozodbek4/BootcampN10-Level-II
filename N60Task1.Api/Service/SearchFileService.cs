namespace N60Task1.Api.Service;

public class SearchFileService
{
    public string SearchFolder(string path, string folderName)
    {
        var directories = Directory.GetDirectories(path, searchPattern: "*", SearchOption.TopDirectoryOnly);
        for (int i = 0; i < directories.Length; i++)
        {
            if (!directories[i].Equals("F:\\System Volume Informatoin"))
            {
                var fileName = SearchFile(directories[i], folderName);
                if(fileName is not null)
                {
                    return fileName;
                }
            }
        }
        return "Bunday file mavjud emas";
    }

    public string SearchFile(string path, string fileName)
    {
        var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);
        var needFile = files.FirstOrDefault(x => Path.GetFileName(x).Equals(fileName, StringComparison.OrdinalIgnoreCase));
        return needFile;
    }
}