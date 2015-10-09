using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApplication.Common;
using WpfApplication.Models;

namespace WpfApplication.ViewModels
{
    public class AlbumViewModel
    {
        private SongDatabase database;
        private ObservableCollection<SongViewModel> songs;

        public AlbumViewModel()
        {
            this.database = new SongDatabase();
            this.songs = new ObservableCollection<SongViewModel>();
        }

        public ObservableCollection<SongViewModel> Songs
        {
            get
            {
                return this.songs;
            }
            set
            {
                this.songs = value;
            }
        }

        // commands
        public ICommand CommandAddSongFromDatabase
        {
            get
            {
                return new RelayCommand (
                    param =>
                    {
                        String[] record = this.database.GetRecord();
                        Song song = new Song { ArtistName = record[0], SongTitle = record[1] };
                        this.songs.Add(new SongViewModel() { Song = song });
                    },
                    param => { return this.songs.Count <= 9; }
                );
            }
        }

        public ICommand CommandAddSongManually
        {
            get
            {
                return new RelayCommand(
                    param =>
                    {
                        String[] record = new String[2]
                        {
                            (String)((Object[])param)[0],
                            (String)((Object[])param)[1]
                        };
                        if (String.IsNullOrEmpty (record[0]) || String.IsNullOrEmpty (record[1]))
                            return;

                        Song song = new Song { ArtistName = record[0], SongTitle = record[1] };
                        this.songs.Add(new SongViewModel() { Song = song });
                    },
                    param => { return this.songs.Count <= 9; }
                );
            }
        }

        public ICommand CommandRemoveSong
        {
            get
            {
                return new RelayCommand(
                    param =>
                    {
                        int index = Int32.Parse(param.ToString()) - 1;
                        if (index >= this.songs.Count)
                            return;

                        this.songs.RemoveAt(index);
                    },
                    param => { return this.songs.Count > 0; }
                );
            }
        }

        public ICommand CommandRemoveAllSongs
        {
            get
            {
                return new RelayCommand(
                    param => { this.songs.Clear(); },
                    param => { return this.songs.Count > 0; }
                );
            }
        }
    }
}
