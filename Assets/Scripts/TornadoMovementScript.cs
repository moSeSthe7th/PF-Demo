using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMovementScript : MonoBehaviour
{
    string zPositive = "zPositive";
    string zNegative = "zNegative";
    string xPositive = "xPositive";

    public GameObject truck;

    public float tornadoSpeed;

    private Vector3 touchStartPos;
    private Vector3 currentTouchPos;
    private Vector3 touchDiff;

    private Vector2 differenceVecForCollision;

    string truckAxis;

    void Update()
    {
        if (truck.transform.rotation.eulerAngles.y < 45)
            truckAxis = zPositive;
        else if (truck.transform.rotation.eulerAngles.y > 135)
            truckAxis = zNegative;
        else
            truckAxis = xPositive;

        #region Mouse Controls
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseVector = new Vector2();
            mouseVector.x = Input.GetAxis("Mouse X");
            mouseVector.y = Input.GetAxis("Mouse Y");
            Vector3 movementVec = new Vector3();

            
            
            if(truckAxis == xPositive)
                movementVec = new Vector3(transform.position.x + (mouseVector.y * 2f), 0.5f, transform.position.z + (mouseVector.x * -2f));
            else if(truckAxis == zPositive)
                movementVec = new Vector3(transform.position.x + (mouseVector.x*2f), 0.5f, transform.position.z + (mouseVector.y*2f));
            else
                movementVec = new Vector3(transform.position.x + (mouseVector.x * -2f), 0.5f, transform.position.z + (mouseVector.y * -2f));
            
            transform.position = Vector3.Lerp(transform.position, movementVec, tornadoSpeed * Time.deltaTime);
            
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, truck.transform.position, tornadoSpeed * Time.deltaTime/15f);
        }
        #endregion

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                Vector2 touchVector = touch.deltaPosition;
                Vector3 movementVec = new Vector3();

                if (truckAxis == xPositive)
                    movementVec = new Vector3(transform.position.x + (touchVector.y * 2f), 0.5f, transform.position.z + (touchVector.x * -2f));
                else if (truckAxis == zPositive)
                    movementVec = new Vector3(transform.position.x + (touchVector.x * 2f), 0.5f, transform.position.z + (touchVector.y * 2f));
                else
                    movementVec = new Vector3(transform.position.x + (touchVector.x * -2f), 0.5f, transform.position.z + (touchVector.y * -2f));

                transform.position = Vector3.Lerp(transform.position, movementVec, tornadoSpeed * Time.deltaTime / 15f);
            }
        }
        else
            transform.position = Vector3.Lerp(transform.position, truck.transform.position, tornadoSpeed * Time.deltaTime / 20f);

    }

}

