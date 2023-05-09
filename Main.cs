using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static Main Instance;

    [SerializeField] GameObject pausePanel;

    public BattleZone curBattleZone;

    public static bool pause { get; private set; } = false;

    private void Awake()
    {
        Instance = this;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pause = false;
    }

    public void SetPause(bool value)
    {
        pause = value;
        pausePanel.SetActive(value);
        Player player = FindObjectOfType<Player>();
        player.SetWeaponAnimEnabled(!value);
        player.SetPlayerAnimEnabled(!value);
        if (curBattleZone != null)
            curBattleZone.StopAllEnemies();
        player.StopMovement();
    }
}
