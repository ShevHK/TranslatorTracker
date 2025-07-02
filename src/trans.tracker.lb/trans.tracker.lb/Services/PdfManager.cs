using System.Text.RegularExpressions;
using trans.tracker.lb.Interfaces;
using UglyToad.PdfPig;

namespace trans.tracker.lb.Services;
public class PdfManager : IPdfManager
{
    public readonly Regex _nonLetterSymbols = new Regex("[^a-zA-Zа-яА-ЯіІїЇєЄґҐ\" \"]", RegexOptions.Compiled);
    public int GetSymbolsCount(string path, bool includeSpaces = true)
    {
        using var document = PdfDocument.Open(path);
        var allText = string.Concat(document.GetPages().Select(p => p.Text));

        // Remove newlines, tabs
        allText = _nonLetterSymbols.Replace(allText, "");

        if (!includeSpaces)
            allText = allText.Replace(" ", "");

        return allText.Length;
    }
}
