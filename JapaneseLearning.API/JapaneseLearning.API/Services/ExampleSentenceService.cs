using JapaneseLearning.Interfaces;
using JapaneseLearning.Models;
using JapaneseLearning.Helpers;
namespace JapaneseLearning.Services;

public class ExampleSentenceService : IExampleSentenceService
{
    private readonly LearningAppContext _context;
    private readonly HttpClient _httpClient;

    public ExampleSentenceService(LearningAppContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public async Task<List<ExampleSentences>?> GetSentences(int vocabId)
    {
        // Check if example sentences are cached and not older than 24 hours
        var sentences = _context.ExampleSentences
            .Where(s => s.VocabularyId == vocabId && s.LastFetched > DateTime.Now.AddDays(-1))
            .ToList();

        // If found and valid, return cached sentences
        if (sentences.Count > 0)
        {
            return sentences;
        }

        // Otherwise, fetch from external API (e.g., Tatoeba)
        var externalSentences = await FetchFromTatoebaAPI(vocabId);

        if (externalSentences != null)
        {
            // Add or update the sentences in the cache (database)
            foreach (var sentence in externalSentences)
            {
                sentence.VocabularyId = vocabId;
                sentence.LastFetched = DateTime.Now;

                // Add new sentence if not found in the cache
                if (!_context.ExampleSentences.Any(s => s.Id == sentence.Id))
                {
                    _context.ExampleSentences.Add(sentence);
                }
            }

            await _context.SaveChangesAsync();
            return externalSentences;
        }

        return null;  // Return null if no data is found
    }

    // Private method to fetch example sentences from Tatoeba API
    private async Task<List<ExampleSentences>?> FetchFromTatoebaAPI(int vocabId)
    {
        // Assuming we have a method to map vocabulary ID to its word
        var vocabWord = _context.Vocabulary.FirstOrDefault(v => v.Id == vocabId)?.Word;

        if (string.IsNullOrEmpty(vocabWord))
        {
            return null;
        }

        var response = await _httpClient.GetAsync($"https://tatoeba.org/eng/api_v0/search?query={vocabWord}&from=jpn&to=eng");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var tatoebaData = await response.Content.ReadFromJsonAsync<TatoebaResponse>();  // Assuming you have a TatoebaResponse class

        // Map the API response to a list of ExampleSentence objects
        if (tatoebaData == null || tatoebaData.results == null)
        {
            return null;
        }

        var sentences = tatoebaData.results.Select(result => new ExampleSentences
        {
            Sentence = result.text,
            Translation = result.translations[0].text,
            Source = "Tatoeba",
            LastFetched = DateTime.Now,
            Vocabulary = _context.Vocabulary.FirstOrDefault(v => v.Id == vocabId) ?? new VocabWords { Word = vocabWord }  // Set the Vocabulary property
        }).ToList();

        return sentences;
    }

    Task<List<ExampleSentences>> IExampleSentenceService.GetSentences(int vocabId)
    {
        throw new NotImplementedException();
    }
}
