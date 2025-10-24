using UnityEngine;
using UnityEngine.UI;

public class AccueilManager : MonoBehaviour
{
    public GameObject iconSelectionPanel;
    public Dropdown player1Dropdown;
    public Dropdown player2Dropdown;
    public GameObject[] iconPrefabs;         // 3D icon prefabs
    public Sprite[] iconSprites;             // Corresponding 2D icon sprites
    public Image player1IconPreview;         // UI preview image for player 1
    public Image player2IconPreview;         // UI preview image for player 2
    public SceneLoader sceneLoader;          // Reference to scene loader script
    public string gameSceneName = "SampleScene"; // Replace with your actual game scene name

    // Called when Start is clicked
    public void ShowIconSelection()
    {
        iconSelectionPanel.SetActive(true);
    }

    // Called when Continue is clicked
    public void ConfirmAndLoad()
    {
        int p1 = player1Dropdown.value;
        int p2 = player2Dropdown.value;

        // Assign 3D prefabs to be used in game
        IconSelectionData.Instance.selectedXPrefab = iconPrefabs[p1];
        IconSelectionData.Instance.selectedOPrefab = iconPrefabs[p2];

        // Assign preview icons for display (optional)
        if (player1IconPreview != null) player1IconPreview.sprite = iconSprites[p1];
        if (player2IconPreview != null) player2IconPreview.sprite = iconSprites[p2];

        // Load the actual game scene
        sceneLoader.LoadScene(gameSceneName);
    }
}
