using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GhostBuilding : MonoBehaviour {

    bool Active = false;
    public bool Place = false;

    public GameObject HouseG;
    public GhostForge gForge;
    public EventSystem eventSystem;

    public Transform house;

    void Start()
    {
        HouseG.SetActive(false);

    }

	void Update () 
    {
        Debug.Log(Place);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Active = false;
            HouseG.SetActive(false);

        }
        if (eventSystem.IsPointerOverGameObject())
        {

        }
        else
        {
            if (Active == true)
            {
                transform.position = new Vector3(Mouse.CurrentMousePoint.x, Mouse.CurrentMousePoint.y + 6, Mouse.CurrentMousePoint.z);
                if (Input.GetMouseButtonDown(0))
                {
                    if (Place == true)
                    {
                        Instantiate(house, new Vector3(Mouse.CurrentMousePoint.x, Mouse.CurrentMousePoint.y + 8.5f, Mouse.CurrentMousePoint.z), Quaternion.identity);
                    }
                }
            }
        }
	}

    public void GhostActive()
    {
        Active = true;
        HouseG.SetActive(true);
    }

    public void GhostOff()
    {
        HouseG.SetActive(false);
    }
}
