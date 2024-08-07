namespace phase6.Services.IO.OutPutManager;

public interface IOutput<T>
{
    T OutputProcess(string input);
}