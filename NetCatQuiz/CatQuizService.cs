namespace NetCatQuiz;

// Database would contain 3 columns:
// - User ID: to uniquely identify a user
// - Total # of answers
// - Total # of correct answers
public class CatQuizService
{
    public void GradeCatQuiz(string userId, bool correct)
    {
        // 1. For a specific user ID increment the Total # of answers
        // 2. - if correct = true increment the Total # of correct answers
        //    - if correct = false do nothing
    }

    public IEnumerable<(string name, int score)> GetLeaderboard()
    {
        // 1. Fetch Leaderboard data from DB for a specific user ID
        // 2. Compute score as (Total # of correct answers)/(Total # of answers)
        return new (string name, int score)[] {};
    }
}