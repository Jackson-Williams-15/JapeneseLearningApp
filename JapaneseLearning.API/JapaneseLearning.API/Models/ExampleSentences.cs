using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JapaneseLearning.Models;
namespace JapaneseLearning.Models;
public class ExampleSentences
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Automatically increments the Id
    public int Id { get; set; }

    [Required]  // Foreign key to Vocabulary table
    public int VocabularyId { get; set; }

    [ForeignKey("VocabularyId")]
    public required VocabWords Vocabulary { get; set; }  // Navigation property to Vocabulary

    [Required]  // Foreign key to PartsOfSpeech table
    public int PartOfSpeechId { get; set; }

    [ForeignKey("PartOfSpeechId")]
    public PartOfSpeech? PartOfSpeech { get; set; }  // Navigation property to PartsOfSpeech

    [Required]
    public string? Sentence { get; set; }  // The example sentence in Japanese

    public string? Translation { get; set; }  // English translation of the sentence

    [MaxLength(255)]
    public string? Source { get; set; }  // The source, e.g., "Tatoeba"

    public DateTime LastFetched { get; set; } = DateTime.Now;  // Timestamp for caching
}