using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Set
{
    [Key]
    public string Key { get; set; }    
    public ICollection<RuleSet> RuleSets { get; set; }
    public ICollection<Item> Items { get; set; }
}