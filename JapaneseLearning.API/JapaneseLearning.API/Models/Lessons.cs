using System;
using System.Collections.Generic;

namespace JapaneseLearning.Models {

    public class Lesson { 
        public int Id { get; set; }
        public int LessonId { get; set; }
        public ICollection<string> VocabWords { get; set; }
        public ICollection<string> GrammarPractice { get; set; }
        public ICollection<string> Hirigana { get; set; }
        public ICollection<string> Katakana { get; set; }
        public ICollection<string> Kanji { get; set; }

        // Track user input and progress
        public ICollection<string> UserVocabAnswers { get; set; }
        public ICollection<bool> VocabAnswersCorrect { get; set; }
        public ICollection<string> UserGrammarAnswers { get; set; }
        public ICollection<bool> GrammarAnswersCorrect { get; set; }
    }

    }
