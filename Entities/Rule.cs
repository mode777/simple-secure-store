using System;
using System.ComponentModel.DataAnnotations;

public class Rule
{
    [Key]
    public Guid Id { get; set; }
    public string ClaimType { get; set; }
    public RuleOperator Operator { get; set; }
    public string Value { get; set; }

    public RuleSet RuleSet { get; set; }
}