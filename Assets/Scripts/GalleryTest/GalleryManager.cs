using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    public ScrollRect ScrollRect;
    public RectTransform Canvas;
    public RectTransform ImagesContainer;
    public Button ImageButtonPrefab;

    public Button CloseButton;

    private int currentImageIndex;
    private bool maxIndexReached;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        Instantiate(Resources.Load<LoadPanel>("Prefabs/Panels/LoadingPanel"), Canvas);

        CloseButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
        });

        currentImageIndex = 1;

        CreateImageButton(10);

        ScrollRect.onValueChanged.AddListener((Vector2 value) =>
        {
            if (value.y <= 0) CreateImageButton(1);
        });
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
            }
        }
    }

    public void CreateImageButton(int amount)
    {
        if (maxIndexReached) return;
        amount += currentImageIndex-1;
        while (currentImageIndex <= amount)
        {
            Button item = Instantiate(ImageButtonPrefab, ImagesContainer);

            StartCoroutine(LoadImage($"http://data.ikppbb.com/test-task-unity-data/pics/{currentImageIndex}.jpg", item));
            item.onClick.AddListener(() =>
            {
                if (item.image.sprite == null) return;
                GlobalContext.Instance.SelectedImageSprite = item.image.sprite;
                SceneManager.LoadScene("ViewingScene", LoadSceneMode.Single);
            });
            currentImageIndex++;
        }
    }

    IEnumerator LoadImage(string url, Button button)
    {

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            //Предполагается, что данная ошибка означает, что мы подгрузили все изображения. Да, не всегда это может быть так, но пока что это лучшее, что мне пришло в голову.
            if(request.error == "HTTP/1.1 404 Not Found") maxIndexReached = true;
            Debug.Log(request.error);
            Destroy(button.gameObject);
        }
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            button.image.sprite = sprite;
        }
    }
}
