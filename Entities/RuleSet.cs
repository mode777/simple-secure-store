using System;
using System.Collections.Generic;

namespace SimpleSecureStore
{
    public class RuleSet
    {
        public Guid Id { get; set; }
        public AccessType AccessType { get; set; }
        public Set Set { get; set; }
        public ICollection<Rule> Rules { get; set; }
    }
}
