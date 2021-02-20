using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _killCountText;
    [SerializeField]
    GameObject _grenadeImg;
    [SerializeField]
    GameObject _pistolImg;
    [SerializeField]
    GameObject _gameOverImg;

    public void UpdateKillCount(int totalKills)
    {
        _killCountText.text = $"{totalKills} Kills";
    }

    internal void SetWeapon(Weapons name)
    {
        _grenadeImg.SetActive(name == Weapons.GrenadeLauncher);
        _pistolImg.SetActive(name == Weapons.Pistol);
    }

    internal void ShowGameOver()
    {
        _gameOverImg.SetActive(true);
    }
}
