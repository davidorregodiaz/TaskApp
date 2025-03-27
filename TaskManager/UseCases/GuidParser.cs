using TaskManager.Interfaces;

namespace TaskManager.UseCases;

public class GuidParser : IParser<Guid,string>
{
    public Guid Parse(string input)
    {
        try
        {
            return Guid.Parse(input);
        }
        catch (FormatException formatException)
        {
            return Guid.Empty;
        }
    }
}