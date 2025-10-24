using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gère l’ensemble de la grille 3D (3x3x3)
/// - Initialise les cases
/// - Stocke l’état du jeu dans un tableau 3D
/// - Fournit les outils pour vérifier les conditions de victoire, égalité, etc.
/// </summary>
public class GridManager : MonoBehaviour
{
    // === [🧠 Singleton] ===
    public static GridManager Instance;

    // === [📦 Références manuelles aux 27 cases (dans l’ordre)] ===
    public GridSpaceController[] cellObjects = new GridSpaceController[27]; // assign manually in Inspector

    // === [🔢 Représentation logique de la grille] ===
    // Valeurs : 0 = vide, 1 = X, 2 = O
    public int[,,] grid = new int[3, 3, 3];

    // On initialise une variable qui comptera les coups joués 
    public int countCoups = 0;

    // === [⚙️ Mise en place du Singleton] ===
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // === [🧩 Initialisation de la grille] ===
    private void Start()
    {
        AssignGrid(); // Associe chaque case à une position 3D + vide le tableau
    }

    /// <summary>
    /// Attribue à chaque cellule sa position (x, y, z) et initialise les états à vide (0)
    /// </summary>
    void AssignGrid()
    {
        for (int i = 0; i < cellObjects.Length; i++)
        {
            int x = i % 3;
            int y = (i / 3) % 3;
            int z = i / 9;

            cellObjects[i].Init(x, y, z);    // Attribue la position dans GridSpace
            grid[x, y, z] = 0;               // Initialise à vide
        }
    }

    /// <summary>
    /// Met à jour l'état d'une case après un coup joué
    /// </summary>
    public void SetState(int x, int y, int z, int value)
    {
        grid[x, y, z] = value;
        countCoups +=1;
    }

    /// <summary>
    /// Vérifie s’il y a une condition de victoire
    /// </summary>
    public bool CheckWin()
    {
        int p = GameManager.Instance.GetCurrentPlayer();

        if (countCoups == 27)
            return false; // Match nul

        // Lignes (X)
        for (int z = 0; z < 3; z++)
        {
            for (int y = 0; y < 3; y++)
            {
                int victoire = 0;
                for (int x = 0; x < 3; x++)
                    if (grid[x, y, z] == p) victoire++;

                if (victoire == 3) return true;
            }
        }

        // Colonnes (Y)
        for (int z = 0; z < 3; z++)
        {
            for (int x = 0; x < 3; x++)
            {
                int victoire = 0;
                for (int y = 0; y < 3; y++)
                    if (grid[x, y, z] == p) victoire++;

                if (victoire == 3) return true;
            }
        }

        // Profondeurs (Z)
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                int victoire = 0;
                for (int z = 0; z < 3; z++)
                    if (grid[x, y, z] == p) victoire++;

                if (victoire == 3) return true;
            }
        }

        // Diagonales sur chaque plan XY (z fixe)
        for (int z = 0; z < 3; z++)
        {
            if (grid[0, 0, z] == p && grid[1, 1, z] == p && grid[2, 2, z] == p) return true;
            if (grid[0, 2, z] == p && grid[1, 1, z] == p && grid[2, 0, z] == p) return true;
        }

        // Diagonales sur chaque plan XZ (y fixe)
        for (int y = 0; y < 3; y++)
        {
            if (grid[0, y, 0] == p && grid[1, y, 1] == p && grid[2, y, 2] == p) return true;
            if (grid[0, y, 2] == p && grid[1, y, 1] == p && grid[2, y, 0] == p) return true;
        }

        // Diagonales sur chaque plan YZ (x fixe)
        for (int x = 0; x < 3; x++)
        {
            if (grid[x, 0, 0] == p && grid[x, 1, 1] == p && grid[x, 2, 2] == p) return true;
            if (grid[x, 0, 2] == p && grid[x, 1, 1] == p && grid[x, 2, 0] == p) return true;
        }

        // Diagonales 3D
        if (grid[0, 0, 0] == p && grid[1, 1, 1] == p && grid[2, 2, 2] == p) return true;
        if (grid[0, 0, 2] == p && grid[1, 1, 1] == p && grid[2, 2, 0] == p) return true;
        if (grid[0, 2, 0] == p && grid[1, 1, 1] == p && grid[2, 0, 2] == p) return true;
        if (grid[0, 2, 2] == p && grid[1, 1, 1] == p && grid[2, 0, 0] == p) return true;

        return false;
    }
    
    /// <summary>
    /// Donne l'état actuel d'une case donnée (utile pour vérification)
    /// </summary>
    public int GetState(int x, int y, int z)
    {
        return grid[x, y, z];
    }
}



