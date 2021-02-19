using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _killCountText;

    public void UpdateKillCount(int totalKills)
    {
        _killCountText.text = $"{totalKills} Kills";
    }

}
