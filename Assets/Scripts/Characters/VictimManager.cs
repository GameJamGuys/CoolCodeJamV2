using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public static class VictimManager
    {
        private static VictimImage[] _victimImages;
        private static List<Character> _victimsList;

        private static int _victimsMurdered = 0;
        
        public static void Init(List<Character> characters)
        {
            _victimsList = characters;
            _victimImages = Object.FindObjectsOfType<VictimImage>();
            for (var i = 0; i < characters.Count; i++)
            {
                _victimImages[i].SetSprite(characters[i].SpriteRandomizer.Sprite);
            }
            EndGameScreen.Instance.OnGameLoaded();
        }

        public static void OnKilled(Character character)
        {
            if (_victimsList.Contains(character))
            {
                _victimImages[_victimsList.IndexOf(character)].SetDeadImage();
                _victimsMurdered++;
                if (_victimsMurdered == _victimsList.Count)
                    EndGameScreen.Instance.EndGame(true);
            }
            else
            {
                EndGameScreen.Instance.EndGame(false);
            }
        }
    }
}