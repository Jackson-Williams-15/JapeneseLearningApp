using JapaneseLearning.Models;
namespace JapaneseLearning.Interfaces;

public interface IExampleSentenceService
{
    Task<List<ExampleSentences>> GetSentences(int vocabId);
}