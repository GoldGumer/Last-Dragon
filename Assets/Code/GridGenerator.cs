using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] Transform canvas;

    [Header("Hex Generation")]
    [Space(10)]
    [SerializeField] private GameObject hexPrefab;
    [SerializeField] private int hexesHorizontal;
    [SerializeField] private int hexesVertical;

    [Header("Biome Generation Points")]
    [Space(10)]
    [SerializeField] private float seperationBetweenPoints;
    [SerializeField] private float seperationRandomness;
    private GameObject[,] biomePoints = new GameObject[6,10];

    // Start is called before the first frame update
    void Start()
    {
        //Hex grid generation
        Vector2 canvasResolution = canvas.GetComponent<CanvasScaler>().referenceResolution;
        for (int i = 0; i < hexesVertical; i++)
        {
            for (int j = 0; j < hexesHorizontal; j++)
            {
                float yOffset = ((hexPrefab.GetComponent<RectTransform>().rect.height / 2) - (canvasResolution.y / 2));
                float xOffset = ((hexPrefab.GetComponent<RectTransform>().rect.width / 2) - (canvasResolution.x / 2));
                GameObject hexASCII = Instantiate(hexPrefab, Vector3.zero, Quaternion.identity, canvas);
                hexASCII.transform.localPosition = new Vector3(
                    j * (canvasResolution.x / hexesHorizontal) + xOffset,
                    i * (canvasResolution.y / hexesVertical) + (canvasResolution.y / (hexesVertical * 2) * (j % 2)) + yOffset,
                    0.0f);


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
        Vector2 canvasResolution = canvas.GetComponent<CanvasScaler>().referenceResolution;
        for (int i = 0; i < hexesVertical; i++)
        {
            for (int j = 0; j < hexesHorizontal; j++)
            {
                float yOffset = ((hexPrefab.GetComponent<RectTransform>().rect.height / 2) - (canvasResolution.y / 2));
                float xOffset = ((hexPrefab.GetComponent<RectTransform>().rect.width / 2) - (canvasResolution.x / 2));
                if ((j + i * hexesVertical) < canvas.childCount)
                {
                    Transform hexASCII = canvas.GetChild((j + i * hexesVertical));
                    hexASCII.localPosition = new Vector3(
                        j * (canvasResolution.x / hexesHorizontal) + xOffset,
                        i * (canvasResolution.y / hexesVertical) + (canvasResolution.y / (hexesVertical * 2) * (j % 2)) + yOffset,
                        0.0f);
                }
                else
                {

                }
            }
        }
    }
}
