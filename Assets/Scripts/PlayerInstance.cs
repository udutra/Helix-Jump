using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour {

    public PlayerInstantiate[] playerInstantiate;

    [System.Serializable]
	public struct PlayerInstantiate
    {
        public string playerName;
        public int ID;
        public GameObject player;
    }

    private void Start()
    {
        for (int i = 0; i < playerInstantiate.Length; i++)
        {
            if(playerInstantiate[i].ID == GameController.Instance.playerID)
            {
                //Instantiate(playerInstantiate[i].player, transform.position, Quaternion.identity);
                Instantiate(playerInstantiate[i].player);
            }
        }
        if (GameController.Instance.playerID == 0)
        {
            Instantiate(playerInstantiate[0].player);
        }
    }
}
