using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Models
{
    public class Song
    {
        private String artistName;
        private String songTitle;

        public String ArtistName
        {
            get { return this.artistName; }
            set { this.artistName = value; }
        }

        public String SongTitle
        {
            get { return this.songTitle; }
            set { this.songTitle = value; }
        }
    }
}
