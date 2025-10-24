using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("🎮 Game Flow")]
    public string sceneVictoire = "victoire";
    public string sceneEgalite = "egalite";
    public int currentPlayer = 1;
    private bool gameIsOver = false;

    [Header("🎯 Icon Prefabs (loaded from accueil)")]
    public GameObject selectedXPrefab;
    public GameObject selectedOPrefab;

    [Header("🧾 UI Elements")]
    public TextMeshProUGUI turnText;
    public Image player1Icon;
    public Image player2Icon;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // Load selected prefabs
        selectedXPrefab = IconSelectionData.Instance.selectedXPrefab;
        selectedOPrefab = IconSelectionData.Instance.selectedOPrefab;

        // Show initial player turn
        UpdateTurnUI();
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
            LoadSceneVictoire();
        }
        else if (!gameIsOver && GridManager.Instance.countCoups == 27)
        {
            Debug.Log("Egalité !");
            LoadSceneEgalite();
        }
        else
        {
            SwitchPlayer();
        }
    }

    private void UpdateTurnUI()
    {
        if (turnText != null)
            turnText.text = $"Player {currentPlayer}'s Turn";

        if (player1Icon != null && player2Icon != null)
        {
            player1Icon.color = (currentPlayer == 1) ? Color.red : Color.gray;
            player2Icon.color = (currentPlayer == 2) ? Color.green : Color.gray;
        }
    }

    public void LoadSceneVictoire()
    {
        gameIsOver = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneVictoire);
    }

    public void LoadSceneEgalite()
    {
        gameIsOver = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneEgalite);
    }
}