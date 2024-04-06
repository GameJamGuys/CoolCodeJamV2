using Cysharp.Threading.Tasks;

namespace Server.Examples
{
    public sealed class RandomJokeServerHandler : ServerHandler
    {
        public async UniTask<RandomJoke> GetJoke()
        {
            var response = await SendRequest<RandomJokeResponse>("https://official-joke-api.appspot.com/random_joke", null);
            return new RandomJoke(response.setup, response.punchline);
        }

                
        public sealed class RandomJoke
        {
            public string Setup { get; }
            public string Punchline { get; }

            public RandomJoke(string setup, string punchline)
            {
                Setup = setup;
                Punchline = punchline;
            }
        }
        
        private class RandomJokeResponse
        {
            public string type;
            public string setup;
            public string punchline;
            public int id;
        }
    }
}