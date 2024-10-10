using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JapaneseLearning.Interfaces;

namespace JapaneseLearning.Controllers;

[ApiController]
    [Route("api/[controller]")]
    public class VocabularyController : ControllerBase
    {
        private readonly IVocabService _vocabularyService;

        // Inject the IVocabularyService using dependency injection
        public VocabularyController(IVocabService vocabularyService)
        {
            _vocabularyService = vocabularyService;
        }

        // GET: api/vocabulary/{word}
        // Fetch a single vocabulary word by its Japanese form (kanji/kana)
        [HttpGet("{word}")]
        public async Task<IActionResult> GetVocabulary(string word)
        {
            // Call the service to get the vocabulary word
            var vocab = await _vocabularyService.GetVocabWords(word);

            if (vocab == null)
            {
                return NotFound(new { Message = $"Vocabulary word '{word}' not found." });
            }

            return Ok(vocab);
        }

        // POST: api/vocabulary
        [HttpPost]
        public async Task<IActionResult> AddVocabulary([FromBody] Models.VocabWords newVocab)
        {
            // Validate the input
            if (newVocab == null || string.IsNullOrWhiteSpace(newVocab.Word))
            {
                return BadRequest(new { Message = "Invalid vocabulary word." });
            }

            // Add the vocabulary word to the database
            var result = await _vocabularyService.AddVocabulary(newVocab);

            if (!result)
            {
                return StatusCode(500, new { Message = "An error occurred while adding the vocabulary word." });
            }

            return Ok(new { Message = "Vocabulary word added successfully!" });
        }
    }