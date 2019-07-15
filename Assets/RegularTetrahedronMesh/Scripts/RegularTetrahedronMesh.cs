using UnityEngine;

public class RegularTetrahedronMesh : MonoBehaviour
{
    [SerializeField] bool exportMesh = false;
    [SerializeField] Material material;

    void Start()
    {
        var filter = gameObject.AddComponent<MeshFilter>();
        filter.sharedMesh = CreateRegularTetrahedronMesh(); 

        var renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.sharedMaterial = material;

        if (exportMesh)
        {
            MeshExporter.Export(filter);
        }
    }

    Mesh CreateRegularTetrahedronMesh()
    {
        var mesh = new Mesh();

        mesh.vertices = new Vector3[]
        {
            new Vector3(0f, -1f, 0f),
            new Vector3(0f, 1f/3f, Mathf.Sqrt(8f)/3f),
            new Vector3( Mathf.Sqrt(8f)/(2f*Mathf.Sqrt(3f)), 1f/3f, -Mathf.Sqrt(8f)/6f),
            new Vector3(-Mathf.Sqrt(8f)/(2f*Mathf.Sqrt(3f)), 1f/3f, -Mathf.Sqrt(8f)/6f),
        };

        mesh.triangles = new int[]
        {
            0, 2, 1,
            0, 1, 3,
            0, 3, 2,
            1, 2, 3,
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        return mesh;
    }
}
