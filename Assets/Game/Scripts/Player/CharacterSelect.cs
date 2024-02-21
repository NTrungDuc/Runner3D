using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    private int characterIndex;
    [SerializeField] private GameObject[] skin;
    [SerializeField] private PlayerController playerController;
    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("characterIndex", 0);
        setSkin();
        playerController.setComponentAnim(getPlayerSkin());
    }
    public void setID(int id)
    {
        characterIndex = id;
        PlayerPrefs.SetInt("characterIndex", id);
        setSkin();
        playerController.setComponentAnim(getPlayerSkin());
    }
    public void setSkin()
    {
        foreach(GameObject player in skin)
        {
            player.SetActive(false);
            skin[characterIndex].SetActive(true);
        }
    }
    public GameObject getPlayerSkin()
    {
        return skin[characterIndex];
    }
}
