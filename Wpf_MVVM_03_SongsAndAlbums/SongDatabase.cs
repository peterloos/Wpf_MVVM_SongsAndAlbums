using System;

namespace WpfApplication.ViewModels
{
    public class SongDatabase
    {
        private int index;

        public SongDatabase()
        {
            this.index = 0;
        }

        private String[] artists = {
            "Marcin Wasilewski", 
            "Gwilym Simcock",
            "Alan Pasqua", 	
            "George Duke", 	
            "Brad Mehldau", 		
            "Joshua Redman", 	
            "Antonio Farao"
        };

        private String[] songTitles = {
            "Three Reflections", 
            "Affinity", 
            "My New Old Friend", 
            "You Never Know", 
            "Song-Song", 
            "Faith", 
            "Dormi"
        };

        public String[] GetRecord()
        {
            String[] nextSong = new String[]
            {
                this.artists[this.index],
                this.songTitles[this.index]
            };

            this.index++;
            if (this.index == this.artists.Length)
                this.index = 0;

            return nextSong;
        }
    }
}
