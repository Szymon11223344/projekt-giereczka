using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //czas do zakonczenia
    public float timeLeft = 90f;


    public GameObject timeCounter;

    public GameObject GameOverOverlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //zmniejsz ilosc czasu pozosta�ego na zrobienie poziomu
        timeLeft -= Time.deltaTime;

        //aktualizuj UI
        UpdateUI();
    }

    void UpdateUI()
    {
        //aktualizuje interfejs 
        timeCounter.GetComponent<TextMeshProUGUI>().text = "Pozosta�y czas:" + Mathf.Floor(timeLeft).ToString();

        if(timeLeft <= 0 )
            GameOverOverlay.SetActive(true);
    }

    public void OnWin()
    {
        GameOverOverlay.SetActive(true);
        GameOverOverlay.transform.Find("ReasonText").GetComponent<TextMeshProUGUI>().text = "Wygra�e�!";
    } 

    public void OnLose()
    {
        GameOverOverlay.SetActive(true);
        GameOverOverlay.transform.Find("ReasonText").GetComponent<TextMeshProUGUI>().text = "Kamera ci� zobaczy�a!";
    }
}
