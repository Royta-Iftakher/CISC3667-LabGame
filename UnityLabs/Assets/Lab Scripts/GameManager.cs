using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int spiderKilled = 0;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI nameTxt;

    int level;

    // Start is called before the first frame update
    void Start()
    {
        //spiderKilled = PersistentData.Instance.GetScore();
        level = SceneManager.GetActiveScene().buildIndex - 1;
        DisplayScore();
        DisplayName();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
        DisplayName();
    }

    public void AddPoints(int score)
    {
        spiderKilled = spiderKilled + score;
        Debug.Log("score: " + spiderKilled);
        DisplayScore();
        PersistentData.Instance.SetScore(PersistentData.Instance.GetScore() + spiderKilled);
        //DisplayScore();
    }

    public void DisplayScore()
    {
        scoreTxt.SetText("Score: " + PersistentData.Instance.GetScore());
    }

    public void DisplayName()
    {
        nameTxt.SetText("Good Luck, " + PersistentData.Instance.GetName());
    }


    public void AdvanceScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
