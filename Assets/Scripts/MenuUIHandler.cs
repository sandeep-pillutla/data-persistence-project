using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    //public Text PlayerNameText;
    public Text BestScoreText;
    public InputField NameInput;

    public void Start()
    {
        BestScoreText.text = $"Best Score : {MainManagerUI.Instance.bestScore.ToString()}";
        NameInput.text = MainManagerUI.Instance.playerName;
    }

    public void SavePlayerName(string value)
    {
        MainManagerUI.Instance.playerName = value;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}