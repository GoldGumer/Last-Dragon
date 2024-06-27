using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    private enum BiomeType
    {
        plain,
        forest,
        mountain
    }

    struct biomePointPosition
    {
        public biomePointPosition(BiomeType BiomeType, Vector2Int vector2Int, Vector2 vector2)
        {
            type = BiomeType;
            overWorldPosition = vector2Int;
            offsetPosition = vector2;
        }

        public BiomeType type { get; }
        public Vector2Int overWorldPosition { get; }
        public Vector2 offsetPosition { get; }
    }

    [SerializeField] Transform canvas;

    [Header("Hex Generation")]
    [Space(10)]
    [SerializeField] private GameObject hexPrefab;
    [SerializeField] private Transform hexContainer;
    private float hexesHorizontal = 10;
    private float hexesVertical = 7;
    [Range(0.0f,1.0f)]
    [SerializeField] private float canvasAreaMultiplier;

    [Header("Biome Generation Points")]
    [Space(10)]
    [SerializeField] private Transform biomePointsContainer;
    [SerializeField] private float horizontalBiomePoints;
    [SerializeField] private float verticalBiomePoints;
    private GameObject[,] biomePoints;
    private List<biomePointPosition> storedBiomePoints = new List<biomePointPosition>();

    // Start is called before the first frame update
    void Start()
    {
        Vector2 canvasResolution = canvas.GetComponent<CanvasScaler>().referenceResolution;
        canvasResolution += new Vector2(canvasResolution.x * canvasAreaMultiplier, canvasResolution.y * canvasAreaMultiplier);
        Vector2 canvasHalfResolution = canvasResolution / 2;

        //Biome point generator
        biomePoints = new GameObject[Mathf.RoundToInt(horizontalBiomePoints + 1.0f), Mathf.RoundToInt(verticalBiomePoints + 1.0f)];


        for (int i = 0; i <= verticalBiomePoints; i++)
        {
            for (int j = 0; j <= horizontalBiomePoints; j++)
            {
                float horizontalStep = (canvasResolution.x / horizontalBiomePoints);
                float verticalStep = (canvasResolution.y / verticalBiomePoints);

                biomePoints[j, i] = new GameObject("Generation Point" + (j + (i * (horizontalBiomePoints + 1))).ToString());
                biomePoints[j, i].transform.parent = biomePointsContainer;
                biomePoints[j, i].transform.localPosition = new Vector3(
                    j * horizontalStep - canvasHalfResolution.x,
                    i * verticalStep - canvasHalfResolution.y,
                    0.0f
                    );

                storedBiomePoints.Add(
                    new biomePointPosition((BiomeType)Random.Range(0, 2),
                    new Vector2Int(j, i),
                    new Vector2(Random.Range(-(horizontalStep / 2), (horizontalStep / 2)), Random.Range(-(verticalStep / 2), (verticalStep / 2)))));

                GameObject offsetPoint = new GameObject("Offset Point");
                offsetPoint.transform.parent = biomePoints[j, i].transform;
                offsetPoint.transform.localPosition = storedBiomePoints[storedBiomePoints.Count - 1].offsetPosition;
                
            }
        }

        //Hex grid generation
        Vector2Int cityCoord = new Vector2Int(Random.Range(3, 11), Random.Range(2, 7));


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
                hexASCII.GetComponent<Hex>().SetOverworldPosition(new Vector3Int(Mathf.CeilToInt(j / 2.0f) + i - j, j, -Mathf.CeilToInt(j / 2.0f) -i));

                if (cityCoord == new Vector2Int(j, i))
                {
                    hexASCII.GetComponent<Hex>().ChangeHexType(4);
                }
            }
        }

        
    }

    public void UpdateMap(Vector2 dragonPosition)
    {

    }
}
