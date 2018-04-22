using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SimpleSecureStore
{
    public class Item
    {
        private string _payloadString;
        public string Key { get; set; }
        public string SetKey { get; set; }
        public JObject Data
        {
            get => JObject.Parse(_payloadString);
            set => _payloadString = value.ToString();
        }

        public ICollection<ItemClaim> Claims { get; set; }
    }
}