using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewingPanel : MonoBehaviour
{
    public Button CloseButton;

    public Image ViewingImage;
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;

        ViewingImage.sprite = GlobalContext.Instance.SelectedImageSprite;
        ViewingImage.SetNativeSize();
        ViewingImage.transform.localScale *= 2;

        CloseButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GalleryScene", LoadSceneMode.Single);
        });
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("GalleryScene", LoadSceneMode.Single);
            }
        }
    }
}
