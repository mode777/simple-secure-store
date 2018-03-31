using System.Collections.Generic;

namespace SimpleSecureStore
{
    public class Item
    {
        public string Key { get; set; }
        public string SetKey { get; set; }
        public string Data { get; set; }
        public ICollection<ItemClaim> Claims { get; set; }
    }
}