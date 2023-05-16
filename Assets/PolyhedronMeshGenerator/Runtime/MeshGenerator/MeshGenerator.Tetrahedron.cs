using UnityEngine;

namespace PolyhedronMeshGenerator
{
    public partial class MeshGenerator
    {
        public static Mesh CreateTetrahedron(float scaleFactor = 1f)
        {
            var mesh = new Mesh();
            mesh.name = "Tetrahedron";

            var vertices = new Vector3[4];
            vertices[0] = new Vector3(0f, -1f, 0f) * scaleFactor;
            vertices[1] = new Vector3(0f, (1f / 3f), Mathf.Sqrt(8f) / 3f) * scaleFactor;
            vertices[2] = new Vector3( Mathf.Sqrt(8f) / (2f * Mathf.Sqrt(3f)), 1f / 3f, -Mathf.Sqrt(8f) / 6f) * scaleFactor;
            vertices[3] = new Vector3(-Mathf.Sqrt(8f) / (2f * Mathf.Sqrt(3f)), 1f / 3f, -Mathf.Sqrt(8f) / 6f) * scaleFactor;
            mesh.vertices = vertices;

            mesh.triangles = new int[]
            {
                0, 2, 1,
                0, 1, 3,
                0, 3, 2,
                1, 2, 3,
            };

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            return mesh;
        }
    }
}