using UnityEngine;

[ExecuteInEditMode]
public class BoundingBoxCalculator : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // Obtiene el componente Renderer del objeto
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            // Obtiene y actualiza los límites actuales de la Bounding Box
            Bounds bounds = renderer.bounds;

            // Configura el color para el Gizmo
            Gizmos.color = Color.green;

            // Dibuja la Bounding Box en la escena
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
        else
        {
            Debug.LogWarning("El objeto no tiene un componente Renderer.");
        }
    }
}