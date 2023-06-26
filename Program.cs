internal class Program
{
    private static void Main(string[] args)
    {
        DirectoryInfo notes = new DirectoryInfo(args[0]);

        notes.CreateSubdirectory("ordered");
        DirectoryInfo orderedNotes = new DirectoryInfo(notes.FullName + "/ordered/");

        List<FileInfo> orderedFiles = notes.EnumerateFiles().Where(file => file.Name.EndsWith(".pdf")).OrderBy(file => FileNameToDays(file.Name)).ToList();

        uint index = 0;
        foreach (FileInfo file in orderedFiles)
        {
            string newFullName = orderedNotes.FullName + $"/{index.ToString("000")}-" + file.Name;
            if (File.Exists(newFullName))
                File.Delete(newFullName);

            file.CopyTo(newFullName);
            index++;
        }

        Console.WriteLine($"Finished ordering, check out {orderedNotes.FullName}");
    }

    private static int FileNameToDays(string filename)
    {
        string dateString;
        try
        {
            dateString = filename.Split("Appunti ")[1].Split(".pdf")[0] ?? "";
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine($"Unable to parse string {filename}");
            return -1;
        }

        int[] dateComponents;
        try
        {
            dateComponents = dateString.Split("-").Select(comp => Convert.ToInt32(comp)).ToArray();
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse string {filename}");
            return -1;
        }

        if (dateComponents.Length == 2)
            dateComponents = dateComponents.Append(0).ToArray();

        if (dateComponents.Length == 3)
        {
            return dateComponents[0] +
                    dateComponents[1] * 31 +
                    dateComponents[2] * 372;
        }
        else
        {
            Console.WriteLine($"Unable to parse string {filename}");
            return -1;
        }
    }
}