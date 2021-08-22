using Notepad.Repositories;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Notepad.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly INoteRepository noteRepository;

        public ICommand SaveCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private string previousContent = string.Empty;

        private string content;
        public string Content
        {
            get => this.content;
            set
            {
                this.SetProperty(ref this.content, value ?? string.Empty);
                this.HasChanged = !string.Equals(this.previousContent, this.content);
            }
        }

        private string lastSaved;
        public string LastSaved
        {
            get => this.lastSaved;
            set => this.SetProperty(ref this.lastSaved, value);
        }

        private bool hasChanged;
        public bool HasChanged
        {
            get => this.hasChanged;
            set => this.SetProperty(ref this.hasChanged, value);
        }

        public MainPageViewModel(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
            SaveCommand = new Command(Save);
            LoadCommand = new Command(Load);
        }

        private void Save(object args)
        {
            this.noteRepository.SaveNote(this.content);
        }

        private void Load(object obj)
        {
            var note = this.noteRepository.LoadNote();
            this.previousContent = note?.Content ?? string.Empty;
            this.Content = note?.Content ?? string.Empty;
            this.LastSaved = note?.LastSaved.ToString("MM/dd/yyyy hh:mm:ss") ?? string.Empty;
        }

        protected void SetProperty<T>(ref T obj, T value, [CallerMemberName] string memberName = null)
        {
            obj = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
