using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hex : MonoBehaviour
{
    private enum HexType
    {
        plain,
        forest,
        mountain,
        river,
        city
    }

    [SerializeField]private Vector3Int overworldPosition;
    [SerializeField] private HexType hexType;

    // Start is called before the first frame update
    void Awake()
    {
        ChangeHexType(Random.Range(0, 4));
    }

    /*
  ___  
 /   \ 
/     \
\     /
 \___/ 
     */

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHexType(int newType)
    {
        hexType = (HexType)newType;

        switch (hexType)
        {
            case HexType.plain:
                transform.GetComponent<TextMeshProUGUI>().text = "" +
                    "  ___  \r" +
                    "\n /   \\ \r" +
                    "\n/     \\\r" +
                    "\n\\field/\r" +
                    "\n \\___/ ";
                transform.GetComponent<TextMeshProUGUI>().color = Color.yellow;
                break;
            case HexType.forest:
                transform.GetComponent<TextMeshProUGUI>().text = "" +
                    "  ___  \r" +
                    "\n /   \\ \r" +
                    "\n/     \\\r" +
                    "\n\\ tree/\r" +
                    "\n \\___/ ";
                transform.GetComponent<TextMeshProUGUI>().color = Color.green;
                break;
            case HexType.mountain:
                transform.GetComponent<TextMeshProUGUI>().text = "" +
                    "  ___  \r" +
                    "\n /   \\ \r" +
                    "\n/     \\\r" +
                    "\n\\rocks/\r" +
                    "\n \\___/ ";
                transform.GetComponent<TextMeshProUGUI>().color = Color.grey;
                break;
            case HexType.city:
                transform.GetComponent<TextMeshProUGUI>().text = "" +
                    "  ___  \r" +
                    "\n /   \\ \r" +
                    "\n/     \\\r" +
                    "\n\\city /\r" +
                    "\n \\___/ ";
                transform.GetComponent<TextMeshProUGUI>().color = Color.red;
                break;
            case HexType.river:
                transform.GetComponent<TextMeshProUGUI>().text = "" +
                    "  ___  \r" +
                    "\n /   \\ \r" +
                    "\n/     \\\r" +
                    "\n\\water/\r" +
                    "\n \\___/ ";
                transform.GetComponent<TextMeshProUGUI>().color = Color.cyan;
                break;
            default:
                transform.GetComponent<TextMeshProUGUI>().text = "" +
                    "  ___  \r" +
                    "\n /   \\ \r" +
                    "\n/     \\\r" +
                    "\n\\     /\r" +
                    "\n \\___/ ";
                transform.GetComponent<TextMeshProUGUI>().color = Color.white;
                break;
        }
    }

    public void OnClick()
    {
        DragonOverworld dragonOverworld = GameObject.FindGameObjectWithTag("Player").GetComponent<DragonOverworld>();

        Vector3Int dragonToHexVect3 = dragonOverworld.GetOverworldPosition() - overworldPosition;

        int distanceToDragon = (Mathf.Abs(dragonToHexVect3.x) + Mathf.Abs(dragonToHexVect3.y) + Mathf.Abs(dragonToHexVect3.z)) / 2;

        if (dragonOverworld && (dragonOverworld.GetMovement() >= distanceToDragon))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
            dragonOverworld.AddMovement(-distanceToDragon);
            dragonOverworld.SetOverworldPosition(overworldPosition);
            if (hexType == HexType.city)
            {
                SceneManager.LoadScene("Combat");
            }
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
