using System.Collections.Generic;
using System.Linq;
using Server;
using UnityEngine;
using UnityEngine.UI;

namespace Characters
{
    public static class VictimManager
    {
        private static VictimImage[] _victimImages;
        private static List<Character> _victimsList;
        
        public static void Init(List<Character> characters)
        {
            _victimsList = characters;
            _victimImages = Object.FindObjectsOfType<VictimImage>();
            for (var i = 0; i < characters.Count; i++)
            {
                _victimImages[i].SetSprite(characters[i].SpriteRandomizer.Sprite);
            }
        }

        public static void OnKilled(Character character)
        {
            if (_victimsList.Contains(character))
            {
                _victimImages[_victimsList.IndexOf(character)].SetDeadImage();
            }
            else
            {
                Debug.Log("LOSE");
            }
        }
    }
}