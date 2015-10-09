using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication.ViewModels;

namespace Wpf_MVVM_03_SongsAndAlbums
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }


        private void Button_Click(Object sender, RoutedEventArgs e)
        {
            AlbumViewModel viewModel = (AlbumViewModel)base.DataContext;

            if (sender == this.ButtonTestAddSong)
            {
                ICommand cmdAddSong =
                    viewModel.CommandAddSongFromDatabase;

                if (cmdAddSong.CanExecute(null))
                    cmdAddSong.Execute(null);
            }
            else if (sender == this.ButtonTestUpdateArtist)
            {
                int numberOfSongs = viewModel.Songs.Count;
                if (numberOfSongs == 0)
                    return;

                int randomIndex = (new Random()).Next() % numberOfSongs;
                SongViewModel songViewModel = viewModel.Songs[randomIndex];

                ICommand cmdUpdateSongTitle =
                    songViewModel.CommandUpdateSongTitle;

                if (cmdUpdateSongTitle.CanExecute(null))
                    cmdUpdateSongTitle.Execute(null);
            }
        }

        private void ListView_SelectionChanged(
            Object sender, SelectionChangedEventArgs e)
        {
            SongViewModel songViewModel =
                (SongViewModel)this.ListViewSongs.SelectedItem;

            if (songViewModel != null)
            {
                ICommand cmd = songViewModel.CommandUpdateSongTitle;
                if (cmd.CanExecute(null))
                    cmd.Execute(null);
            }
        }
    }
}
