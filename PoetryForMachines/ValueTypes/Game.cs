namespace PoetryForMachines.ValueTypes
{
    public class Game
    {
        public Game()
        {
            Status = "Not started";
        }
        
        public string Status { get; set; }
    }
}