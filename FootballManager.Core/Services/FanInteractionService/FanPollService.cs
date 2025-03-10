namespace FootballManager.Core.Services.FanInteraction
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class FanPollService : IFanInteractionService
    {
        private readonly string _interactionType;
        private readonly string _input;

        public FanPollService() : this("vote", "teamA") { }

        public FanPollService(string interactionType, string input)
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
            sb.AppendLine($"Processing fan poll of type: {type}");
            
            if (type == "vote" && input == "teamA")
            {
                sb.AppendLine("Vote registered for Team A.");
            }
            else if (type == "vote" && input == "teamB")
            {
                sb.AppendLine("Vote registered for Team B.");
            }
            else
            {
                sb.AppendLine("Invalid poll type or input.");
            }
            
            return sb.ToString();
        }
        
        public Poll GetPoll()
        {
            // Return sample poll data
            return new Poll
            {
                Question = "Who will win the Premier League this season?",
                Options = new List<string> { "Manchester City", "Liverpool", "Arsenal" },
                Results = new Dictionary<string, int>
                {
                    { "Manchester City", 42 },
                    { "Liverpool", 31 },
                    { "Arsenal", 27 }
                }
            };
        }

        public string SubmitPollAnswer(string answer)
        {
            // Process the answer and return a formatted result
            return $"Thank you for voting for {answer}!\nCurrent poll results:\nManchester City: 42%\nLiverpool: 31%\nArsenal: 27%";
        }

        public Trivia GetTrivia()
        {
            // Fan poll service doesn't provide trivia
            throw new NotImplementedException("Trivia is not supported by the Poll service");
        }

        public bool CheckTriviaAnswer(string answer)
        {
            // Fan poll service doesn't check trivia answers
            throw new NotImplementedException("Trivia is not supported by the Poll service");
        }
    }
}