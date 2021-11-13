using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public  class PlayerData 
{
    public  float[] playerPosition = new float[3];

    public  PlayerData(PlayerController playerData)
    {
        playerPosition[0] = playerData.transform.position.x;
        playerPosition[1] = playerData.transform.position.y;
        playerPosition[3] = playerData.transform.position.z;
    }
}
