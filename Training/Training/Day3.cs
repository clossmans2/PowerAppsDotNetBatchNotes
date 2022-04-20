using System;
using System.IO;

public class Day3
{
    public string TextFileAndPath { get; set; }
    public string FileContents { get; set; }

    public Day3(string fileAndPath)
    {
        TextFileAndPath = fileAndPath;
    }

    public async Task<string> ReadFileAsync()
    {
        string textFileContents = await File.ReadAllTextAsync(TextFileAndPath);
        FileContents = textFileContents;
        return textFileContents;
    }

    public void WriteFileContentsToConsole()
    {
        Console.WriteLine(FileContents);
    }

}


public struct Day3Struct
{
	public Day3Struct()
    {

    }

	public const string Day3Topic = "structs";


}