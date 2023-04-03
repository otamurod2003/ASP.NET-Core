namespace LatinCyrillic.Models
{
    public interface ILatinCryllicService
    {
       Dictionary<char, string> TranslateToCryllic(string text);
      Dictionary<char, string> TranslateToLatin(string text);
    }
}
