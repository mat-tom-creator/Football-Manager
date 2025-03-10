namespace FootballManager.Core.Interfaces
{
    using Models;
    using Base;

    public interface IFanInteractionService : IService
    {
        string Interact(string type, string input);
        
        // Poll related methods
        Poll GetPoll();
        string SubmitPollAnswer(string answer);
        
        // Trivia related methods
        Trivia GetTrivia();
        bool CheckTriviaAnswer(string answer);
    }
}