using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    public Terrain terrain;
    public Mesh treeMesh;
    public Material treeMaterial;
    public int instanceCount = 100;
    public float maxSteepness = 30f;
    public float treeScale = 1f;

    private Matrix4x4[] TRS_Matrices;

    void Start()
    {
        TRS_Matrices = new Matrix4x4[instanceCount];
        for (int i = 0; i < instanceCount; i++)
        {
            float x = Random.Range(250, 450);
            float z = Random.Range(150, 350);

            float steepness = terrain.terrainData.GetSteepness(x, z);
            if (steepness > maxSteepness)
            {
                // Если уклон слишком большой, дерево не ставим
                i--;
                continue;
            }

            float y = terrain.SampleHeight(new(x, 0, z));
            Vector3 pos = new(x, y, z);

            float randomAngle = Random.Range(0f, 360f);
            Quaternion rotation = Quaternion.Euler(0, randomAngle, 0);

            TRS_Matrices[i] = Matrix4x4.TRS(pos, rotation, Vector3.one * treeScale);
        }
    }

    void Update()
    {
        // Рисуем деревья на GPU
        Graphics.DrawMeshInstanced(treeMesh, 0, treeMaterial, TRS_Matrices);
    }
}