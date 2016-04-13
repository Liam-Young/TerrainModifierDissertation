using UnityEngine;
using System.Collections;
using System.Linq;

public class changeTerrainTexture : MonoBehaviour {

    public Terrain myTerrain;

    public void MountainButton()
    {
        //THIS CREATES DEFAULT MOUNTAINOUS TERRAIN

        //Get a reference to the terrain data
        TerrainData terrainData = myTerrain.terrainData;

        //Array for splatmap data
        float[, ,] splatmapData = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];

        for (int y = 0; y < terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                //Normalise x/y coordinates to range 0-1 
                float y_01 = (float)y / (float)terrainData.alphamapHeight;
                float x_01 = (float)x / (float)terrainData.alphamapWidth;

                //Sample the height at a specific location
                float height = terrainData.GetHeight(Mathf.RoundToInt(y_01 * terrainData.heightmapHeight), Mathf.RoundToInt(x_01 * terrainData.heightmapWidth));

                //Calculate the normal of the terrain
                Vector3 normal = terrainData.GetInterpolatedNormal(y_01, x_01);

                //Calculate the steepness of the terrain
                float steepness = terrainData.GetSteepness(y_01, x_01);

                //Array for texture weights at a specific point
                float[] splatWeights = new float[terrainData.alphamapLayers];

                // THE BELOW RULES CHANGE THE EFFECTS THAT THE TEXTURES HAVE UPON THE TERRAIN

                //This has constant influence
                splatWeights[0] = 0.75f;

                //This is stronger at higher altitudes
                splatWeights[1] = Mathf.Clamp01((terrainData.heightmapHeight + height));

                //This is stronger on flatter terrain
                splatWeights[2] = 1.0f - Mathf.Clamp01(steepness * steepness / (terrainData.heightmapHeight / 5.0f));

                //This increases with height but only on the positive Z axis
                splatWeights[3] = height * Mathf.Clamp01(normal.z);

                //Normalise texture weights to add to 1
                float z = splatWeights.Sum();

                //Loop through each terrain texture
                for (int i = 0; i < terrainData.alphamapLayers; i++)
                {

                    //Normalize so that sum of all texture weights = 1
                    splatWeights[i] /= z;

                    //Assign this point to the splatmap array
                    splatmapData[x, y, i] = splatWeights[i];
                }
            }
        }

        //Assign the new splatmap to the terrainData:
        terrainData.SetAlphamaps(0, 0, splatmapData);
    }

    public void DesertButton()
    {
        //THIS CREATES DESERT TERRAIN

        //Get a reference to the terrain data
        TerrainData terrainData = myTerrain.terrainData;

        //Array for splatmap data
        float[, ,] splatmapData = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];

        for (int y = 0; y < terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                //Normalise x/y coordinates to range 0-1 
                float y_01 = (float)y / (float)terrainData.alphamapHeight;
                float x_01 = (float)x / (float)terrainData.alphamapWidth;

                //Sample the height at a specific location
                float height = terrainData.GetHeight(Mathf.RoundToInt(y_01 * terrainData.heightmapHeight), Mathf.RoundToInt(x_01 * terrainData.heightmapWidth));

                //Calculate the normal of the terrain
                Vector3 normal = terrainData.GetInterpolatedNormal(y_01, x_01);

                //Calculate the steepness of the terrain
                float steepness = terrainData.GetSteepness(y_01, x_01);

                //Array for texture weights at a specific point
                float[] splatWeights = new float[terrainData.alphamapLayers];

                // THE BELOW RULES CHANGE THE EFFECTS THAT THE TEXTURES HAVE UPON THE TERRAIN

                //This has constant influence
                splatWeights[6] = 0.75f;

                //This is stronger at higher altitudes
                splatWeights[7] = Mathf.Clamp01((terrainData.heightmapHeight + height));

                //This is stronger on flatter terrain
                splatWeights[4] = 1.0f - Mathf.Clamp01(steepness * steepness / (terrainData.heightmapHeight / 5.0f));

                //This increases with height but only on the positive Z axis
                splatWeights[5] = height * Mathf.Clamp01(normal.z);

                //Normalise texture weights to add to 1
                float z = splatWeights.Sum();

                //Loop through each terrain texture
                for (int i = 0; i < terrainData.alphamapLayers; i++)
                {

                    //Normalize so that sum of all texture weights = 1
                    splatWeights[i] /= z;

                    //Assign this point to the splatmap array
                    splatmapData[x, y, i] = splatWeights[i];
                }
            }
        }

        //Assign the new splatmap to the terrainData:
        terrainData.SetAlphamaps(0, 0, splatmapData);
    }

    public void DefaultButton()
    {
        //THIS CREATES DEFAULT MOUNTAINOUS TERRAIN

        //Get a reference to the terrain data
        TerrainData terrainData = myTerrain.terrainData;

        //Array for splatmap data
        float[, ,] splatmapData = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];

        for (int y = 0; y < terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                //Normalise x/y coordinates to range 0-1 
                float y_01 = (float)y / (float)terrainData.alphamapHeight;
                float x_01 = (float)x / (float)terrainData.alphamapWidth;

                //Sample the height at a specific location
                float height = terrainData.GetHeight(Mathf.RoundToInt(y_01 * terrainData.heightmapHeight), Mathf.RoundToInt(x_01 * terrainData.heightmapWidth));

                //Calculate the normal of the terrain
                Vector3 normal = terrainData.GetInterpolatedNormal(y_01, x_01);

                //Calculate the steepness of the terrain
                float steepness = terrainData.GetSteepness(y_01, x_01);

                //Array for texture weights at a specific point
                float[] splatWeights = new float[terrainData.alphamapLayers];

                // THE BELOW RULES CHANGE THE EFFECTS THAT THE TEXTURES HAVE UPON THE TERRAIN

                //This has constant influence
                splatWeights[0] = 0.75f;

                //Normalise texture weights to add to 1
                float z = splatWeights.Sum();

                //Loop through each terrain texture
                for (int i = 0; i < terrainData.alphamapLayers; i++)
                {

                    //Normalize so that sum of all texture weights = 1
                    splatWeights[i] /= z;

                    //Assign this point to the splatmap array
                    splatmapData[x, y, i] = splatWeights[i];
                }
            }
        }

        //Assign the new splatmap to the terrainData:
        terrainData.SetAlphamaps(0, 0, splatmapData);
    }
}
