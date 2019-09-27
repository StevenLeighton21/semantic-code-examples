using PoetryForMachines.ValueTypes;

namespace PoetryForMachines
{
    public class Bowling
    {
        private readonly Game _game;
        private readonly PlayerScore _player;
        private int _bowlOne;

        public Bowling()
        {
            _player = new PlayerScore();
            _game = new Game();
            _bowlOne = 0;
        }

        public Bowling(Game game, PlayerScore player, int bowlOne)
        {
            _game = game;
            _player = player;
            _bowlOne = bowlOne;
        }

        public void Start()
        {
            _game.Status = "In Progress";
        }

        public Game GameInformation()
        {
            return _game;
        }

        public PlayerScore WhatIsTheScore()
        {
            return _player;
        }

        public void ThePreviousBowlThisFrameWas(int i)
        {
            _bowlOne = i;
        }

        public void Bowl(int i)
        {

            if (_player.Ball == 1)
            {
                _player.Ball++;
                _bowlOne = i;
                _player.Score += i;
            }
            
            else if (_player.Ball == 2)
            {
                if (_bowlOne + i == 10)
                {
                    _player.Ball = 1;
                    _player.Frame++;
                    _player.Spare = true;
                }
                else
                {
                    _player.Ball = 1;
                    _player.Frame++;
                    _player.Score += i;
                }
            }
        }
    }
}