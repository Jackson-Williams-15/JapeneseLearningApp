namespace JapaneseLearning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class VocabWords {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id{get; set;}
    
    [Required]
    [MaxLength(255)]
    public required string Word{get; set;}

    [MaxLength(255)]
    public string? Reading {get; set;}
    public string? Meaning {get; set;}

    [MaxLength(255)]
    public string? Romaji {get; set;}

    [MaxLength(255)]
    public string? Source{get; set;}
    
    public DateTime LastFetched { get; set; } = DateTime.Now;
    
    
    }