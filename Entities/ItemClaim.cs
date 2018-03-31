using System;

namespace SimpleSecureStore
{
    public class ItemClaim
    {
        public Guid Id { get; set; }
        public string ClaimType { get; set; }
        public string Value { get; set; }
    }
}