using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GhostForge : MonoBehaviour
{

    bool Active = false;
    public bool Place = false;

    public GameObject ForgeG;
    public GhostBuilding houseG;
    public EventSystem eventSystem;

    public Transform forge;

    void Start()
    {
        ForgeG.SetActive(false);
    }

    void Update()
    {
        Debug.Log(Place);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Active = false;
            ForgeG.SetActive(false);

        }
        if (eventSystem.IsPointerOverGameObject())
        {

        }
        else
        {
            if (Active == true)
            {
                transform.position = new Vector3(Mouse.CurrentMousePoint.x, Mouse.CurrentMousePoint.y + 2, Mouse.CurrentMousePoint.z);
                if (Input.GetMouseButtonDown(0))
                {
                    if (Place == true)
                    {
                        Instantiate(forge, new Vector3(Mouse.CurrentMousePoint.x, Mouse.CurrentMousePoint.y, Mouse.CurrentMousePoint.z), Quaternion.identity);
                    }
                }
            }
        }
    }

    public void GhostActive()
    {
        Active = true;
        ForgeG.SetActive(true);
    }

    public void GhostOff()
    {
        ForgeG.SetActive(false);
    }
}
