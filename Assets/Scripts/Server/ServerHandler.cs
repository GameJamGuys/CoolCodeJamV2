using System;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Server
{
    public abstract class ServerHandler
    {
        private const float AWAIT_TIME = 5f;
        public event Action ErrorOccured;
        
        protected async UniTask<T> SendRequest<T>(string uri, object data) where T : new()
        {
            try
            {

                var request = new UnityWebRequest(uri);

                request.downloadHandler = new DownloadHandlerBuffer();

                var jsonData = JsonUtility.ToJson(data);
                var jsonBytes = Encoding.UTF8.GetBytes(jsonData);
                request.uploadHandler = new UploadHandlerRaw(jsonBytes);

                var cancellationToken = new CancellationTokenSource();
                cancellationToken.CancelAfter(TimeSpan.FromSeconds(AWAIT_TIME));

                try
                {
                    await request.SendWebRequest().WithCancellation(cancellationToken.Token);
                }
                catch (OperationCanceledException e)
                {
                    if (e.CancellationToken == cancellationToken.Token)
                    {
                        Debug.LogError("Request time out");
                        ErrorOccured?.Invoke();
                        return new T();
                    }
                }

                T responseData = new();
                if (request.result == UnityWebRequest.Result.Success)
                {
                    var responseText = request.downloadHandler.text;
                    Debug.Log(responseText);
                    if (!string.IsNullOrEmpty(responseText))
                    {
                        responseData = JsonUtility.FromJson<T>(responseText);
                    }
                }
                else
                {
                    Debug.LogError("Request error: " + request.result);
                    ErrorOccured?.Invoke();
                }

                return responseData;
            }
            catch (Exception e)
            {
                Debug.LogError("Request error: " + e.Message);
                ErrorOccured?.Invoke();
                return new T();
            }
        }

        protected async UniTask<Texture2D> GetTexture(string url)
        {
            var request = UnityWebRequestTexture.GetTexture(url);
            var cancellationToken = new CancellationTokenSource();
            cancellationToken.CancelAfter(TimeSpan.FromSeconds(AWAIT_TIME));
            var response = await request.SendWebRequest().WithCancellation(cancellationToken.Token);
            return DownloadHandlerTexture.GetContent(response);
        }
    }
}