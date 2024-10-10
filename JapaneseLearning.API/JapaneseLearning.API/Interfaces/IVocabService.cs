using JapaneseLearning.Controllers;
using JapaneseLearning.Models;
namespace JapaneseLearning.Interfaces;

public interface IVocabService {
    Task<VocabWords?> GetVocabWords(string word);
    Task<bool> AddVocabulary(VocabWords newVocab);
}