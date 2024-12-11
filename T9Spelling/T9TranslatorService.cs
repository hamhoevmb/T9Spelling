using System.Text;
using AutoMapper;

namespace T9Spelling;

public class T9TranslatorService(IMapper mapper) : IT9TranslatorService
{
    public string Translate(string message)
    {
        var result = new StringBuilder();

        for (int i = 0; i < message.Length; i++)
        {
            var currentChar = message[i];
            var currentKey = mapper.Map<string>(currentChar);

            if (i > 0 && result.Length > 0 && result[^1] == currentKey[0])
            {
                result.Append(" ");
            }

            result.Append(currentKey);
        }

        return result.ToString();
    }
}