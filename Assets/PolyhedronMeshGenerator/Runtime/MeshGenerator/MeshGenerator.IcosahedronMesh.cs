using UnityEngine;

namespace PolyhedronMeshGenerator
{
    public partial class MeshGenerator
    {
        // References:
        //  - https://en.wikipedia.org/wiki/Regular_icosahedron
        //  - http://blog.andreaskahler.com/2009/06/creating-icosphere-mesh-in-code.html
        public static Mesh CreateIcosahedron(float scaleFactor = 0.5f)
        {
            var mesh = new Mesh();
            mesh.name = "Icosahedron";

            var phi = (1f + Mathf.Sqrt(5f)) / 2f;

            var vertices = new Vector3[12];
            vertices[0]  = new Vector3(-1f,  phi, 0f) * scaleFactor;
            vertices[1]  = new Vector3( 1f,  phi, 0f) * scaleFactor;
            vertices[2]  = new Vector3(-1f, -phi, 0f) * scaleFactor;
            vertices[3]  = new Vector3( 1f, -phi, 0f) * scaleFactor;
            vertices[4]  = new Vector3( 0f, -1f,  phi) * scaleFactor;
            vertices[5]  = new Vector3( 0f,  1f,  phi) * scaleFactor;
            vertices[6]  = new Vector3( 0f, -1f, -phi) * scaleFactor;
            vertices[7]  = new Vector3( 0f,  1f, -phi) * scaleFactor;
            vertices[8]  = new Vector3( phi, 0f, -1f) * scaleFactor;
            vertices[9]  = new Vector3( phi, 0f,  1f) * scaleFactor;
            vertices[10] = new Vector3(-phi, 0f, -1f) * scaleFactor;
            vertices[11] = new Vector3(-phi, 0f,  1f) * scaleFactor;
            mesh.vertices = vertices;

            mesh.triangles = new int[]
            {
                0, 11, 5,
                0, 5, 1,
                0, 1, 7,
                0, 7, 10,
                0, 10, 11,
                1, 5, 9,
                5, 11, 4,
                11, 10, 2,
                10, 7, 6,
                7, 1, 8,
                3, 9, 4,
                3, 4, 2,
                3, 2, 6,
                3, 6, 8,
                3, 8, 9,
                4, 9, 5,
                2, 4, 11,
                6, 2, 10,
                8, 6, 7,
                9, 8, 1,
            };

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            return mesh;
        }
    }
}