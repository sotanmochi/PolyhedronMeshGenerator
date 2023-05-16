using UnityEditor;
using UnityEngine;

namespace PolyhedronMeshGenerator.Editor
{
    public static class MeshExporterMenu
    {
        [MenuItem("PolyhedronMeshGenerator/Export Obj File/Tetrahedron Mesh")]
        public static void ExportTetrahedronMeshToObj()
        {
            var mesh = MeshGenerator.CreateTetrahedron(1.0f);
            var meshExporter = new MeshExporter(new ObjSerializer());
            meshExporter.ExportAsync(Application.streamingAssetsPath, "Tetrahedron.obj", mesh);
            Debug.Log($"[{nameof(PolyhedronMeshGenerator)}] Exported Tetrahedron.obj to {Application.streamingAssetsPath}");
        }

        [MenuItem("PolyhedronMeshGenerator/Export Obj File/Octahedron Mesh")]
        public static void ExportOctahedronMeshToObj()
        {
            var mesh = MeshGenerator.CreateOctahedron(1.0f);
            var meshExporter = new MeshExporter(new ObjSerializer());
            meshExporter.ExportAsync(Application.streamingAssetsPath, "Octahedron.obj", mesh);
            Debug.Log($"[{nameof(PolyhedronMeshGenerator)}] Exported Octahedron.obj to {Application.streamingAssetsPath}");
        }

        [MenuItem("PolyhedronMeshGenerator/Export Obj File/Icosahedron Mesh")]
        public static void ExportIcosahedronMeshToObj()
        {
            var mesh = MeshGenerator.CreateIcosahedron(0.5f);
            var meshExporter = new MeshExporter(new ObjSerializer());
            meshExporter.ExportAsync(Application.streamingAssetsPath, "Icosahedron.obj", mesh);
            Debug.Log($"[{nameof(PolyhedronMeshGenerator)}] Exported Icosahedron.obj to {Application.streamingAssetsPath}");
        }
    }
}