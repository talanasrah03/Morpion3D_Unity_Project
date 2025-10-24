using UnityEngine;

/// <summary>
/// 🎥 Script OrbitCamera
/// Permet de faire tourner la caméra autour d'un objet (souvent le centre du plateau de jeu)
/// avec la souris. Le joueur peut aussi zoomer avec la molette.
/// À attacher à la caméra principale (Main Camera).
/// </summary>
public class OrbitCamera : MonoBehaviour
{
    [Header("🔗 Cible à suivre")]
    public Transform target; // L’objet autour duquel la caméra tourne (souvent un empty centré sur la grille)

    [Header("🎮 Contrôles de rotation")]
    public float rotationSpeed = 5f; // Vitesse de rotation à la souris
    public float zoomSpeed = 10f;    // Vitesse de zoom avec la molette

    [Header("📏 Limites de zoom")]
    public float minDistance = 5f;   // Zoom minimum
    public float maxDistance = 20f;  // Zoom maximum

    private float distance = 10f;    // Distance actuelle par rapport à la cible
    private float currentX = 0f;     // Rotation horizontale autour de la cible
    private float currentY = 6f;    // 🔁 Inclinaison verticale (vue plus ou moins plongeante)

    /// <summary>
    /// 🟢 Initialisation de la caméra
    /// </summary>
    void Start()
    {
        if (target == null)
        {
            Debug.LogError("🚨 OrbitCamera : Aucun target assigné !");
            return;
        }

        // Calcule la distance initiale entre la caméra et la cible
        distance = Vector3.Distance(transform.position, target.position);

        // Applique la position initiale de la caméra (vue légèrement de haut)
        UpdateCameraPosition();
    }

    /// <summary>
    /// 🔁 S'exécute à la fin de chaque frame (après tous les mouvements)
    /// </summary>
    void LateUpdate()
    {
        if (target == null) return;

        // 🔄 Rotation avec clic droit (bouton droit de la souris)
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;

            // Empêche la caméra de pivoter à l’envers
            currentY = Mathf.Clamp(currentY, -80f, 80f);
        }

        // 🔍 Zoom avec la molette de la souris
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // 🧭 Repositionne la caméra
        UpdateCameraPosition();
    }

    /// <summary>
    /// 🔧 Calcule et applique la position de la caméra en fonction de l'angle et de la distance
    /// </summary>
    void UpdateCameraPosition()
    {
        // Calcule la rotation de la caméra autour de la cible
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // Calcule le déplacement en arrière (car la caméra regarde vers la cible depuis derrière)
        Vector3 direction = new Vector3(0, 0, -distance);

        // Applique la position finale
        transform.position = target.position + rotation * direction;

        // Oriente la caméra vers la cible
        transform.LookAt(target);
    }
}
