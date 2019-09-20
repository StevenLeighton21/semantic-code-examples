namespace PoetryForMachines.ValueTypes
{
    public class BowlingGameStatus
    {
        public BowlingGameStatus()
        {
            Status = "Not started";
        }
        
        public string Status { get; set; }
    }
}