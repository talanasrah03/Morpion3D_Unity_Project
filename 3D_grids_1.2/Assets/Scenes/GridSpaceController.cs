using UnityEngine;

/// <summary>
/// Contrôleur d'une cellule de la grille de jeu (case jouable)
/// Gère l'état de la case, l'apparence initiale, et l'ajout du pion lors d'un clic
/// </summary>
public class GridSpaceController : MonoBehaviour
{
    // === [ Apparence de la case] ===
    public Material emptyMat;                // Matériau de base (case vide)

    private Renderer rend;                   // Pour changer le matériau de la case
    public int state = 0;                    // État de la case : 0 = vide, 1 = X, 2 = O

    // === [📍 Position de la case dans la grille 3D] ===
    public int x, y, z;

    // === [🔁 Initialisation au lancement] ===
    private void Start()
    {
        rend = GetComponent<Renderer>();     // Récupération du Renderer
        rend.material = emptyMat;            // Applique le matériau vide
    }

    /// <summary>
    /// Initialisation de la position dans la grille (appelée par GridManager)
    /// </summary>
    public void Init(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    /// <summary>
    /// Gestion du clic sur la case par le joueur
    /// </summary>
    private void OnMouseDown()
    {
        // [🚫] Ne rien faire si la case est déjà occupée
        if (state != 0) return;

        // [🎮] Récupération du joueur actuel
        int player = GameManager.Instance.GetCurrentPlayer();

        // [📌] Position d’apparition du pion
        Vector3 spawnPos = transform.position + new Vector3(0, 0.1f, 0);

        GameObject mark = null; // Référence au pion instancié

        // === [❌ Joueur 1 : X] ===
        if (player == 1)
        {
            mark = Instantiate(GameManager.Instance.selectedXPrefab, spawnPos, Quaternion.Euler(90f, 0f, 0f));
            state = 1;
        }
        // === [⭕ Joueur 2 : O] ===
        else
        {
            mark = Instantiate(GameManager.Instance.selectedOPrefab, spawnPos, Quaternion.Euler(0f, 0f, 0f));
            state = 2;
        }

        // [📎] Attache le pion à la case (dans la hiérarchie Unity)
        mark.transform.SetParent(transform);

        // === [📊 Mise à jour de la grille dans GridManager] ===
        GridManager.Instance.SetState(x, y, z, state);

        // === [⏭️ Fin du tour] ===
        GameManager.Instance.PlayerMadeMove();
    }

    /// <summary>
    /// Permet aux autres scripts de connaître l’état de la case
    /// </summary>
    public int GetState()
    {
        return state;
    }
}
