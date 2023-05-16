using UnityEngine;

namespace PolyhedronMeshGenerator
{
	public class ObjSerializer : ISerializer
	{
		public byte[] Serialize(string meshName, Vector3[] vertices, int[] triangles)
		{
			var offset = 0;
			var objTextBuilder = new System.Text.StringBuilder();

			objTextBuilder.Append($"# {meshName}.obj exported by PolyhedronMeshGenerator\n");
			objTextBuilder.AppendFormat($"g {meshName}\n");

			for (var i = 0; i < vertices.Length; i++)
			{
				objTextBuilder.AppendFormat("v {0} {1} {2}\n", vertices[i].x, vertices[i].y, vertices[i].z);
			}

			for (var i = 0; i < triangles.Length; i += 3)
			{
				objTextBuilder.AppendFormat("f {0} {1} {2}\n",
					triangles[i + 0] + 1 + offset,
					triangles[i + 1] + 1 + offset,
					triangles[i + 2] + 1 + offset);
			}

			return System.Text.Encoding.ASCII.GetBytes(objTextBuilder.ToString());
		}

		public byte[] Serialize(string meshName, Vector3[] vertices, int[] triangles, Vector3[] normals)
		{
			var offset = 0;
			var objTextBuilder = new System.Text.StringBuilder();

			objTextBuilder.Append($"# {meshName}.obj exported by PolyhedronMeshGenerator\n");
			objTextBuilder.Append($"g {meshName}\n");

			objTextBuilder.Append($"# Vertices\n");
			for (var i = 0; i < vertices.Length; i++)
			{
				objTextBuilder.AppendFormat("v {0} {1} {2}\n", vertices[i].x, vertices[i].y, vertices[i].z);
			}

			objTextBuilder.Append($"# Vertex normals\n");
			for (var i = 0; i < vertices.Length; i++)
			{
				objTextBuilder.AppendFormat("vn {0} {1} {2}\n", normals[i].x, normals[i].y, normals[i].z);
			}

			objTextBuilder.Append($"# Triangles\n");
			for (var i = 0; i < triangles.Length; i += 3)
			{
				objTextBuilder.AppendFormat("f {0} {1} {2}\n",
					triangles[i + 0] + 1 + offset,
					triangles[i + 1] + 1 + offset,
					triangles[i + 2] + 1 + offset);
			}

			return System.Text.Encoding.ASCII.GetBytes(objTextBuilder.ToString());
		}
    }
}