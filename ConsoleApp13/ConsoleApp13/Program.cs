public class FolderSize
{
    public static long GetFolderSize(string folderPath)
    {
        long totalSize = 0;

        // Получаем список всех файлов и папок в указанной папке
        var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
        var directories = Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories);

        // Суммируем размер всех файлов
        foreach (var file in files)
        {
            var fileInfo = new FileInfo(file);
            totalSize += fileInfo.Length;
        }

        // Рекурсивно считаем размер вложенных папок
        foreach (var dir in directories)
        {
            totalSize += GetFolderSize(dir);
        }

        return totalSize;
    }
 
}
