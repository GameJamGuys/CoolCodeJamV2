using System;
using System.Globalization;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Server.Examples
{
    public sealed class RandomAvatarServerHandler : ServerHandler
    {
        private RandomAvatarStyle _style = new();

        public void SetStyle(RandomAvatarStyle style)
        {
            _style = style;
        }
        public async UniTask<Texture2D> GetAvatar(EAvatarType type, string seed = null)
        {
            var styleString = EnumToStringStyle(type);
            seed ??= DateTime.Now.ToOADate().ToString(CultureInfo.InvariantCulture);
            
            Debug.Log($"https://api.dicebear.com/7.x/{styleString}/png?seed={seed}{_style}");
            var result = await GetTexture($"https://api.dicebear.com/7.x/{styleString}/png?seed={seed}{_style}");
            return result;
        }
        
        private string EnumToStringStyle(EAvatarType type)
        {
            return type.ToString().Replace("_", "-").ToLower();
        }
    }
}