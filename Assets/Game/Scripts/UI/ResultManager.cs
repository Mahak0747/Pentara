using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public GameObject resultPannel;
    public Text resultText;

    public FightingController[] fightingController;
    public OpponentAI[] opponentAI;

    void Update(){
        foreach(FightingController fightingController in fightingController){
            if(fightingController.gameObject.activeSelf && fightingController.currentHealth<=0){
                SetResult("You Lose!");
                return;
            }
        }

        foreach(OpponentAI opponentAI in opponentAI){
            if(opponentAI.gameObject.activeSelf && opponentAI.currentHealth<=0){
                SetResult("You Win!");
                return;
            }
        }
    }

    void SetResult(string result){
        resultText.text=result;
        resultPannel.SetActive(true);
        Time.timeScale=0f;
    }

    public void LoadMainMenue(){
        Time.timeScale=1f;
        SceneManager.LoadScene("MainMenu");
    }
}
