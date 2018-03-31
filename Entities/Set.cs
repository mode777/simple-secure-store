using System.Collections.Generic;

namespace SimpleSecureStore
{
    public class Set
    {
        public string Key { get; set; }    
        public ICollection<RuleSet> RuleSets { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}