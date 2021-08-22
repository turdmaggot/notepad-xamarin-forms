using Notepad.Models;
using System;

namespace Notepad.Repositories
{
    public class InMemoryNoteRepository : INoteRepository
    {
        private string content;
        private DateTime lastSaved;

        public Note LoadNote()
        {
            return new Note()
            {
                Content = content,
                LastSaved = lastSaved
            };
        }

        public void SaveNote(string content)
        {
            this.content = content;
            this.lastSaved = DateTime.Now;
        }
    }
}
