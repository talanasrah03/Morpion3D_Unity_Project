using UnityEngine;
using UnityEngine.UI;

public class AccueilManager : MonoBehaviour
{
    public GameObject iconSelectionPanel;
    public Dropdown player1Dropdown;
    public Dropdown player2Dropdown;
    public GameObject[] iconPrefabs;
    public SceneLoader sceneLoader; // Reference to your existing "load.cs"
    public string gameSceneName = "SampleScene"; // replace with your scene

    // Called when Start is clicked
    public void ShowIconSelection()
    {
        iconSelectionPanel.SetActive(true);
    }

    // Called when Continue is clicked
    public void ConfirmAndLoad()
    {
        IconSelectionData.Instance.selectedXPrefab = iconPrefabs[player1Dropdown.value];
        IconSelectionData.Instance.selectedOPrefab = iconPrefabs[player2Dropdown.value];

        sceneLoader.LoadScene(gameSceneName); // use your load.cs!
    }
}

