using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace PolyhedronMeshGenerator
{
	public class MeshExporter
	{
		private readonly ISerializer _serializer;

		public MeshExporter(ISerializer serializer)
		{
			_serializer = serializer;
		}

		public async Task ExportAsync(string directoryPath, string filename, Mesh mesh)
		{
			var meshName = mesh.name;
			var vertices = mesh.vertices;
			var triangles = mesh.triangles;
			var normals = mesh.normals;

			var serializedData = _serializer.Serialize(meshName, vertices, triangles, normals);

			await SaveFileAsync(directoryPath, filename, serializedData);
		}

		public async Task SaveFileAsync(string directoryPath, string filename, byte[] data)
		{
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}

			var filepath = Path.Combine(directoryPath, filename);

			using (var fs = new FileStream(filepath, FileMode.OpenOrCreate))
			{
				await fs.WriteAsync(data, 0, data.Length);
			}
		}
	}	
}