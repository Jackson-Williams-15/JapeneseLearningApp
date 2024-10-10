using System.Collections.Generic;
using System.Text;

namespace JapaneseLearning.Helpers
{
    public static class KanaToRomajiConverter
    {
        // Hiragana to Romaji map (you can expand this list with more entries)
        private static readonly Dictionary<string, string> HiraganaToRomajiMap = new Dictionary<string, string>
        {
            { "あ", "a" }, { "い", "i" }, { "う", "u" }, { "え", "e" }, { "お", "o" },
            { "か", "ka" }, { "き", "ki" }, { "く", "ku" }, { "け", "ke" }, { "こ", "ko" },
            { "さ", "sa" }, { "し", "shi" }, { "す", "su" }, { "せ", "se" }, { "そ", "so" },
            { "た", "ta" }, { "ち", "chi" }, { "つ", "tsu" }, { "て", "te" }, { "と", "to" },
            { "な", "na" }, { "に", "ni" }, { "ぬ", "nu" }, { "ね", "ne" }, { "の", "no" },
            { "は", "ha" }, { "ひ", "hi" }, { "ふ", "fu" }, { "へ", "he" }, { "ほ", "ho" },
            { "ま", "ma" }, { "み", "mi" }, { "む", "mu" }, { "め", "me" }, { "も", "mo" },
            { "や", "ya" }, { "ゆ", "yu" }, { "よ", "yo" },
            { "ら", "ra" }, { "り", "ri" }, { "る", "ru" }, { "れ", "re" }, { "ろ", "ro" },
            { "わ", "wa" }, { "を", "wo" }, { "ん", "n" },
            { "が", "ga" }, { "ぎ", "gi" }, { "ぐ", "gu" }, { "げ", "ge" }, { "ご", "go" },
            { "ざ", "za" }, { "じ", "ji" }, { "ず", "zu" }, { "ぜ", "ze" }, { "ぞ", "zo" },
            { "だ", "da" }, { "ぢ", "ji" }, { "づ", "zu" }, { "で", "de" }, { "ど", "do" },
            { "ば", "ba" }, { "び", "bi" }, { "ぶ", "bu" }, { "べ", "be" }, { "ぼ", "bo" },
            { "ぱ", "pa" }, { "ぴ", "pi" }, { "ぷ", "pu" }, { "ぺ", "pe" }, { "ぽ", "po" }
            // Add Katakana or more Hiragana characters later
        };

        // Convert Kana (Hiragana or Katakana) to Romaji
        public static string ConvertKanaToRomaji(string kana)
        {
            var romaji = new StringBuilder();

            foreach (char kanaChar in kana)
            {
                var kanaStr = kanaChar.ToString();

                // If the kana character exists in the map, convert it to Romaji
                if (HiraganaToRomajiMap.ContainsKey(kanaStr))
                {
                    romaji.Append(HiraganaToRomajiMap[kanaStr]);
                }
                else
                {
                    // If no match, keep the original character (this handles punctuation, kanji, etc.)
                    romaji.Append(kanaStr);
                }
            }

            return romaji.ToString();
        }
    }
}