using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : MonoBehaviour {


    // Use this for initialization
    int groundMask;
    Rigidbody turretRigidbody;
    public float camRayLegth = 100f;
    private string m_RotateAxisName;
    void Awake()
    {
        groundMask = LayerMask.GetMask("Ground");
        turretRigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Turning();
    }
    void Turning()
    {
    //    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit groundHit;
    //    if (Physics.Raycast(camRay, out groundHit, camRayLegth, groundMask))
    //    {
    //        //Debug.Log("Hittt");
    //        Vector3 playerToMouse = groundHit.point;
    //        playerToMouse.y = 0.0f;
    //        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
    //        turretRigidbody.MoveRotation(newRotation);
    //    }
    }
}
