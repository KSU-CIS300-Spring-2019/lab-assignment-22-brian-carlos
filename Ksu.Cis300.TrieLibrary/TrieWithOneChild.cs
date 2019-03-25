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
        /// Whether or not trie contains empty string
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// The only child
        /// </summary>
        private ITrie _onlyChild;
      
        /// <summary>
        /// The child's label
        /// </summary>
        private char _label;

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else if (s != "" && s[0] == _label)
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _label, _onlyChild);
            }
            return this;
        }

        /// <summary>
        /// Gets whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                if (s[0] == _label)
                {
                    return _onlyChild.Contains(s.Substring(1));
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hasEmpty"></param>
        /// <param name="childLabel"></param>
        /// <param name="child"></param>
        public TrieWithOneChild(string s, bool hasEmpty)
        {
            
            if (s == "" || !(s[0] >= 'a' && s[0] <= 'z'))
            {
                throw new ArgumentException();
            }
            _hasEmptyString = hasEmpty;
            _label = s[0];

            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1));
            
        }
    }
}
