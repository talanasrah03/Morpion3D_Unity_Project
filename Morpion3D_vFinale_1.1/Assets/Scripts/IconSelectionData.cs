using UnityEngine;

public class IconSelectionData : MonoBehaviour
{
    public static IconSelectionData Instance;

    public GameObject selectedXPrefab;
    public GameObject selectedOPrefab;

    public Material selectedSkyboxMaterial; //  New: holds selected skybox

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
