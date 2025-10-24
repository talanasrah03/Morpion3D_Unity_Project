using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
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
        // Récupérer les prefabs sélectionnés dans IconSelectionData
        if (IconSelectionData.Instance != null)
        {
            selectedXPrefab = IconSelectionData.Instance.selectedXPrefab;
            selectedOPrefab = IconSelectionData.Instance.selectedOPrefab;
        }
        else
        {
            Debug.LogWarning("⚠️ IconSelectionData.Instance est null. Icônes par défaut utilisées.");
        }

        UpdateTurnUI();

        if (victoirePanel != null) victoirePanel.SetActive(false);
        if (egalitePanel != null) egalitePanel.SetActive(false);

        Time.timeScale = 1f; // Assure que le temps n'est pas stoppé au lancement
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
            ShowVictoirePanel();
        }
        else if (!gameIsOver && GridManager.Instance.countCoups == 27)
        {
            Debug.Log("Egalité !");
            ShowEgalitePanel();
        }
        else
        {
            SwitchPlayer();
        }
    }

    private void UpdateTurnUI()
    {
        if (player1Icon != null && player2Icon != null)
        {
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
            Time.timeScale = 0f;
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
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("Le panneau d'egalite n'est pas assigné dans l'Inspecteur !");
        }
    }
}
