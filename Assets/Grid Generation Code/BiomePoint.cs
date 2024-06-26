using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomePoint : MonoBehaviour
{
    private enum biomeType
    {
        plain,
        forest,
        mountain
    }

    struct biomePointPosition
    {
        biomeType type;
        Vector2Int overWorldPosition;
        Vector2 pos;
    }

    [SerializeField] private Vector2Int overWorldPosition;
    private List<biomePointPosition> randomPositions = new List<biomePointPosition>();

    public void Setup(Vector2Int overWorldPosition)
    {
        this.overWorldPosition = overWorldPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
