using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.TextCore.Text;

public class Teams : MonoBehaviour, IPunObservable
{
    public List<ICharacter> Human = new List<ICharacter>();
    public List<ICharacter> Orc=new List<ICharacter>();
    public string characterName;
    void Start()
    {
        characterName = PhotonNetwork.NickName;
    }
    void Update()
    {
        
    }
    public void AddTeamHuman(ICharacter icharacter)
    {
        Human.Add(icharacter);
        //liste kontrolü yapýlacak iki listede de ayný karakter var ise silme iþlemi yapýlacak.iki takýmdan da sil öyle ekle
    }
    public void AddTeamOrc(ICharacter icharacter)
    {
        Orc.Add(icharacter);
        //liste kontrolü yapýlacak
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //if (stream.IsWriting)
        //{
        //    stream.SendNext(Human);
        //    stream.SendNext(Orc);
        //}
        //else if (stream.IsReading)
        //{
        //    Human=(List<ICharacter>)stream.ReceiveNext();
        //    Orc=(List<ICharacter>)stream.ReceiveNext();
        //}
        if (stream.IsWriting)
        {
            stream.SendNext(characterName);
        }
        else
        {
            characterName = (string)stream.ReceiveNext();
            Debug.Log(characterName);
        }
    }
}


