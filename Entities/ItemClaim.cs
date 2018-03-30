using System;
using System.ComponentModel.DataAnnotations;

public class ItemClaim
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string ClaimType { get; set; }
    public string Value { get; set; }
    public Item Item { get; set; }
}