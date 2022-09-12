namespace KidsFair
{
    internal class Album
    {
        private String albumName;
        private String artistName;
        private int numOfTracks;
        public void start()
        {
            Console.WriteLine("THE ALBUM PROGRAM!");
            Console.WriteLine("----------------\n");
            ReadAndSaveAlbumData();
            DisplayAlbumData();
        }

        private void ReadAndSaveAlbumData()
        {
            Console.Write("What is the name of your favourite music album? ");
            albumName = Console.ReadLine();
            Console.Write($"What is the name of the artist or band for {albumName}? ");
            artistName = Console.ReadLine();
            Console.Write($"How many tracks does {albumName} have? ");
            numOfTracks = Convert.ToInt32(Console.ReadLine());
        }

        private void DisplayAlbumData()
        {
            Console.WriteLine($"\nAlbum name: {albumName}");
            Console.WriteLine($"Artist/band: {artistName}");
            Console.WriteLine($"Number of tracks: {numOfTracks}");
            Console.WriteLine("Enjoy listening!");
        }
    }
}
