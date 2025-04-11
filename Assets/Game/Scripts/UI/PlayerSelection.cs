using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    public GameObject playerCharacters;
    public GameObject[] allCharacters;
    public int currentIndex=0;

    void Start(){
        allCharacters=new GameObject[playerCharacters.transform.childCount];
        for(int i=0; i<playerCharacters.transform.childCount; i++){
            allCharacters[i]=playerCharacters.transform.GetChild(i).gameObject;
            allCharacters[i].SetActive(false);
        }
        if (PlayerPrefs.HasKey("SelectCharacterIndex")) {
            currentIndex = PlayerPrefs.GetInt("SelectCharacterIndex");
        }

        ShowCueerentCharacter();
    }

    void ShowCueerentCharacter(){
        foreach(GameObject character in allCharacters){
            character.SetActive(false);
        }

        allCharacters[currentIndex].SetActive(true);
    }

    public void NextCharacter(){
        currentIndex=(currentIndex+1)%allCharacters.Length;
        ShowCueerentCharacter();
    }

    public void PreviousCharacter(){
        currentIndex=(currentIndex-1+allCharacters.Length)%allCharacters.Length;
        ShowCueerentCharacter();
    }

    public void OnYesButtonClick(string sceneName){
        PlayerPrefs.SetInt("SelectCharacterIndex",currentIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneName);
    }
}
