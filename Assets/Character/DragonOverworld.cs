using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonOverworld : MonoBehaviour
{
    private int movement = 3;
    private Vector3Int overworldPosition = new Vector3Int(4, 4, 3);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMovement(int movement)
    {
        this.movement = movement;
    }

    public int GetMovement()
    {
        return movement;
    }

    public void AddMovement(int movement)
    {
        this.movement += movement;
    }


    public Vector3Int GetOverworldPosition()
    {
        return overworldPosition;
    }
}
