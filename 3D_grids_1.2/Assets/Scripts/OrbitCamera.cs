using UnityEngine;

/// <summary>
/// Ce script permet à la caméra de tourner autour d'une cible avec la souris.
/// À attacher à la Main Camera.
/// </summary>
public class OrbitCamera : MonoBehaviour
{
    public Transform target;        // Cible autour de laquelle la caméra tourne
    public float rotationSpeed = 5f;
    public float zoomSpeed = 10f;
    public float minDistance = 5f;
    public float maxDistance = 20f;

    private float distance = 10f;
    private float currentX = 0f;
    private float currentY = 0f;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("🚨 OrbitCamera : Aucun target assigné !");
        }
        distance = Vector3.Distance(transform.position, target.position);
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Rotation avec clic droit
        if (Input.GetMouseButton(1)) // clic droit
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            currentY = Mathf.Clamp(currentY, -80, 80); // Limite la rotation verticale
        }

        // Zoom avec la molette
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Calcul de la position de la caméra
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = new Vector3(0, 0, -distance);
        transform.position = target.position + rotation * direction;
        transform.LookAt(target);
    }
}
