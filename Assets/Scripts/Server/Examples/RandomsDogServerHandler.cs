using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Server.Examples
{
    public sealed class RandomsDogServerHandler : ServerHandler
    {
        public async UniTask<Texture2D> GetRandomDog()
        {
            return await GetTexture(await GetDogURL());
        } 
        private async UniTask<string> GetDogURL()
        {
            var response = await SendRequest<RandomDogResponse>("https://dog.ceo/api/breeds/image/random", null);
            return response.message;
        }
        
        private sealed class RandomDogResponse
        {
            public string message;
            public string status;
        }
    }
}