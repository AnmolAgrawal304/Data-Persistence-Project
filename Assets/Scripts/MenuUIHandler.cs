using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI BestScoreText;
    public string playerName;

    // Start is called before the first frame update
    void Start()
    {
        BestScoreName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerName()
    {
        playerName = nameInputField.text;
        GameManager.instance.playerName = nameInputField.text.ToString();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitScene()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); //original code to quit Unity player
#endif    
    }

    public void BestScoreName()
    {
        if (!string.IsNullOrEmpty(GameManager.instance.bestPlayerName))
        {
            BestScoreText.text = "Best Score : " +
                GameManager.instance.bestPlayerName + " : " +
                GameManager.instance.bestScore;
        }
        else
        {
            BestScoreText.text = "Best Score : None";
        }
    }
}
