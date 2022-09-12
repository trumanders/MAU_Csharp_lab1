namespace KidsFair
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Pet pet = new Pet();
            pet.start();
           
            TicketSeller ts = new TicketSeller();
            ts.start();        
            
            Album album = new Album();
            album.start();
        }
    }
}