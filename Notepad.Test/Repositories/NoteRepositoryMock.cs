using Notepad.Models;
using Notepad.Repositories;

namespace Notepad.Test.Repositories
{
    public class NoteRepositoryMock : INoteRepository
    {
        public string SaveNote_param_content { get; private set; }
        public Note LoadNote_result { get; set; }

        public void SaveNote(string content)
        {
            SaveNote_param_content = content;
        }

        public Note LoadNote()
        {
            return LoadNote_result;
        }
    }
}
