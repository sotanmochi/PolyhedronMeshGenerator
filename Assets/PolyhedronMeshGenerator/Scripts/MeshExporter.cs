using System;
using System.IO;
using System.Text;
using UnityEngine;

public static class MeshExporter
{
    public static void Export(MeshFilter meshFilter)
    {
        string dirpath = Application.streamingAssetsPath + "/Mesh";
        string dateTimeStr = DateTime.Now.ToString("yyyyMMddHHmmss");

        byte[] serialized = SerializeAsObjFormat(meshFilter.sharedMesh.vertices, meshFilter.sharedMesh.triangles);
		string filename = "Mesh_" + dateTimeStr + ".obj";
        SaveByteData(dirpath, filename, serialized);

    }

    async static void SaveByteData(string dirpath, string filename, byte[] data)
    {
        if(!Directory.Exists(dirpath))
        {
            Directory.CreateDirectory(dirpath);
        }

        string filepath = dirpath + "/" + filename;

        using(var fs = new FileStream(filepath, FileMode.OpenOrCreate))
        {
            await fs.WriteAsync(data, 0, data.Length);
        }
    }

    static byte[] SerializeAsObjFormat(Vector3[] vertices, int[] triangles)
	{
		StringBuilder objTextBuilder = new StringBuilder();
		int offset = 0;
		int count = 0;

		objTextBuilder.AppendFormat("o object.{0}\n", ++count);
		foreach(var vertex in vertices)
		{
			objTextBuilder.AppendFormat("v {0} {1} {2}\n", vertex.x, vertex.y, vertex.z);
		}

		objTextBuilder.Append("\n");

		for (int i = 0; i < triangles.Length; i += 3)
		{
			objTextBuilder.AppendFormat("f {0} {1} {2}\n",
				triangles[i + 0] + 1 + offset,
				triangles[i + 1] + 1 + offset,
				triangles[i + 2] + 1 + offset);
		}

		objTextBuilder.Append("\n\n");

		return System.Text.Encoding.ASCII.GetBytes(objTextBuilder.ToString());
	}
}
