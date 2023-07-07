using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour
{
    public Button GalleryButton;
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        GalleryButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GalleryScene", LoadSceneMode.Single);
        });
    }
}
