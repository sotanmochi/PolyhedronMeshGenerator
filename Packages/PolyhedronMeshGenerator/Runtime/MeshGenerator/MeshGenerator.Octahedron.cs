using UnityEngine;

namespace PolyhedronMeshGenerator
{
    public partial class MeshGenerator
    {
        public static Mesh CreateOctahedron(float scaleFactor = 1f)
        {
            var mesh = new Mesh();
            mesh.name = "Octahedron";

            var vertices = new Vector3[6];
            vertices[0] = new Vector3(scaleFactor, 0f, 0f);
            vertices[1] = new Vector3(0f, scaleFactor, 0f);
            vertices[2] = new Vector3(0f, 0f, scaleFactor);
            vertices[3] = new Vector3(-scaleFactor, 0f, 0f);
            vertices[4] = new Vector3(0f, -scaleFactor, 0f);
            vertices[5] = new Vector3(0f, 0f, -scaleFactor);
            mesh.vertices = vertices;

            mesh.triangles = new int[]
            {
                0, 1, 2,
                0, 2, 4,
                0, 4, 5,
                0, 5, 1,
                3, 1, 5,
                3, 5, 4,
                3, 4, 2,
                3, 2, 1,
            };

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            return mesh;
        }
    }
}