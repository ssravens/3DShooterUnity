using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{


    public GameObject Character;

    public GameObject CameraCenter;

    public float yOffset;

    public float sensitivity;

    public Camera cam;

    RaycastHit camHit;

    public Vector3 CamDist;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CameraCenter.transform.position = new Vector3(Character.transform.position.x, Character.transform.position.y + yOffset, Character.transform.position.z);
        CameraCenter.transform.rotation = Quaternion.Euler(CameraCenter.transform.rotation.eulerAngles.x - Input.GetAxis("Mouse Y") * sensitivity / 2,
            CameraCenter.transform.rotation.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivity, CameraCenter.transform.rotation.eulerAngles.z);

        cam.transform.localPosition = CamDist;
        GameObject obj = new GameObject();
        obj.transform.SetParent(cam.transform.parent);
        obj.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z - 0.1f);

        if (Physics.Linecast(CameraCenter.transform.position, obj.transform.position, out camHit))
        {
            cam.transform.position = camHit.point;
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z + 0.1f);
        }

        Destroy(obj);
    }
}

/*
 *
 *

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotationSpeed;
    public Transform rotate;



    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;

        }

        rotate.transform.position = target.transform.position;
        rotate.transform.parent = target.transform;

        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {



        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed;
        rotate.Rotate(-vertical, 0, 0);

        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        target.Rotate(0, horizontal, 0);

        //Limiter - this limits the moving of the camera up/down to certain angle ponts.
        if (rotate.rotation.eulerAngles.x > 60f && rotate.rotation.eulerAngles.x < 180f)
        {
            rotate.rotation = Quaternion.Euler(60f, 0, 0);
        }
        if (rotate.rotation.eulerAngles.x < -10f && rotate.rotation.eulerAngles.x < 300f)
        {
            rotate.rotation = Quaternion.Euler(-11f, 0, 0);
        }



        float wantedYAngle = target.eulerAngles.y;
        float wantedXAngle = rotate.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(wantedXAngle, wantedYAngle, 0);
        transform.position = target.position - (rotation * offset);


        if (transform.position.y < target.position.y)
        {

            transform.position = new Vector3(transform.position.x, target.position.y + .20f, transform.position.z);
        }

        transform.LookAt(target);

    }
}


 * 
 * 
 * 
 * 
 */
