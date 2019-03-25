/*
 *Agustin Rodriguez
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// field to check whether the trie contains the 
        /// empty string
        /// </summary>
        private bool _contains;

        /// <summary>
        /// the only child
        /// </summary>
        private ITrie _onlyChild;

        /// <summary>
        /// gives us child's label
        /// </summary>
        private char _childLabel;

        /// <summary>
        /// constructor for class
        /// </summary>
        /// <param name="s"></param> string we are adding
        /// <param name="b"></param>boolean whether trie contains the string
        public TrieWithOneChild(string s, bool b)
        {
            if (s == "" || (s[0] < 'a' || s[0] > 'z'))
            {
                throw new ArgumentException();
            }
            _contains = b;
            _childLabel = s[0];
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1)); 
            
        }
        /// <summary>
        /// adds a string to trie
        /// </summary>
        /// <param name="s"></param> string we want to add
        /// <returns></returns> returns itrie with string
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _contains = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();

            }
            else if (s[0] == _childLabel)
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _contains, _childLabel, _onlyChild);
            }
            
           
        }
        /// <summary>
        /// checks to see if trie contains the string
        /// </summary>
        /// <param name="s"></param>string we are looking for
        /// <returns></returns> returns bool if true or not
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _contains;
            }
            if (s[0] == _childLabel)
            {
                return _onlyChild.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
