using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPointsManager : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void UpdateStartPoint(Transform newTransform)
    {
        player.startPoint = newTransform;
    }
}
