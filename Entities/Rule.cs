using System;

namespace SimpleSecureStore
{
    public class Rule
    {
        public Guid Id { get; set; }
        public string ClaimType { get; set; }
        public RuleOperator Operator { get; set; }
        public string Value { get; set; }
    }
}