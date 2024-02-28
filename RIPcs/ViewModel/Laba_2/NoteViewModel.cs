using CommunityToolkit.Mvvm.Input;
using RIPcs.Model;

namespace RIPcs.ViewModel.Laba_2
{
    internal partial class NoteViewModel : BaseViewModel, IQueryAttributable
    {
        private Note _note { get; set; }

        public string Text
        {
            get => _note.Text;
            set
            {
                if (_note.Text != value)
                {
                    _note.Text = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date => _note.Date;
        public string Identifier => _note.Filename;
        public NoteViewModel() => _note = new Note();
        public NoteViewModel(Note? note)
        {
            _note = note==null? new Note():note;
        }

        [RelayCommand]
        private async Task Save()
        {
            _note.Date = DateTime.Now;
            _note.Save();
            await Shell.Current.GoToAsync($"..?saved={_note.Filename}");
        }

        [RelayCommand]
        private async Task Delete()
        {
            _note.Delete();
            await Shell.Current.GoToAsync($"..?deleted={_note.Filename}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                _note = Note.Load(query["load"].ToString());
                RefreshProperties();
            }
        }

        public void Reload()
        {
            _note = Note.Load(_note.Filename);
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged(nameof(Text));
            OnPropertyChanged(nameof(Date));
        }
    }
}
