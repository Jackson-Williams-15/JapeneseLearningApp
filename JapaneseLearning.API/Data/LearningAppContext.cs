using JapaneseLearning.Models;
using Microsoft.EntityFrameworkCore;

public class LearningAppContext : DbContext
{
    public LearningAppContext(DbContextOptions<LearningAppContext> options) : base(options) { }

    public DbSet<VocabWords> Vocabulary { get; set; } = null!;
    public DbSet<ExampleSentences> ExampleSentences { get; set; }= null!;
    public DbSet<PartOfSpeech> PartsOfSpeech { get; set; }= null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<PartOfSpeech>()
            .HasMany(ps => ps.ExampleSentences)
            .WithOne(es => es.PartOfSpeech)
            .HasForeignKey(es => es.PartOfSpeechId);
    }
}
