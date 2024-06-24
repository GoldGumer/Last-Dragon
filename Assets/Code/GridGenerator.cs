using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] Transform canvas;

    [Header("Hex Generation")]
    [Space(10)]
    [SerializeField] GameObject hexPrefab;

    [Header("Biome Generation Points")]
    [Space(10)]
    //Biome genertion points
    [SerializeField] private float seperationBetweenPoints;
    [SerializeField] private float seperationRandomness;
    private GameObject[,] biomePoints = new GameObject[6,10];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                Instantiate(hexPrefab, new Vector3(j * 1.5f, i * 1.886f, 0.0f), Quaternion.identity, canvas);
            }
        }
        
        //Biome point generator
        for (int i = 0; i < 6; i++) 
        {
            for (int j = 0; j < 10; j++) 
            {
                biomePoints[i, j] = new GameObject("generation point" + (j + (i * 10)));
                biomePoints[i, j].transform.position = new Vector3(
                    (j - 4.5f) * seperationBetweenPoints + Random.Range(-seperationRandomness, seperationRandomness),
                    (i - 2.5f) * seperationBetweenPoints + Random.Range(-seperationRandomness, seperationRandomness),
                    0.0f
                    );
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
