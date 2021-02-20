using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField]
    Texture2D cursorArrow;
    private int _enemyKilled;
    private UIManager _uiManager;
    private PlayerStats _player;

    private void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        if (_uiManager == null) Debug.LogWarning("Please put UIManager on the scene.");
        var pl = GameObject.FindObjectOfType<PlayerStats>();
        if (pl != null) pl.OnPlayerDeath += OnPlayerDeath;
    }
    void Start()
    {
        Cursor.SetCursor(cursorArrow, new Vector2(16f, 16f), CursorMode.Auto);
        _enemyKilled = 0;
        if (_uiManager != null) _uiManager.UpdateKillCount(_enemyKilled);
    }

    public void OnEnemyDeath()
    {
        _enemyKilled++;
        if (_uiManager != null) _uiManager.UpdateKillCount(_enemyKilled);
    }

    public void OnPlayerDeath()
    {
        _uiManager.ShowGameOver();
        var pm = GameObject.FindObjectOfType<PlayerMovement>();
        pm.enabled = false;
    }
}
