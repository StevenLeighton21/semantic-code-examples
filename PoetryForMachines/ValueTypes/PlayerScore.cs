namespace PoetryForMachines.ValueTypes
{
    public class PlayerScore
    {
        public PlayerScore()
        {
            Frame = 1;
            Score = 0;
            Ball = 1;
            Spare = false;
        }
        public int Frame { get; set; }
        public int Score { get; set; }
        public int Ball { get; set; }
        public bool Spare { get; set; }
    }
}