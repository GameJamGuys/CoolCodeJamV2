using UnityEngine;

namespace Characters
{
    public sealed class Character : MonoBehaviour
    {
        [field: SerializeField] public CharacterSpriteRandomizer SpriteRandomizer { get; private set; }
    }
}