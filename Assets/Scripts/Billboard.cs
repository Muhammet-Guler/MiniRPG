using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Billboard : MonoBehaviourPun

{
    Camera cam;
    public UnityEngine.UI.Text nickName;
    void Start()
    {
        if (photonView.IsMine)
        {

            nickName.text = PhotonNetwork.NickName;
        }
        if (!photonView.IsMine)
        {

            nickName.text = GetComponent<PhotonView>().Controller.NickName;
        }
        nickName.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void Update()
    {
        if (cam==null)
            cam=FindObjectOfType<Camera>();
        if (cam == null)
            return;

        transform.LookAt(cam.transform);
        transform.Rotate(Vector3.up*180);
    }
}
