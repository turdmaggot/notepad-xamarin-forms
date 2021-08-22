using Notepad.Models;

namespace Notepad.Repositories
{
    public interface INoteRepository
    {
        void SaveNote(string content);
        Note LoadNote();
    }
}
