using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class Cube : MonoBehaviourPun, IOnEventCallback
{

    private Color cubeColor;
    private Renderer cubeRenderer;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        cubeColor = cubeRenderer.material.color;

        PhotonNetwork.AddCallbackTarget(this);
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ChangeCubeColor()
    {
        if (photonView.IsMine)
        {
            Color newColor = new Color(Random.value, Random.value, Random.value);
            cubeRenderer.material.color = newColor;

            object[] data = new object[] { newColor.r, newColor.g, newColor.b };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
            PhotonNetwork.RaiseEvent(1, data, raiseEventOptions, SendOptions.SendUnreliable);
        }
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 1)
        {
            object[] data = (object[])photonEvent.CustomData;
            if (data.Length == 3)
            {
                float r = (float)data[0];
                float g = (float)data[1];
                float b = (float)data[2];
                Color receivedColor = new Color(r, g, b);
                cubeRenderer.material.color = receivedColor;
            }
        }
    }
}
