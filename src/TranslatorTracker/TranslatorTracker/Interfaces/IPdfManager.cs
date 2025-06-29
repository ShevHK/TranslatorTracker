namespace TranslatorTracker.Interfaces
{
    internal interface IPdfManager
    {
        int GetSymbolsCount(string path, bool includeSpaces = true);
    }
}
