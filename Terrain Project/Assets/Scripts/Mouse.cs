using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

    public GhostBuilding Ghost;
    public GhostForge gForge;
    public static Vector3 CurrentMousePoint;
    RaycastHit hit;

    private float raycastLength = 500;
	
	void Update () 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, raycastLength))
        {
            Debug.Log(hit.collider.name);
            if(hit.collider.name == "Terrain")
            {
                Ghost.Place = true;
                gForge.Place = true;
                CurrentMousePoint = hit.point;
            }
            else
            {
                Ghost.Place = false;
                gForge.Place = false;
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * raycastLength, Color.yellow);

	}
}
