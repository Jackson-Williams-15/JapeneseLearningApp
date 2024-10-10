using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JapaneseLearning.Models;
public class PartOfSpeech
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Automatically increments the Id
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]  // Part of speech name (e.g., "Past Tense Verbs")
    public required string Name { get; set; }

    public string? Description { get; set; }  // Optional, to describe the part of speech

    public ICollection<ExampleSentences>? ExampleSentences { get; set; }

}