using UnityEngine;

public class Grid3d : MonoBehaviour
{
    public GameObject pointPrefab; // Prefab del punto (puede ser una esfera, cubo, etc.)
    public int gridSizeX = 10;     // Tamaño de la grilla en X
    public int gridSizeY = 10;     // Tamaño de la grilla en Y
    public int gridSizeZ = 10;     // Tamaño de la grilla en Z
    public float spacing = 30.0f;   // Espaciado entre los puntos

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    // Calcular la posición de cada punto en el espacio
                    Vector3 position = new Vector3(x * spacing, y * spacing, z * spacing);

                    // Instanciar el punto en la escena
                    Instantiate(pointPrefab, position, Quaternion.identity);
                }
            }
        }
    }
}
