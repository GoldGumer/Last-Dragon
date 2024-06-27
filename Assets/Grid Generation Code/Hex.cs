using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    [SerializeField]private Vector3Int overworldPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        DragonOverworld dragonOverworld = GameObject.FindGameObjectWithTag("Player").GetComponent<DragonOverworld>();

        int distanceToDragon = Mathf.Abs(
            (dragonOverworld.GetOverworldPosition().x + dragonOverworld.GetOverworldPosition().y + dragonOverworld.GetOverworldPosition().z)
            - (overworldPosition.x + overworldPosition.y + overworldPosition.z));

        if (dragonOverworld && (dragonOverworld.GetMovement() >= distanceToDragon))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
            dragonOverworld.AddMovement(-distanceToDragon);
        }
    }

    public void SetOverworldPosition(Vector3Int overworldPosition)
    {
        this.overworldPosition = overworldPosition;
    }

    public Vector3Int GetOverworldPosition()
    {
        return overworldPosition;
    }
}
