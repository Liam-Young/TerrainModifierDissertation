using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float speed = 5.0f;
    public float zoomSpeed = 5.0f;

    public float minX = -360.0f;
    public float maxX = 360.0f;

    public float minY = -45.0f;
    public float maxY = 45.0f;

    public float sensX = 100.0f;
    public float sensY = 100.0f;

    float rotationY = 0.0f;
    float rotationX = 0.0f;

	void Update () 
    {
        //Moves camera right
        if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D)))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
        //Moves camera left
        if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.A)))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        
        //Moves camera up
        if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.W)))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
       
        //Moves camera down
        if ((Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.S)))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }


        //Scrolls camera
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);

        //Rotates the camera
        if (Input.GetMouseButton(2))
        {
            rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
	}
}
