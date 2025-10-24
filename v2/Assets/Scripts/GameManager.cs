using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // definitions des variables pour une meilleure gestion
    [Header("🎮 Game ")]
    public int currentPlayer = 1;
    private bool gameIsOver = false;

    [Header("🎯 Icon Prefabs ")]
    public GameObject selectedXPrefab;
    public GameObject selectedOPrefab;

    [Header("🧾 UI Elements")]
    public Image player1Icon;
    public Image player2Icon;

    [Header("🎨 Player Icon Sprites")]
    public Sprite player1ActiveSprite;
    public Sprite player1InactiveSprite;
    public Sprite player2ActiveSprite;
    public Sprite player2InactiveSprite;

    [Header("UI Popups")]
    public GameObject victoirePanel; 
    public GameObject egalitePanel;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // Chargement des prefabs seulement si l'icon est bien selecitonnée
        if (IconSelectionData.Instance != null)
        {
            selectedXPrefab = IconSelectionData.Instance.selectedXPrefab;
            selectedOPrefab = IconSelectionData.Instance.selectedOPrefab;
        }
        else
        {
            Debug.LogWarning("⚠️ IconSelectionData.Instance est null. Icônes par défaut seront utilisées.");
        }

        // Affichage du tour du premier joueur
        UpdateTurnUI();

        // verifie bien que victoire panel est invisible durant le jeu
        if (victoirePanel != null)
        {
            victoirePanel.SetActive(false);
        }
        if (egalitePanel != null)
            {
                egalitePanel.SetActive(false);
            }
        }
    public int GetCurrentPlayer() => currentPlayer;

    public void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        UpdateTurnUI();
    }

    public void PlayerMadeMove()
    {
        if (!gameIsOver && GridManager.Instance.CheckWin())
        {
            Debug.Log("Player " + currentPlayer + " a gagné !");
            ShowVictoirePanel(); // Appeler la fonction pour afficher le panneau
        }
        else if (!gameIsOver && GridManager.Instance.countCoups == 27)
        {
            Debug.Log("Egalité !");
            ShowEgalitePanel(); // affiche le panneau d'egalité
        }
        else
        {
            SwitchPlayer();
        }
    }

    private void UpdateTurnUI()
    // permet d'update le sprite en fonction du tour de chaque joueur
    {
        if (player1Icon != null && player2Icon != null)
        {
            // Change sprites
            player1Icon.sprite = (currentPlayer == 1) ? player1ActiveSprite : player1InactiveSprite;
            player2Icon.sprite = (currentPlayer == 2) ? player2ActiveSprite : player2InactiveSprite;

            
            player1Icon.color = Color.white;
            player2Icon.color = Color.white;
        }
    }

    public void ShowVictoirePanel()
    {
        if (victoirePanel != null)
        {
            victoirePanel.SetActive(true);
            gameIsOver = true;
            Time.timeScale = 0f; // permet de mettre le jeu en pause
        }
        else
        {
            Debug.LogError("Le panneau de victoire n'est pas assigné dans l'Inspecteur !");
        }
    }

    public void ShowEgalitePanel()
    {
        if (egalitePanel != null)
        {
            egalitePanel.SetActive(true);
            gameIsOver = true;
            Time.timeScale = 0f; // permet de mettre le jeu en pause
        }
        else
        {
            Debug.LogError("Le panneau d'egalite n'est pas assigné dans l'Inspecteur !");
        }
    }

    // Vous pouvez ajouter une fonction ici pour masquer le panneau de victoire si nécessaire,
    // par exemple, si vous avez un bouton "Retour au jeu" ou similaire.
    // public void HideVictoirePanel()
    // {
    //     if (victoirePanel != null)
    //     {
    //         victoirePanel.SetActive(false);
    //         gameIsOver = false;
    //         // Optional: Time.timeScale = 1f; // Reprendre le jeu
    //     }
    // }
}
