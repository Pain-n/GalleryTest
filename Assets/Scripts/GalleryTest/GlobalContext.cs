using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalContext : MonoBehaviour
{
    public static GlobalContext Instance;

    [HideInInspector]
    public Sprite SelectedImageSprite;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
        DontDestroyOnLoad(this);
    }
}
