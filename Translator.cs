using System.Collections;
using System.Collections.Generic;

namespace prove_06
{
    public static class DictionaryExtensionMethods
    {
        public static string AsString(this IEnumerable dictionary)
        {
            return "<Dictionary>{" + string.Join(", ", (Dictionary<string, string>)dictionary) + "}";
        }
    }

    public class Translator
    {
        private Dictionary<string, string> _words = new Dictionary<string, string>();

        /// <summary>
        /// Add the translation from 'fromWord' to 'toWord'
        /// For example, in an English to German dictionary:
        /// 
        /// myTranslator.AddWord("book","buch")
        /// </summary>
        /// <param name="fromWord">The word to translate from</param>
        /// <param name="toWord">The word to translate to</param>
        public void AddWord(string fromWord, string toWord)
        {
            _words[fromWord] = toWord;
        }

        /// <summary>
        /// Translates the from word into the word that this stores as the translation
        /// </summary>
        /// <param name="fromWord">The word to translate</param>
        /// <returns>The translated word or "???" if no translation is available</returns>
        public string Translate(string fromWord)
        {
            return _words.TryGetValue(fromWord, out var translation) ? translation : "???";
        }
    }
}
