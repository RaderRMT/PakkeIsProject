using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace WaterAndFloating
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class Waves : MonoBehaviour
    {
        //variables
        [Header("Parameters"), SerializeField] private int _dimension = 10;
        [SerializeField] private float _UVScale = 2f;
        [SerializeField] private Transform _waterPlacing;

        public List<Transform> PlayerTransforms;

        //mesh
        private MeshFilter _meshFilter;
        private Mesh _mesh;
        private List<Vector3> _vertices = new List<Vector3>();

        private void Start()
        {
            //mesh generation
            _meshFilter = GetComponent<MeshFilter>();
            _mesh = _meshFilter.mesh;
            _mesh.name = gameObject.name;
            _mesh.indexFormat = IndexFormat.UInt32;
            
            _mesh.vertices = GenerateVertices();
            _mesh.triangles = GenerateTriangles();
            _mesh.uv = GenerateUVs();
            _mesh.RecalculateNormals();
            _mesh.RecalculateBounds();
            _mesh.GetVertices(_vertices);
            
            //position & scale
            Transform wavePlacing = _waterPlacing;
            Transform t = transform;
            Vector3 position = wavePlacing.position;
            Vector3 scale = wavePlacing.localScale;
            t.position = position;
            t.localScale = scale;
        }

        private Vector3[] GenerateVertices()
        {
            Vector3[] vertices = new Vector3[(_dimension + 1) * (_dimension + 1)];

            //equally distribute verts
            for (int x = 0; x <= _dimension; x++)
            {
                for (int z = 0; z <= _dimension; z++)
                {
                    vertices[Index(x, z)] = new Vector3(x, 0, z);
                }
            }

            return vertices;
        }

        private int[] GenerateTriangles()
        {
            int[] triangles = new int[_mesh.vertices.Length * 6];

            //two triangles are one tile
            for (int x = 0; x < _dimension; x++)
            {
                for (int z = 0; z < _dimension; z++)
                {
                    //(0,0) -> (1,1) -> (1,0) -> (0,0) -> (0,1) -> (1,1)
                    triangles[Index(x, z) * 6 + 0] = Index(x, z); 
                    triangles[Index(x, z) * 6 + 1] = Index(x + 1, z + 1); 
                    triangles[Index(x, z) * 6 + 2] = Index(x + 1, z); 
                    triangles[Index(x, z) * 6 + 3] = Index(x, z); 
                    triangles[Index(x, z) * 6 + 4] = Index(x, z + 1); 
                    triangles[Index(x, z) * 6 + 5] = Index(x + 1, z + 1);
                }
            }

            return triangles;
        }

        private Vector2[] GenerateUVs()
        {
            Vector2[] uvs = new Vector2[_mesh.vertices.Length];

            //always set one uv over n tiles than flip the uv and set it again
            for (int x = 0; x <= _dimension; x++)
            {
                for (int z = 0; z <= _dimension; z++)
                {
                    Vector2 vector = new Vector2((x / _UVScale) % 2, (z / _UVScale) % 2);
                    uvs[Index(x, z)] = new Vector2(vector.x <= 1 ? vector.x : 2 - vector.x, vector.y <= 1 ? vector.y : 2 - vector.y);
                }
            }

            return uvs;
        }

        private int Index(float x, float z)
        {
            int index = (int)x * (_dimension + 1) + (int)z;
            return index;
        }
    }
}