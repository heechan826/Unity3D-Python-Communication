/*
code from: https://www.gamedeveloper.com/programming/rotate-zoom-and-move-your-camera-with-your-mouse-in-unity3d 
*/

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseControl : MonoBehaviour {

public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 20F;
    public float sensitivityY = 20F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -90F;
    public float maximumY = 90F;
    float rotationY = -60F;

    // For camera movement
    float CameraPanningSpeed = 10.0f;

    [SerializeField] Texture2D handImg, cursorImg;

    void Update()
    {
        MouseInput();
    }

    void MouseInput()
    {
        /*
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
            //MouseLeftClick()
        }
        */

        if (Input.GetMouseButton(0)) //Left click(마우스 왼쪽 버튼을 누르는중의 처리)
        {
        }
        else if (Input.GetMouseButton(1)) //Right click(마우스 오른쪽 버튼을 누르는중의 처리)
        {
            MouseRightClick();
        }
        else if (Input.GetMouseButton(2)) //Middle click(마우스 가운데 버튼을 누르는중의 처리)
        {
            Cursor.SetCursor(handImg, Vector2.zero, CursorMode.ForceSoftware);
            MouseMiddleButtonClicked();
        }
        else if (Input.GetMouseButtonUp(0)) //Left unclick(마우스 왼쪽 버튼을 뗄 때의 처리)
        {
            ShowAndUnlockCursor();
        }
        else if (Input.GetMouseButtonUp(1)) //Right unclick(마우스 오른쪽 버튼을 뗄 때의 처리)
        {
            ShowAndUnlockCursor();
        }
        else if (Input.GetMouseButtonUp(2)) //Middle unclick(마우스 가운데 버튼을 뗄 때의 처리)
        {
            ShowAndUnlockCursor();
            Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
        }
        else //When clicking nothing
        {
            MouseWheeling();
        }
    }

    void ShowAndUnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void HideAndLockCursor()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        //Cursor.SetCursor(cursor, Vector3.zero, CursorMode.ForceSoftware);
    }

    void MouseMiddleButtonClicked()
    {
        HideAndLockCursor();
        //Vector3 NewPosition = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
        Vector3 NewPosition = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
        Vector3 pos = transform.position;
        if (NewPosition.x > 0.0f)
        {
            pos -= 2*transform.right;
        }
        else if (NewPosition.x < 0.0f)
        {
            pos += 2*transform.right;
        }
        else if (NewPosition.y > 0.0f)
        {
            pos -= 2*transform.up;
        }
        else if (NewPosition.y < 0.0f)
        {
            pos += 2*transform.up;
        }
        /*
        float dirX = Input.GetAxis("Horizntal");
        float dirY = Input.GetAxis("Vertical");
     
        Vector3 dirXY = Vector3.right * h + Vector3.up * dirY; 
        
        dirXY.Normalize();
     
        transform.position += dirXY * 5 * Time.deltaTime;
        출처: https://backback.tistory.com/422 [Back Ground:티스토리]
        */
        /*
        if (NewPosition.z > 0.0f)
        {
            pos += transform.forward;
        }
        if (NewPosition.z < 0.0f)
        {
            pos -= transform.forward;
        }
        */
        //pos.y = transform.position.y;
        transform.position = pos;
    }

    void MouseRightClick()
    {
        HideAndLockCursor();
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

    void MouseWheeling()
    {
        Vector3 pos = transform.position;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            pos = pos - 7*transform.forward;
            transform.position = pos;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            pos = pos + 7*transform.forward;
            transform.position = pos;
        }
    }

}
