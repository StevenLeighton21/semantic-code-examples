using PoetryForMachines;
using PoetryForMachines.ValueTypes;

namespace CodeForHumans.TestUtilities
{
    public class TestUtils
    {
        private Bowling _game;
        private PlayerScore _currentScore;

        public object Game_has_not_started()
        {
            _game = null;
            return new object();
        }

        public Bowling My_game()
        {
            return _game;
        }

        public void Create_game()
        {
            _game = new Bowling();
        }

        public bool Does_game_exist()
        {
            return _game != null;
        }

        public void Game_exists()
        {
            Create_game();
        }

        public void Start_game()
        {
            _game.Start();
        }

        public string Check_status_of_game()
        {
            return _game.CheckStatus().Status;
        }

        public void Game_has_started()
        {
            Create_game();
            Start_game();
        }

        public void Inspect_score()
        {
            _currentScore = _game.CheckCurrentScore();
        }

        public int Current_frame()
        {
            return _currentScore.Frame;
        }

        public int Current_score()
        {
            return _currentScore.Score;
        }

        public void SetupGameAt(BowlingFrame frame)
        {
            _game = new Bowling(
                new BowlingGameStatus
                    {
                        Status = "In Progress"
                    }, 
                new PlayerScore
                    {
                        Frame = frame.Frame,
                        Score = frame.StartingScore,
                        Ball = frame.Ball
                    });
            
        }

        public void Bowl(int i)
        {
            _game.Bowl(i);
        }

        public int Current_ball()
        {
            return _currentScore.Ball;
        }
    }
}