using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.RegularExpressions;

namespace LatinCyrillic.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            ViewData["Title"] = "Home Page";
            return View(ViewData["Title"]);
        }

        [HttpPost]
        public IActionResult Index(string inputText)
        {

            if (string.IsNullOrWhiteSpace(inputText))
            {
                ModelState.AddModelError("", "Matn kiritilmadi");
                return View();
            }
            string outputText = ConvertToLatinOrCryllic(inputText);
            ViewBag.Result = outputText;

            return View();
        }

        private string ConvertToLatinOrCryllic(string inputText)
        {
            StringBuilder outputTextBuilder = new StringBuilder();
            Regex cyrillicRegex = new Regex(@"[А-Яа-яЁё]");
            Regex latinRegex = new Regex(@"[A-Za-z]");

            bool isCryllic = cyrillicRegex.IsMatch(inputText);
            bool isLatin = latinRegex.IsMatch(inputText);
            if (!isCryllic && !isLatin)
            {
                return inputText;
            }


            if (isCryllic)
            {
                var cryllic = new Dictionary<char, string>(){
    {'a', "A"},
    {'б', "b"},
    {'в', "v"},
    {'г', "g"},
    {'ғ', "g'"},
    {'д', "d"},
    {'е', "e"},
    {'ё', "yo"},
    {'ж', "j"},
    {'з', "z"},
    {'и', "i"},
    {'й', "y"},
    {'к', "k"},
    {'қ', "q"},
    {'л', "l"},
    {'м', "m"},
    {'н', "n"},
    {'ң', "n'"},
    {'о', "o"},
    {'ө', "o'"},
    {'п', "p"},
    {'р', "r"},
    {'с', "s"},
    {'т', "t"},
    {'у', "u"},
    {'ұ', "u'"},
    {'ү', "u'"},
    {'ф', "f"},
    {'х', "x"},
    {'һ', "h"},
    {'ц', "ts"},
    {'ч', "ch"},
    {'ш', "sh"},
    {'щ', "shch"},
    {'ъ', ""},
    {'ы', "y"},
    {'і', "i"},
    {'ь', ""},
    {'э', "e"},
    {'ю', "yu"},
    {'я', "ya"}
};
                foreach (var item in inputText)
                {
                    if (cryllic.ContainsKey(item))
                    {
                        outputTextBuilder.Append(cryllic[item]);
                    }
                    else
                    {
                        outputTextBuilder.Append(item);
                    }
                }

            }
            if (isLatin)
            {
                var latin = new Dictionary<char, string>()
                {

                {'A', "А"}, {'B', "Б"}, {'C', "Ц"}, {'D', "Д"}, {'E', "Е"}, {'F', "Ф"},
                {'G', "Г"}, {'H', "Ҳ"}, {'I', "И"}, {'J', "Ж"}, {'K', "К"}, {'L', "Л"},
                {'M', "М"}, {'N', "Н"}, {'O', "О"}, {'P', "П"}, {'Q', "Қ"}, {'R', "Р"},
                {'S', "С"}, {'T', "Т"}, {'U', "У"}, {'V', "В"}, {'W', "Ў"}, {'X', "Х"},
                {'Y', "Й"}, {'Z', "З"}, {'a', "а"}, {'b', "б"}, {'c', "ц"}, {'d', "д"},
                {'e', "е"}, {'f', "ф"}, {'g', "г"}, {'h', "ҳ"}, {'i', "и"}, {'j', "ж"},
                {'k', "к"}, {'l', "л"}, {'m', "м"}, {'n', "н"}, {'o', "о"}, {'p', "п"},
                {'q', "қ"}, {'r', "р"}, {'s', "с"}, {'t', "т"}, {'u', "у"}, {'v', "в"},
                {'w', "ў"}, {'x', "х"}, {'y', "й"}, {'z', "з"}

                };

                foreach(var item in inputText)
                {
                    if (latin.ContainsKey(item))
                    {
                        outputTextBuilder.Append(latin[item]);
                    }
                    else
                    {
                        outputTextBuilder.Append(item);
                    }
                }
            }

            return outputTextBuilder.ToString();
        }

    }
}

