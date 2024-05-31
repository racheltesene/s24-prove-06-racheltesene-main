using System.Collections;
using System.Collections.Generic;

namespace prove_06
{
    public class Translator
    {
        private Dictionary<string, string> _translations = new Dictionary<string, string>();

        public void AddWord(string fromWord, string toWord)
        {
            _translations[fromWord.ToLower()] = toWord.ToLower();
        }

        public string Translate(string word)
        {
            if (_translations.ContainsKey(word.ToLower()))
            {
                return _translations[word.ToLower()];
            }
            else
            {
                return "???";
            }
        }
    }
}
