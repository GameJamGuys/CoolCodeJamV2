using Cysharp.Threading.Tasks;
using Server.Examples;
using UnityEngine;

namespace Characters
{
    public sealed class CharacterSpriteRandomizer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private RandomAvatarServerHandler _randomAvatarServerHandler = new();
        public Sprite Sprite => _spriteRenderer.sprite;

        public async UniTask LoadAvatarAsync(string seed)
        {
            var style = new RandomAvatarStyle().SetSize(96);
            _randomAvatarServerHandler.SetStyle(style);
            var texture = await _randomAvatarServerHandler.GetAvatar(EAvatarType.Adventurer, seed);
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 70f);
            _spriteRenderer.sprite = sprite;
        }
    }
}