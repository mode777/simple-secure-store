using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Item
{
    [Key]
    public string Key { get; set; }
    public string Data { get; set; }
    public ICollection<ItemClaim> Claims { get; set; }
}