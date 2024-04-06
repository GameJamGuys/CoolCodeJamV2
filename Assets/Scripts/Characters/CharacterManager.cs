using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Server;
using UnityEngine;

namespace Characters
{
    public sealed class CharacterManager : MonoBehaviour
    {
        [SerializeField] private Character[] _characters;
        private VictimManager _victimManager = new();

        private List<Character> Victims { get; } = new(VICTIMS_COUNT);

        private const int VICTIMS_COUNT = 3;

        private void Awake()
        {
            GenerateCharacters().Forget();
        }

        private async UniTaskVoid GenerateCharacters()
        {
            var tasks = new List<UniTask>(_characters.Length);
            foreach (var character in _characters)
            {
                tasks.Add(character.SpriteRandomizer.LoadAvatarAsync(character.GetHashCode().ToString()));
            }
            await UniTask.WhenAll(tasks);
            
            SelectImposters();
        }

        private void SelectImposters()
        {
            Victims.Clear();
            for (var i = 0; i < VICTIMS_COUNT; i++)
            {
                Character victim = null;
                do
                {
                    victim = _characters[Random.Range(0, _characters.Length)];
                } while (victim == null || Victims.Contains(victim));
                
                Victims.Add(victim);
            }
            _victimManager.Init(Victims);
        }
    }
}