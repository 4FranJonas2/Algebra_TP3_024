using System.Collections.Generic;
using UnityEngine;

public class NormalsAndMesh : MonoBehaviour
{
    // Lista de tri�ngulos que forman la geometr�a de la malla
    [SerializeField] private List<Poligon> triangles = new List<Poligon>();

    // Referencia al MeshFilter que contiene la informaci�n de la malla
    [SerializeField] private MeshFilter meshFilter;

    // Lista de planos generados a partir de los tri�ngulos de la malla
    [SerializeField] private List<Plane> planes = new List<Plane>();

    // Propiedad de solo lectura para acceder a la lista de tri�ngulos
    public List<Poligon> Triangles => triangles;

    // Propiedad de solo lectura para acceder al MeshFilter
    public MeshFilter MeshFilter => meshFilter;

    // Propiedad de solo lectura para acceder a la malla dentro del MeshFilter
    public Mesh Mesh => meshFilter.mesh;

    private void Awake()
    {
        // Obtiene el componente MeshFilter en el objeto hijo
        meshFilter = GetComponentInChildren<MeshFilter>();
        if (meshFilter == null) return; // Sale si no hay MeshFilter

        // Obtiene los v�rtices y tri�ngulos de la malla
        Vector3[] vertices = meshFilter.mesh.vertices;
        int[] meshTriangles = meshFilter.mesh.triangles;

        // Recorre los �ndices de los tri�ngulos en la malla, de tres en tres
        for (int i = 0; i < meshTriangles.Length; i += 3)
        {
            // Crea un nuevo tri�ngulo y asigna sus tres v�rtices
            Poligon triangle = new Poligon();
            triangle.SetVertices(
                vertices[meshTriangles[i]],
                vertices[meshTriangles[i + 1]],
                vertices[meshTriangles[i + 2]]
            );
            triangles.Add(triangle); // A�ade el tri�ngulo a la lista de tri�ngulos


            // Crea un plano a partir de los tres v�rtices y lo a�ade a la lista de planos
            planes.Add(new Plane(triangle.vertices[0], triangle.vertices[1], triangle.vertices[2]));
        }
    }

    // Dibuja un Gizmo para cada plano, �til para la visualizaci�n en el editor
    private void OnDrawGizmos()
    {
        planes.ForEach(plane => plane.DrawGizmo(transform));
    }

    // Verifica si un punto est� contenido dentro del modelo
    public bool ContainAPoint(Vector3 point)
    {
        // Itera sobre cada plano y verifica si el punto est� dentro del modelo
        foreach (var plane in planes)
        {
            // Calcula el vector desde el centro del plano hasta el punto
            //Vector3 toPoint = point - plane.Center;

            // Si el producto punto con la normal es negativo, el punto est� fuera del modelo
            // Dependiendo de la orientaci�n de las normales, la condici�n puede invertirse
            if (Vector3.Dot( plane.Normal, point) < 0)
                return false;
        }

        // Devuelve true si el punto est� dentro de todos los planos
        return true;
    }

}
