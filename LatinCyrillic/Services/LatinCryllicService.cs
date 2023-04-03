using LatinCyrillic.Models;

namespace LatinCyrillic.Services
{
    public class LatinCryllicService : ILatinCryllicService
    {
        public LatinCryllicService()
        {
            var Latin = new Dictionary<char, char>()
            {
                {'a', 'а'},{'b', 'б'},{'d', 'д'},{'e', 'е'},{'f', 'ф'}, {'g', 'г'},
    {'h', 'ҳ'},
    {'i', 'и'},
    {'j', 'ж'},
    {'k', 'к'},
    {'l', 'л'},
    {'m', 'м'},
    {'n', 'н'},
    {'o', 'о'},
    {'p', 'п'},
    {'q', 'қ'},
    {'r', 'р'},
    {'s', 'с'},
    {'t', 'т'},
    {'u', 'у'},
    {'v', 'в'},
    {'x', 'х'},
    {'y', 'й'},
    {'z', 'з'},
    {'A', 'А'},
    {'B', 'Б'},
    {'D', 'Д'},
    {'E', 'Е'},
    {'F', 'Ф'},
    {'G', 'Г'},
    {'H', 'Ҳ'},
    {'I', 'И'},
    {'J', 'Ж'},
    {'K', 'К'},
    {'L', 'Л'},
    {'M', 'М'},
    {'N', 'Н'},
    {'O', 'О'},
    {'P', 'П'},
    {'Q', 'Қ'},
    {'R', 'Р'},
    {'S', 'С'},
    {'T', 'Т'},
    {'U', 'У'},
    {'V', 'В'},
    {'X', 'Х'},
    {'Y', 'Й'},
    {'Z', 'З'},

            };
            var Cryllic = new Dictionary<char, string>()
            {

            };
        }

        Dictionary<char, char> ILatinCryllicService.TranslateToCryllic(string result)
        {
            throw new NotImplementedException();
        }

        Dictionary<char, char> ILatinCryllicService.TranslateToLatin(string result)
        {
            throw new NotImplementedException();
        }
    }
}
