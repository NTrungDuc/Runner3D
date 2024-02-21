using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance { get => instance; }
    public PlayerState state;
    [SerializeField] private GameObject Player;
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnOpenStore;
    [SerializeField] public GameObject restartPanel;
    [SerializeField] public GameObject store;
    public void StartGame()
    {
        state = PlayerState.Moving;
        btnStart.transform.DOScale(0, 0);
        btnOpenStore.transform.DOScale(0, 1f);
    }
    public void RestartGame()
    {
        state = PlayerState.Idle;        
        GroundSpawner.Instance.RestartGround();
        Player.transform.position = Vector3.zero;
        restartPanel.transform.DOScale(0, 2);
        btnStart.transform.DOScale(1, 0);
        btnOpenStore.transform.DOScale(1, 1f);
    }
    public void openStore()
    {
        store.transform.DOScale(1, 1f);
        btnOpenStore.transform.DOScale(0, 1f);
    }
    public void closeStore()
    {
        store.transform.DOScale(0, 1f);
        btnOpenStore.transform.DOScale(1, 1f);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Awake()
    {
        instance = this;
    }
}
public enum PlayerState
{
    Idle,
    Moving,
    Die
}

