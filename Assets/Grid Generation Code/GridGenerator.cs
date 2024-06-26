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
    [SerializeField] private Transform hexContainer;
    private float hexesHorizontal = 10;
    private float hexesVertical = 7;
    [Range(0.0f,1.0f)]
    [SerializeField] private float canvasAreaMultiplier;

    [Header("Biome Colours")]
    [Space(10)]
    [SerializeField] private Color plainsColour;
    [SerializeField] private Color forestColour;
    [SerializeField] private Color mountainColour;

    [Header("Biome Generation Points")]
    [Space(10)]
    [SerializeField] private Transform biomePointsContainer;
    [SerializeField] private float horizontalBiomePoints;
    [SerializeField] private float verticalBiomePoints;
    [SerializeField] private float seperation;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 canvasResolution = canvas.GetComponent<CanvasScaler>().referenceResolution;
        canvasResolution += new Vector2(canvasResolution.x * canvasAreaMultiplier, canvasResolution.y * canvasAreaMultiplier);
        Vector2 canvasHalfResolution = canvasResolution / 2;

        //Hex grid generation
        hexesHorizontal += hexesHorizontal * canvasAreaMultiplier;
        hexesVertical += hexesVertical * canvasAreaMultiplier;
        for (int i = 0; i < hexesVertical; i++)
        {
            for (int j = 0; j < hexesHorizontal; j++)
            {
                float yOffset = ((hexPrefab.GetComponent<RectTransform>().rect.height / 2) - canvasHalfResolution.y);
                float xOffset = ((hexPrefab.GetComponent<RectTransform>().rect.width / 2) - canvasHalfResolution.x);
                GameObject hexASCII = Instantiate(hexPrefab, Vector3.zero, Quaternion.identity, hexContainer);
                hexASCII.transform.localPosition = new Vector3(
                    j * (canvasResolution.x / hexesHorizontal) + xOffset,
                    i * (canvasResolution.y / hexesVertical) + ((canvasResolution.y / (hexesVertical * 2)) * (j % 2)) + yOffset,
                    0.0f);
            }
        }
        
        //Biome point generator
        for (int i = 0; i <= verticalBiomePoints; i++) 
        {
            for (int j = 0; j <= horizontalBiomePoints; j++) 
            {
                GameObject biomePoint = new GameObject("generation point" + (j + (i * horizontalBiomePoints)).ToString());
                biomePoint.transform.parent = biomePointsContainer;
                biomePoint.transform.localPosition = new Vector3(
                    j * (canvasResolution.x / horizontalBiomePoints) - canvasHalfResolution.x,
                    i * (canvasResolution.y / verticalBiomePoints) - canvasHalfResolution.y,
                    0.0f
                    );
            }
        }
    }

    public void UpdateMap()
    {

    }
}
