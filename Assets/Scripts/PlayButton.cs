using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();

        btn.onClick.AddListener(StartGame);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
