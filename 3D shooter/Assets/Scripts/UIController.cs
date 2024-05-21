using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreLabel;
    [SerializeField] SettingsPopup SettingsPopup;

    private int _Score;

    private void OnEnable()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void OnEnemyHit()
    {
        _Score += 1;
        ScoreLabel.text = _Score.ToString();
    }
    private void Start()
    {
        _Score = 0;
        ScoreLabel.text = _Score.ToString();
        SettingsPopup.Close();
    }

    public void OnOpenSettings()
    {
        Debug.Log("Opening Settings...");
        SettingsPopup.Open();
    }
}
