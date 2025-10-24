using UnityEngine;

public class IconSelectionData : MonoBehaviour
{
    public static IconSelectionData Instance;

    public GameObject selectedXPrefab;
    public GameObject selectedOPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // keeps this object when switching scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
