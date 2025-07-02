namespace trans.tracker.lb.Interfaces
{
    public interface IPdfManager
    {
        int GetSymbolsCount(string path, bool includeSpaces = true);
    }
}
