using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : StaticInstance<EndGameScreen>
{
    [SerializeField]
    List<GameObject> disableThings;

    [SerializeField]
    GameObject winScreen, loseScreen;

    [SerializeField] private Image _loadingImage;

    public void OnGameLoaded()
    {
        FindObjectOfType<PlayerController>(true).gameObject.SetActive(true);
        _loadingImage.DOColor(Color.clear, 1f);
    }

    public void EndGame(bool isWin)
    {
        foreach(GameObject thing in disableThings)
        {
            thing.SetActive(false);
        }

        if (isWin)
            winScreen.SetActive(true);
        else
            loseScreen.SetActive(true);
    }

    public void Reload() => Loader.Reload();
}
