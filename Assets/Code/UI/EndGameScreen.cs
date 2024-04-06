using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScreen : StaticInstance<EndGameScreen>
{
    [SerializeField]
    List<GameObject> disableThings;

    [SerializeField]
    GameObject winScreen, loseScreen;

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
