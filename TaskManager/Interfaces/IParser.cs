namespace TaskManager.Interfaces;

public interface IParser<T,Y>
{
    T Parse(Y input);
}