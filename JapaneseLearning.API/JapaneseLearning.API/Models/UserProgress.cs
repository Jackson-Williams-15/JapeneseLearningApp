using System;
using System.Collections.Generic;
// link to lessons later
namespace JapaneseLearning.Models {
    
    public class UserProgress {
    public int Id {get; set;}
    public int UserId {get; set;}
    public int LessonId {get; set;}
     public DateTime CompletedAt { get; set;
    }
}
}