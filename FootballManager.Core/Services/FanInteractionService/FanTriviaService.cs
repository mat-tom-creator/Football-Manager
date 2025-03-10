namespace FootballManager.Core.Services.FanInteraction
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class FanTriviaService : IFanInteractionService
    {
        private readonly string _interactionType;
        private readonly string _input;

        public FanTriviaService() : this("question", "correct") { }

        public FanTriviaService(string interactionType, string input)
        {
            _interactionType = interactionType;
            _input = input;
        }

        public string Execute()
        {
            return Interact(_interactionType, _input);
        }

        public string Interact(string type, string input)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Processing trivia of type: {type}");
            
            if (type == "question" && input == "correct")
            {
                sb.AppendLine("Correct answer! You earn 10 points.");
            }
            else if (type == "question" && input == "wrong")
            {
                sb.AppendLine("Wrong answer. Better luck next time!");
            }
            else
            {
                sb.AppendLine("Invalid trivia type or input.");
            }
            
            return sb.ToString();
        }
        
        public Poll GetPoll()
        {
            // Trivia service doesn't provide polls
            throw new NotImplementedException("Polls are not supported by the Trivia service");
        }

        public string SubmitPollAnswer(string answer)
        {
            // Trivia service doesn't process poll answers
            throw new NotImplementedException("Polls are not supported by the Trivia service");
        }

        public Trivia GetTrivia()
        {
            // Return sample trivia data
            return new Trivia
            {
                Question = "Which player has scored the most goals in Premier League history?",
                Options = new List<string> 
                { 
                    "Wayne Rooney", 
                    "Alan Shearer", 
                    "Thierry Henry", 
                    "Sergio Aguero" 
                },
                CorrectAnswer = "Alan Shearer"
            };
        }

        public bool CheckTriviaAnswer(string answer)
        {
            // Check if the answer is correct
            return answer == "Alan Shearer";
        }
    }
}