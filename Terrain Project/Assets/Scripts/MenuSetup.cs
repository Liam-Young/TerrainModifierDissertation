using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuSetup : MonoBehaviour {

    public static List<Texture2D> BuildingIconTextures = new List<Texture2D>();
    public static List<Texture2D> BuildingIconTexturesMO = new List<Texture2D>();
    public static List<string> BuildingNames = new List<string>();
    public static List<string> BuildingPaths = new List<string>();

    public Texture2D IconContainer;

    public GameObject HeightCanvas;
    public GameObject TextureCanvas;
    public GameObject BuildingCanvas;
    public changeTerrainHeight heightScript;
    public GhostBuilding ghost;
    public GhostForge gForge;

    public void terrainHeightButton()
    {
        HeightCanvas.SetActive(true);
        TextureCanvas.SetActive(false);
        BuildingCanvas.SetActive(false);
        Debug.Log("Height");
        heightScript.terrainModify = true;
        ghost.HouseG.SetActive(false);
        gForge.ForgeG.SetActive(false);
    }
     
    public void TerrainTextureButton()
    {
        HeightCanvas.SetActive(false);
        TextureCanvas.SetActive(true);
        BuildingCanvas.SetActive(false);
        Debug.Log("Texture");
        heightScript.terrainModify = false;
        ghost.HouseG.SetActive(false);
        gForge.ForgeG.SetActive(false);
    }

    public void BuildingAddButton()
    {
        HeightCanvas.SetActive(false);
        TextureCanvas.SetActive(false);
        BuildingCanvas.SetActive(true);
        heightScript.terrainModify = false;
        ghost.HouseG.SetActive(false);
        gForge.ForgeG.SetActive(false);
    }
}
