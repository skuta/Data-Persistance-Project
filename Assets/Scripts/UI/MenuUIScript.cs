using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIScript : MonoBehaviour
{

public GameObject inputField; 
public GameObject scoreText;

void Start()
{
    
    if (SessionManager.Instance.name != null)
    {
        inputField.GetComponent<TMP_InputField>().text = SessionManager.Instance.GetActivePlayerName();
        scoreText.GetComponent<TMP_Text>().text = $"Best Score : {SessionManager.Instance.GetBestPlayerName()} : {SessionManager.Instance.GetTopScore()}";
            
        //    text= $"Best Score : {SessionManager.Instance.GetBestPlayerName()} : {SessionManager.Instance.GetTopScore()}";
    }
    

}
    public void StartGame()
    {
        SessionManager.Instance.SetActivePlayerName(inputField.GetComponent<TMP_InputField>().text);
        SessionManager.Instance.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
    public void Leaderboard()
    {
   // SessionManager.Instance.Leaderboard();
    } 

}