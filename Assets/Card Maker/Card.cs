using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private string combatName;
    [SerializeField] private Effect combatEffect;

    [SerializeField] private string overworldName;
    [SerializeField] private Effect overworldEffect;

    [SerializeField] private bool isShowingAttackSide = true;
    public bool hasBeenPlayed;

    [SerializeField] private CardType cardType;
    
    private GameObject _card;
    private GameManager gm;

    public int handIndex;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if (isShowingAttackSide)
        {
            if (combatName != "")
            {
                transform.Find("Name").GetComponent<TextMeshProUGUI>().text = combatName;
            }
            transform.Find("Effect").GetComponent<TextMeshProUGUI>().text = combatEffect.GetEffectText();
        }
        else
        {
            if (overworldName != "")
            {
                transform.Find("Name").GetComponent<TextMeshProUGUI>().text = overworldName;
            }
            transform.Find("Effect").GetComponent<TextMeshProUGUI>().text = overworldEffect.GetEffectText();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowingAttackSide)
        {
            if (combatName != "")
            {
                transform.Find("Name").GetComponent<TextMeshProUGUI>().text = combatName;
            }
            transform.Find("Effect").GetComponent<TextMeshProUGUI>().text = combatEffect.GetEffectText();
        }
        else
        {
            if (overworldName != "")
            {
                transform.Find("Name").GetComponent<TextMeshProUGUI>().text = overworldName;
            }
            transform.Find("Effect").GetComponent<TextMeshProUGUI>().text = overworldEffect.GetEffectText();
        }
    }

    public void FlipCard()
    {
        isShowingAttackSide = !isShowingAttackSide;
    }

    public void CardPressed()
    {
        if (!hasBeenPlayed)
        {
            transform.position += Vector3.up * 5; //shows card has been played
            hasBeenPlayed = true;
            gm.avilableSlots[handIndex] = true;
            Invoke("MoveToDiscardPile", 2f);
        }
    }

    void MoveToDiscardPile()
    {
        gm.discardPile.Add(this);
        gameObject.SetActive(false);
    }
}
