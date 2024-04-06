using UnityEngine;
using UnityEngine.UI;

namespace Characters
{
    public sealed class VictimImage : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _deadImage;
        public void SetDeadImage()
        {
            _image.sprite = _deadImage;
            _image.color = new Color(0.6f, 0.1f, 0.1f);
        }

        public void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }
    }
}