using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class changeTerrainHeight : MonoBehaviour {

    public Terrain myTerrain;
    private TerrainData tData;
    private int heightmapWidth;
    private int heightmapHeight;
    private float[,] heights;
    public float strength = 0.001f;
    public int area = 10;
    public bool terrainModify = false;
    public Slider sliderStrength;
    public Slider sliderArea;
    public Text textStrength;
    public Text textArea;
    public EventSystem eventSystem;

    void Start()
    {
        //Setup for the terrain heightmap
        tData = myTerrain.terrainData;
        heightmapWidth = tData.heightmapWidth;
        heightmapHeight = tData.heightmapHeight;
        heights = tData.GetHeights(0, 0, heightmapWidth, heightmapHeight);

        //Setup for the listeners on the sliders
        sliderStrength.onValueChanged.AddListener(delegate { ValueChangeStrength(); });
        sliderArea.onValueChanged.AddListener(delegate { ValueChangeArea(); });
    }

    void Update()
    {
        //Output to text for strength slider
        float textStr;
        textStr = strength * 1000;
        textStrength.text = textStr.ToString();

        //Output to text for area slider
        int textAr;
        textAr = area - 9;
        textArea.text = textAr.ToString();

        //Prevents the raycast going through the UI
        if (eventSystem.IsPointerOverGameObject())
        {

        }
        else
        {
            //Controls the raycast from the mouse using the camera
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (terrainModify == true)
            {
                //Terrain raise
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.name == "Terrain")
                            {
                                lowerTerrain(hit.point);
                            }
                        }
                    }
                }
                else
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.name == "Terrain")
                            {
                                raiseTerrain(hit.point);
                            }
                        }
                    }
                }
            }
        }
    }

    private void raiseTerrain(Vector3 point)
    {
        int terX = (int)((point.x / myTerrain.terrainData.size.x) * heightmapWidth);
        int terZ = (int)((point.z / myTerrain.terrainData.size.z) * heightmapHeight);
        float[,] height = myTerrain.terrainData.GetHeights(terX - area/2, terZ - area/2, area, area);  //new float[1,1];

        for (int tempY = 0; tempY < area; tempY++)
            for (int tempX = 0; tempX < area; tempX++)
            {
                float dist_to_target = Mathf.Abs((float)tempY - area/2) + Mathf.Abs((float)tempX - area/2);
                float maxDist = area - 1;
                float proportion = dist_to_target / maxDist;

                height[tempX, tempY] += strength * (1f - proportion);
                heights[terX - area/2 + tempX, terZ - area/2 + tempY] += strength * (1f - proportion);
            }

        myTerrain.terrainData.SetHeights(terX - area/2, terZ - area/2, height);
    }

    private void lowerTerrain(Vector3 point)
    {
        int terX = (int)((point.x / myTerrain.terrainData.size.x) * heightmapWidth);
        int terZ = (int)((point.z / myTerrain.terrainData.size.z) * heightmapHeight);
        float[,] height = myTerrain.terrainData.GetHeights(terX - area / 2, terZ - area / 2, area, area);  //new float[1,1];

        for (int tempY = 0; tempY < area; tempY++)
            for (int tempX = 0; tempX < area; tempX++)
            {
                float dist_to_target = Mathf.Abs((float)tempY - area / 2) + Mathf.Abs((float)tempX - area / 2);
                float maxDist = area - 1;
                float proportion = dist_to_target / maxDist;

                height[tempX, tempY] -= strength * (1f - proportion);
                heights[terX - area / 2 + tempX, terZ - area / 2 + tempY] -= strength * (1f - proportion);
            }

        myTerrain.terrainData.SetHeights(terX - area / 2, terZ - area / 2, height);
    }

    //public void terrainButton()
    //{
    //    if(terrainModify == false)
    //    {
    //        terrainModify = true;
    //    }
    //    else if (terrainModify == true)
    //    {
    //        terrainModify = false;
    //    }
    //}

    public void ValueChangeStrength()
    {
        strength = sliderStrength.value;
    }

    public void ValueChangeArea()
    {
        area = (int)sliderArea.value;
    }
}
