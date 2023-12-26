using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public GameObject gameClearPannel;
    [SerializeField] private GameObject restartBtn;
    
    [SerializeField] private  TextMeshProUGUI playTime;
    [SerializeField] private  TextMeshProUGUI TimeText;
    [SerializeField] private TextMeshProUGUI bestTime;
    

    public float t = 0; // play time

    private bool isClear = false;

    private void Awake()
    {
        restartBtn.SetActive(false);
        i = this;
    }

    private void Update()
    {
        if (isClear) return;

        t += Time.deltaTime;  
        playTime.text = SetTime((int)t); 
    }

    string SetTime(int t)
    {
        string min = (t / 60).ToString(); 

        if (int.Parse(min) < 10) min = "0" + min;

        string sec = (t % 60).ToString(); 
        
        if (int.Parse(sec) < 10) sec = "0" + sec;  

        return min + ":" + sec;
    }

    private void SetBestTime()
    {
        int currentTime = (int)t;
        if (PlayerPrefs.HasKey("BEST"))
        {
            int best = PlayerPrefs.GetInt("BEST");

            if (currentTime < best)
            {
                PlayerPrefs.SetInt("BEST", currentTime);
                bestTime.text = "BEST : " + SetTime(currentTime);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BEST", currentTime);
            bestTime.text = "BEST : " + SetTime(currentTime);
        }

        bestTime.enabled = true;
    }


    public void End()
    {
        isClear = true;
        TimeText.text = "TIME : " + SetTime((int)t);
        gameClearPannel.SetActive(true); 
        restartBtn.SetActive(true);
        SetBestTime();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            End();
        }
    }
}
