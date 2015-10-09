using System;
using System.ComponentModel;
using System.Windows.Input;
using WpfApplication.Common;
using WpfApplication.Models;

namespace WpfApplication.ViewModels
{
    public class SongViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Song song;
        
        public SongViewModel()
        {
            this.song = new Song ()
            {
                ArtistName = "Unknown",
                SongTitle = "Unknown"
            };
        }

        public Song Song
        {
            set { this.song = value; }
            get { return this.song; }
        }

        public String ArtistName
        {
            set
            {
                if (this.Song.ArtistName != value)
                {
                    this.Song.ArtistName = value;
                    this.RaisePropertyChanged("ArtistName");
                }
            }
            get { return this.Song.ArtistName; }
        }

        public String SongTitle
        {
            set
            {
                if (this.Song.SongTitle != value)
                {
                    this.Song.SongTitle = value;
                    this.RaisePropertyChanged("SongTitle");
                }
            }
            get { return this.Song.SongTitle; }
        }

        private void RaisePropertyChanged(String propertyName)
        {
            // using a copy to prevent thread issues ...
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // commands
        public ICommand CommandUpdateSongTitle
        {
            get
            {
                return new RelayCommand (
                    param =>
                    {
                        String songTitle = this.SongTitle;

                        if (songTitle.Contains(" ["))
                        {
                            int delimiter = songTitle.IndexOf(" [");
                            songTitle = songTitle.Substring(0, delimiter);
                        }

                        String newSongTitle = String.Format("{0} [{1}]",
                            songTitle, DateTime.Now.TimeOfDay);

                        this.SongTitle = newSongTitle;
                    },
                    param => { return true; }
                );
            }
        }
    }
}

