using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SpellSync.Utilities;

public class ImageDownload : MonoBehaviour
{
    public async static Task DownloadImageAsync(string url, Image image)
    {
        if (url == "" || url == null) return;

        var request = UnityWebRequestTexture.GetTexture(url);
        AsyncOperation operation = request.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        if (request.isDone)
        {
            Texture2D _texture2D = ((DownloadHandlerTexture)request.downloadHandler).texture;

            Sprite sprite = Sprite.Create(_texture2D, new Rect(0, 0, _texture2D.width, _texture2D.height), new Vector2(0.5f, 0.5f), 20f);

            image.sprite = sprite;
        }
        else
        {
            Debug.Log("Download Image : Failed");
        }
    }
}
