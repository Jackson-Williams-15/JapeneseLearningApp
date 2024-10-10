using JapaneseLearning.Models;

namespace JapaneseLearning.Services {
public interface ILessonService
{
    Lesson GetLessonById(int id);
    IEnumerable<Lesson> GetAllLessons();
    void CreateLesson(Lesson lesson);
    void UpdateLesson(int id, Lesson lesson);
    void DeleteLesson(int id);
}
}