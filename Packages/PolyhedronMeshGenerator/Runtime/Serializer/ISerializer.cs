using UnityEngine;

namespace PolyhedronMeshGenerator
{
    public interface ISerializer
    {
        byte[] Serialize(string meshName, Vector3[] vertices, int[] triangles);
        byte[] Serialize(string meshName, Vector3[] vertices, int[] triangles, Vector3[] normals);
    }
}