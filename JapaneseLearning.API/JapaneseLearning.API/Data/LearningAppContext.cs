using JapaneseLearning.Models;
using Microsoft.EntityFrameworkCore;
namespace JapaneseLearning.Data;
public class LearningAppContext : DbContext
{
    public LearningAppContext(DbContextOptions<LearningAppContext> options) : base(options) { }

    public DbSet<VocabWords> Vocabulary { get; set; } = null!;
    public DbSet<ExampleSentences> ExampleSentences { get; set; }= null!;
    public DbSet<PartOfSpeech> PartsOfSpeech { get; set; }= null!;
    public DbSet<Users> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Make sure the username is unique
        modelBuilder.Entity<Users>()
            .HasIndex(u => u.Username)
            .IsUnique();

        // Make sure the email is unique
        modelBuilder.Entity<Users>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<PartOfSpeech>()
            .HasMany(ps => ps.ExampleSentences)
            .WithOne(es => es.PartOfSpeech)
            .HasForeignKey(es => es.PartOfSpeechId);
    }
}
