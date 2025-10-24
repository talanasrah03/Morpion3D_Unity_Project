using UnityEngine;
using UnityEngine.SceneManagement;

public class AccueilManager : MonoBehaviour
{
    // Références aux écrans de l'interface
    public GameObject iconSelectionScreen; // Écran avec les boutons d’icônes et fonds
    public GameObject accueilScreen;       // Écran d’accueil avec le bouton Start

    public GameObject[] iconPrefabs;       // Liste des prefabs 3D des icônes (X, O, etc.)
    public string gameSceneName = "Game screen"; // Nom exact de la scène de jeu à charger

    // Méthode appelée quand on clique sur le bouton "Start"
    // Elle cache l'écran d'accueil et affiche l'écran de sélection
    public void ShowIconSelection()
    {
        if (iconSelectionScreen != null)
            iconSelectionScreen.SetActive(true);   // Affiche l'écran de sélection
        if (accueilScreen != null)
            accueilScreen.SetActive(false);        // Cache l'écran d'accueil
    }

    // Méthode appelée quand on clique sur le bouton "Continue"
    // Elle vérifie que toutes les sélections nécessaires ont été faites, puis charge la scène de jeu
    public void ConfirmAndLoad()
    {
        Debug.Log("🟢 Bouton CONTINUE cliqué");

        // Vérifie que le singleton IconSelectionData est bien présent
        if (IconSelectionData.Instance == null)
        {
            Debug.LogWarning("⚠️ IconSelectionData non trouvée.");
            return;
        }

        // Vérifie que les deux icônes ont été sélectionnées
        if (IconSelectionData.Instance.selectedXPrefab == null ||
            IconSelectionData.Instance.selectedOPrefab == null)
        {
            Debug.LogWarning("⚠️ Veuillez sélectionner des icônes avant de continuer.");
            return;
        }

        // Vérifie qu’un fond (skybox) a été sélectionné
        if (IconSelectionData.Instance.selectedSkyboxMaterial == null)
        {
            Debug.LogWarning("⚠️ Veuillez sélectionner un fond avant de continuer.");
            return;
        }

        // Toutes les vérifications sont OK → charge la scène de jeu
        SceneManager.LoadScene(gameSceneName);
    }
}
