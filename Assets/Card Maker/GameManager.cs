using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public Transform[] cardSlots;
    public Transform[] deckSlots;
    public Transform[] discardPileSlots;
    public bool[] avilableSlots;

    public TextMeshProUGUI deckCountText;
    public TextMeshProUGUI discardPileCount;
    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            Card randCard = deck[Random.Range(0,deck.Count)];

            for (int i = 0; i < avilableSlots.Length; i++)
            {
                if (avilableSlots[i])
                {
                    randCard.gameObject.SetActive(true);
                    randCard.handIndex = i;
                    randCard.transform.position = cardSlots[i].position;
                    avilableSlots[i] = false; //card can no longer occupy that slot if its there
                    deck.Remove(randCard);
                    return; //so it only draws one card at a time
                }
            }
        }
    }
    /* public void ShowCurrentDeck()
    {
        if (deck.Count >= 1)
        { 
            foreach (Card card in deck)
            {
               card.gameObject.SetActive(true);
            }
        }
    } */

    private void Update()
    {
       deckCountText.text = deck.Count.ToString();
       discardPileCount.text = discardPile.Count.ToString();
    }
}
