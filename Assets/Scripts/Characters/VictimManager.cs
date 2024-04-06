using System.Collections.Generic;
using System.Linq;
using Server;
using UnityEngine;
using UnityEngine.UI;

namespace Characters
{
    public static class VictimManager
    {
        private static Image[] _victimImages;
        private static List<Character> _victimsList;
        
        public static void Init(List<Character> characters)
        {
            _victimsList = characters;
            _victimImages = Object.FindObjectsOfType<VictimImage>().Select(x => x.GetComponent<Image>()).ToArray();
            for (var i = 0; i < characters.Count; i++)
            {
                _victimImages[i].sprite = characters[i].SpriteRandomizer.Sprite;
            }
        }
    }
}