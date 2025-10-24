using UnityEngine;

public class SkyboxApplier : MonoBehaviour
{
    void Start()
    {
        Debug.Log("🔄 SkyboxApplier is running.");

        // Vérifie que le singleton IconSelectionData est bien présent
        if (IconSelectionData.Instance != null)
        {
            // Vérifie qu'une skybox a bien été sélectionnée
            if (IconSelectionData.Instance.selectedSkyboxMaterial != null)
            {
                RenderSettings.skybox = IconSelectionData.Instance.selectedSkyboxMaterial;
                Debug.Log("✅ Skybox appliquée : " + IconSelectionData.Instance.selectedSkyboxMaterial.name);
            }
            else
            {
                Debug.LogWarning("❌ Aucune skybox sélectionnée.");
            }
        }
        else
        {
            Debug.LogWarning("❌ IconSelectionData.Instance est null.");
        }
    }
}
