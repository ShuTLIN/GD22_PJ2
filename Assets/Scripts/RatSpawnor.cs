using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawnor : MonoBehaviour
{
    public GameObject m_SpawnObj;

    private Mesh mesh;
    private Vector3[] vertices;

    private float minX=0.0f;
    private float maxX=0.0f;
    private float minY=0.0f;
    private float maxY=0.0f;
    private float minZ=0.0f;
    private float maxZ=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        for(int i=0;i< vertices.Length; i++) 
        {
            //Xaxis
            if (vertices[i].x < minX) 
            {
                minX = vertices[i].x;
            }
            if (vertices[i].x > maxX)
            {
                maxX = vertices[i].x;
            }

            //Yaxis
            if (vertices[i].y < minY)
            {
                minY = vertices[i].y;
            }
            if (vertices[i].y > maxY)
            {
                maxY = vertices[i].y;
            }

            //Zaxis
            if (vertices[i].z < minZ)
            {
                minZ = vertices[i].z;
            }
            if (vertices[i].z > maxZ)
            {
                maxZ = vertices[i].z;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localGenPos = new Vector3(Random.Range(minX, maxX), 0.0f, Random.Range(minZ, maxZ));
        localGenPos = transform.localToWorldMatrix * localGenPos;
        Instantiate(m_SpawnObj, localGenPos, Quaternion.identity);
    }
}
