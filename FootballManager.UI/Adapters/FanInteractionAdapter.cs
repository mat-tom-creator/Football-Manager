namespace FootballManager.UI.Adapters
{
    using FootballManager.Core.Interfaces;
    using FootballManager.Core.Models;
    using System.Windows.Forms;
    using System;

    public class FanInteractionAdapter
    {
        private readonly IFanInteractionService _fanInteractionService;

        public FanInteractionAdapter(IFanInteractionService fanInteractionService)
        {
            _fanInteractionService = fanInteractionService ?? throw new ArgumentNullException(nameof(fanInteractionService));
        }

        public void SetupPollUI(Label questionLabel, RadioButton option1, RadioButton option2, RadioButton option3)
        {
            if (questionLabel == null || option1 == null || option2 == null || option3 == null)
                throw new ArgumentNullException("UI controls cannot be null");
            
            // Get poll data from service
            Poll poll = _fanInteractionService.GetPoll();
            
            // Setup UI
            questionLabel.Text = poll.Question;
            
            if (poll.Options.Count >= 3)
            {
                option1.Text = poll.Options[0];
                option2.Text = poll.Options[1];
                option3.Text = poll.Options[2];
            }
            else
            {
                // Default options if not enough data
                option1.Text = "Option 1";
                option2.Text = "Option 2";
                option3.Text = "Option 3";
            }
            
            option1.Checked = false;
            option2.Checked = false;
            option3.Checked = false;
        }

        public void ProcessPollResults(string selectedOption, Label resultLabel)
        {
            if (resultLabel == null)
                throw new ArgumentNullException(nameof(resultLabel));
            
            // Submit answer
            string result = _fanInteractionService.SubmitPollAnswer(selectedOption);
            
            // Display result
            resultLabel.Text = result;
        }

        public void SetupTriviaUI(Label questionLabel, RadioButton option1, RadioButton option2, 
            RadioButton option3, RadioButton option4)
        {
            if (questionLabel == null || option1 == null || option2 == null || 
                option3 == null || option4 == null)
                throw new ArgumentNullException("UI controls cannot be null");
            
            // Get trivia from service
            Trivia trivia = _fanInteractionService.GetTrivia();
            
            // Setup UI
            questionLabel.Text = trivia.Question;
            
            if (trivia.Options.Count >= 4)
            {
                option1.Text = trivia.Options[0];
                option2.Text = trivia.Options[1];
                option3.Text = trivia.Options[2];
                option4.Text = trivia.Options[3];
            }
            else
            {
                // Default options if not enough data
                option1.Text = "Option 1";
                option2.Text = "Option 2";
                option3.Text = "Option 3";
                option4.Text = "Option 4";
            }
            
            option1.Checked = false;
            option2.Checked = false;
            option3.Checked = false;
            option4.Checked = false;
        }

        public void ProcessTriviaResults(string selectedOption, Label resultLabel)
        {
            if (resultLabel == null)
                throw new ArgumentNullException(nameof(resultLabel));
            
            // Check answer
            bool isCorrect = _fanInteractionService.CheckTriviaAnswer(selectedOption);
            
            // Display result
            if (isCorrect)
            {
                resultLabel.Text = "Correct! You earned 10 points.";
            }
            else
            {
                resultLabel.Text = "Incorrect. Try again next time.";
            }
        }
    }
}