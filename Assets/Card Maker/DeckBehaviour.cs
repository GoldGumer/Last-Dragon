using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CardType
{
    Attack = 1,
    Heal = 2,
    Shield = 3,
}

public class DeckBehaviour : MonoBehaviour
{
    private List<Card> deck = new List<Card>();
    private List<Card> discardPile = new List<Card>();

    public void Shuffle()
    {

    }

}
