using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notepad.Models;
using Notepad.Repositories;
using Notepad.Test.Repositories;
using Notepad.ViewModels;
using System;

namespace Notepad.Test.ViewModels
{
    [TestClass]
    public class MainPageViewModelTest
    {
        private readonly NoteRepositoryMock noteRepository;
        private readonly MainPageViewModel viewModel;

        public MainPageViewModelTest()
        {
            this.noteRepository = new NoteRepositoryMock();
            this.viewModel = new MainPageViewModel(this.noteRepository);
        }

        [TestMethod]
        public void SetContent_HasChagedTrue()
        {
            // Arrange
            viewModel.HasChanged = false;

            // Act
            viewModel.Content = "new content";

            // Assert
            Assert.IsTrue(viewModel.HasChanged);
        }

        [TestMethod]
        public void SaveCommand_SavesContent()
        {
            // Arrange
            viewModel.Content = "save this text";

            // Act
            viewModel.SaveCommand.Execute(null);

            // Assert
            Assert.AreEqual("save this text", this.noteRepository.SaveNote_param_content);
        }

        [TestMethod]
        public void LoadCommand_LoadsContent()
        {
            // Arrange
            var date = DateTime.Now;
            var note = new Note();
            note.Content = "new note";
            note.LastSaved = date;

            noteRepository.LoadNote_result = note;

            // Act
            viewModel.LoadCommand.Execute(null);

            // Assert
            Assert.AreEqual("new note", viewModel.Content);
            Assert.AreEqual(date.ToString("MM/dd/yyyy hh:mm:ss"), viewModel.LastSaved);
        }

        [TestMethod]
        public void LoadCommand_LoadEmpty_WhenNoteIsNull()
        {
            // Arrange
            noteRepository.LoadNote_result = null;

            // Act
            viewModel.LoadCommand.Execute(null);

            // Assert
            Assert.AreEqual(string.Empty, viewModel.Content);
            Assert.AreEqual(string.Empty, viewModel.LastSaved);
        }

        [TestMethod]
        public void LoadCommand_HasChangedFalse()
        {
            // Arrange
            viewModel.HasChanged = true;
            var note = new Note();
            note.Content = "new note";
            note.LastSaved = DateTime.Now;

            noteRepository.LoadNote_result = note;

            // Act
            viewModel.LoadCommand.Execute(null);

            // Assert
            Assert.IsFalse(viewModel.HasChanged);
        }
    }
}
