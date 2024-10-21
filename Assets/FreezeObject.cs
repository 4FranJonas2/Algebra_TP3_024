using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeObject : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    void Start()
    {
        // Guardar la posición, rotación y escala iniciales
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialScale = transform.localScale;
    }

    void LateUpdate()
    {
        // Restaurar la posición, rotación y escala en cada frame
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        transform.localScale = initialScale;
    }
}
