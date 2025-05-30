using JapaneseLearning.Interfaces;
using JapaneseLearning.Models;
using JapaneseLearning.Helpers;
using JapaneseLearning.Data;
namespace JapaneseLearning.Services
{
    public class VocabService : IVocabService
    {
        private readonly LearningAppContext _context;
        private readonly HttpClient _httpClient;

        public VocabService(LearningAppContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        // Method to add a vocabulary word to the database
        public async Task<bool> AddVocabulary(VocabWords newVocab)
        {
            try
            {
                // Add the new word to the Vocabulary table
                _context.Vocabulary.Add(newVocab);

                // Save the changes to the database
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                // If there's an error, return false
                return false;
            }
        }

        public async Task<VocabWords?> GetVocabWords(string word)
        {
            // Check if the word is in the database cache
            var vocab = _context.Vocabulary.FirstOrDefault(v => v.Word == word);

            // If found and not outdated, return it
            if (vocab != null && vocab.LastFetched > DateTime.Now.AddDays(-1))
            {
                // Convert Kana to Romaji before returning
                if (!string.IsNullOrEmpty(vocab.Reading))
                {
                    if (!string.IsNullOrEmpty(vocab.Reading))
                    {
                        vocab.Romaji = KanaToRomajiConverter.ConvertKanaToRomaji(vocab.Reading);
                    }
                }
                return vocab;
            }

            // If not found or outdated, fetch it from the external API (e.g., Jisho API)
            var externalVocab = await FetchFromJishoAPI(word);

            if (externalVocab != null)
    {
        // Check if the word already exists in the database before adding
        var duplicateCheck = _context.Vocabulary.Any(v => v.Word == externalVocab.Word);

        if (!duplicateCheck) // Only add if it doesn't exist
        {
            // Convert Kana (Reading) to Romaji
            if (!string.IsNullOrEmpty(externalVocab.Reading))
            {
                externalVocab.Romaji = KanaToRomajiConverter.ConvertKanaToRomaji(externalVocab.Reading);
            }

            // Add new vocabulary to the database
            _context.Vocabulary.Add(externalVocab);
            Console.WriteLine("Added new vocabulary to the database");

            // Save changes to the database
            await _context.SaveChangesAsync();
            Console.WriteLine("Changes saved to the database. Now fetching...");
        }
        else
        {
            Console.WriteLine("Duplicate word detected. Skipping addition to the database.");
        }

        // Return the fetched vocabulary (whether added or not)
        return externalVocab;
    }

    // Return null if no data found
    return null;
        }

        // Method to fetch data from Jisho API
        private async Task<VocabWords?> FetchFromJishoAPI(string word)
        {
            var response = await _httpClient.GetAsync($"https://jisho.org/api/v1/search/words?keyword={word}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var jishoData = await response.Content.ReadFromJsonAsync<JishoResponse>();

            // Map API response to a Vocab object
            if (jishoData?.data == null || jishoData.data.Count == 0 || 
                jishoData.data[0].japanese == null || jishoData.data[0].japanese.Count == 0 || 
                jishoData.data[0].senses == null || jishoData.data[0].senses.Count == 0)
            {
                return null;
            }

            var vocab = new VocabWords
            {
                Word = jishoData.data[0].slug,
                Reading = jishoData.data[0].japanese[0].reading,
                Meaning = string.Join(", ", jishoData.data[0].senses[0].english_definitions),
                Source = "Jisho",
                LastFetched = DateTime.Now
            };

            return vocab;
        }
    }
}
