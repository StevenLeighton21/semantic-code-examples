using System.Data;
using CodeForHumans.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using PoetryForMachines;

namespace CodeForHumans
{
    public class CodeForHumans
    {
        private TestUtils _test;

        [SetUp]
        public void Setup()
        {
            _test = new TestUtils();
        }

        [Test]
        public void I_can_create_a_game()
        {
            Given("Game does not exist");
            When("Create game");
            Then("My game will exist");
        }

        [Test]
        public void I_can_start_a_game()
        {
            Given("My game exists");
            When("Start game");
            Then("My game will be in progress");
        }
        
        [Test]
        public void I_begin_the_game_on_the_first_frame_with_a_score_of_zero()
        {
            Given("My game has started");
            When("I check my score");
            Then(My(1,1,0));
        }
        
        [Test]
        public void I_score_5_on_my_first_bowl()
        {
            Given(Frame_one_ball_one());
            When(I_bowl(5));
            Then(My(1,2,5));
        }
        
        [Test]
        public void I_score_3_on_my_second_bowl()
        {
            Given(Frame_one_ball_two_score_five());
            When(I_bowl(3));
            Then(My(2,1,8));
        }
        
        #region Test functionality

        private BowlingFrame Frame_one_ball_two_score_five()
        {
            return new BowlingFrame
            {
                Frame = 1,
                Ball = 2,
                StartingScore = 5
            };
        }

        private void Then(BowlingFrame expected)
        {
            _test.Inspect_score();
            _test.Current_frame().Should().Be(expected.Frame);
            _test.Current_score().Should().Be(expected.StartingScore);
            _test.Current_ball().Should().Be(expected.Ball);
        }

        private BowlingFrame My(int frame_is, int ball_is, int score_is)
        {
            return new BowlingFrame
            {
                Frame = frame_is,
                Ball = ball_is,
                StartingScore = score_is
            }; ;
        }

        private string I_bowl(int i)
        {
            _test.Bowl(i);
            return $"Bowled {i}";
        }

        private void Given(BowlingFrame frame)
        {
            _test.SetupGameAt(frame);
        }

        private BowlingFrame Frame_one_ball_one()
        {
            return new BowlingFrame
            {
                Frame = 1,
                Ball = 1,
                StartingScore = 0
            }; 
        }

        
        private void Then(string command)
        {
            switch (command)
            {
                case "My game will be in progress":
                    _test.Check_status_of_game().Should().Be("In Progress");
                    break;
                default:
                    _test.Does_game_exist().Should().BeTrue();
                    break;
            }
        }

        private void When(string command)
        {
            switch (command)
            {
                case "Start game":
                    _test.Start_game();
                    break;
                case "Create game":
                    _test.Create_game();
                    break;
                default:
                    _test.Inspect_score();
                    break;
            }
        }

        private void Given(string command)
        {
            switch (command)
            {
                case "My game has started":
                    _test.Game_has_started();
                    break;
                case "My game exists":
                    _test.Game_exists();
                    break;
                default:
                    _test.Game_has_not_started();
                    break;
            }
        }

        #endregion
    }
}