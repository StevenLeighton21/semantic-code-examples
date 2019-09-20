using PoetryForMachines.ValueTypes;

namespace PoetryForMachines
{
    public class Bowling
    {
        private readonly BowlingGameStatus _status;
        private readonly PlayerScore _playerScore;

        public Bowling()
        {
            _playerScore = new PlayerScore();
            _status = new BowlingGameStatus();
        }

        public Bowling(BowlingGameStatus status, PlayerScore playerScore)
        {
            _status = status;
            _playerScore = playerScore;
        }

        public void Start()
        {
            _status.Status = "In Progress";
            _playerScore.Frame = 1;
            _playerScore.Score = 0;
        }

        public BowlingGameStatus CheckStatus()
        {
            return _status;
        }

        public PlayerScore CheckCurrentScore()
        {
            return _playerScore;
        }

        public void Bowl(int i)
        {
            _playerScore.Score += i;

            if (_playerScore.Ball == 1)
            {
                _playerScore.Ball++;    
            }
            
            else if (_playerScore.Ball == 2)
            {
                _playerScore.Ball = 1;
                _playerScore.Frame++;
            }
            
        }
    }
}