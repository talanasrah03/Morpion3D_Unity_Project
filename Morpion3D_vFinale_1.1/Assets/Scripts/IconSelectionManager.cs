using UnityEngine;

public class IconSelectionManager : MonoBehaviour
{
    public GameObject[] iconPrefabs;         // Prefabs for X and O
    public Material[] skyboxOptions;         // Drag & drop 6 skybox materials in Inspector

    // === ICON SELECTION ===

    public void SelectCercleCroix()
    {
        IconSelectionData.Instance.selectedOPrefab = iconPrefabs[0]; // Cercle
        IconSelectionData.Instance.selectedXPrefab = iconPrefabs[5]; // Croix
        Debug.Log(" Cercle vs Croix sélectionnés");
    }

    public void SelectPizzaSandwich()
    {
        IconSelectionData.Instance.selectedOPrefab = iconPrefabs[2]; // Pizza
        IconSelectionData.Instance.selectedXPrefab = iconPrefabs[3]; // Sandwich
        Debug.Log(" Pizza vs Sandwich sélectionnés");
    }

    public void SelectPommePasteque()
    {
        IconSelectionData.Instance.selectedOPrefab = iconPrefabs[1]; // Pomme
        IconSelectionData.Instance.selectedXPrefab = iconPrefabs[4]; // Pastèque
        Debug.Log(" Pomme vs Pastèque sélectionnés");
    }

    // === SKYBOX SELECTION ===

    public void SelectSkyboxClassic() { SetSkybox(0); }
    public void SelectSkyboxMidday() { SetSkybox(1); }
    public void SelectSkyboxDaybreak() { SetSkybox(2); }
    public void SelectSkyboxEvening() { SetSkybox(3); }
    public void SelectSkyboxSunset() { SetSkybox(4); }
    public void SelectSkyboxMidnight() { SetSkybox(5); }

    private void SetSkybox(int index)
    {
        if (skyboxOptions != null && index < skyboxOptions.Length)
        {
            IconSelectionData.Instance.selectedSkyboxMaterial = skyboxOptions[index];
            Debug.Log(" Skybox sélectionné : " + skyboxOptions[index].name);
        }
    }
}