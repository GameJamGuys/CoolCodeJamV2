using System.Collections.Generic;
using Server;
using UnityEngine;
using UnityEngine.UI;

namespace Characters
{
    public sealed class VictimManager
    {
        private Image _victimImage;
        private List<Character> _victimsList;
        private Character _currentVictim;
        
        public void Init(List<Character> characters)
        {
            _victimsList = characters;
            _victimImage = Object.FindObjectOfType<VictimImage>().GetComponent<Image>();
            SelectNextVictim();
        }

        private void SelectNextVictim()
        {
            if (_victimsList.Count <= 0)
                return;
            
            _currentVictim = _victimsList[0];
            _victimImage.sprite = _currentVictim.SpriteRandomizer.Sprite;
        }
    }
}