using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{

    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// indicates whether the empty string is stored in the 
        /// trie rooted at this node
        /// </summary>
        private bool _isEmpty = false;
        /// <summary>
        /// adds string to trie
        /// </summary>
        /// <param name="s"></param>string to be added
        /// <returns></returns>ITrie with new string
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _isEmpty = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _isEmpty);
            }
        }
        /// <summary>
        /// checks to see if trie contains s
        /// </summary>
        /// <param name="s"></param>string we are looking for
        /// <returns></returns> returns true or false
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _isEmpty;
            }
            else
            {
                return false;
            }
        }
    }
}
