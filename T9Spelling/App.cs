namespace T9Spelling;

internal class App(IT9TranslatorService translatorService) : IApp
{
    public void Run(string inputFilePath, string outputFilePath)
    {
        var inputLines = File.ReadAllLines(inputFilePath);
        var testCasesCount = int.Parse(inputLines[0]);

        var results = new List<string>();

        for (var i = 1; i <= testCasesCount; i++)
        {
            var input = inputLines[i];
            var translatedMessage = translatorService.Translate(input);
            results.Add($"Case #{i}: {translatedMessage}");
        }

        File.WriteAllLines(outputFilePath, results);
    }
}