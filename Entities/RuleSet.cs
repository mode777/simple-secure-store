using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class RuleSet
{
    [Key]
    public Guid Id { get; set; }
    public AccessType AccessType { get; set; }
    public Set Set { get; set; }
    public ICollection<Rule> Rules { get; set; }
}