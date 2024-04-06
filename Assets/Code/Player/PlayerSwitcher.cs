using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public bool darkMode;

    [SerializeField] SpriteRenderer face;
    [SerializeField] ParticleSystem body;

    [SerializeField] Color redFace;
    [SerializeField] Color blackFace;
    [SerializeField] Color blackBody;
    [SerializeField] Color whiteBody;

    public void SetMode(bool mode) => SwitchMode(mode);

    public void SwitchMode() => SwitchMode(!darkMode);

    public void SwitchMode(bool isDark)
    {
        darkMode = isDark;

        if (darkMode)
        {
            face.color = blackFace;
            body.startColor = whiteBody;
        }
        else
        {
            face.color = redFace;
            body.startColor = blackBody;
        }
    }
}
