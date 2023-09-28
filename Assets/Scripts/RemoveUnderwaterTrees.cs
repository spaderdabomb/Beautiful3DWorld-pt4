using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveUnderwaterTrees : MonoBehaviour
{
    public Terrain terrain;
    public float waterLevel = 20.0f;

    public void RemoveTreesUnderWater()
    {
        TerrainData terrainData = terrain.terrainData;
        TreeInstance[] treeInstances = terrainData.treeInstances;
        List<TreeInstance> updatedTreeInstances = new List<TreeInstance>();

        foreach (TreeInstance treeInstance in treeInstances)
        {
            Vector3 treePosition = Vector3.Scale(treeInstance.position, terrainData.size) + terrain.transform.position;

            if (treePosition.y >= waterLevel)
            {
                updatedTreeInstances.Add(treeInstance);
            }
        }

        terrainData.treeInstances = updatedTreeInstances.ToArray();
    }
}
