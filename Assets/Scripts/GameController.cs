using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum GameState { DealerTurn, PlayerTurn };

public class GameController : MonoBehaviour
{
    Card card;

    public List<Card> deck = new List<Card>();
    public List<Card> dealerHand = new List<Card>();
    public List<Card> playerHand = new List<Card>();

    public int dealerHandValue;
    public int playerHandValue;

    public void Awake()
    {
        card = gameObject.GetComponent<Card>();
    }

    public void Start()
    {
        DrawPlayer(2);
        DrawDealer(2);
    }

    public void Update()
    {
        foreach (Card card in dealerHand)
            card.value += dealerHandValue;
        
        foreach (Card card in playerHand)
            card.value += playerHandValue;

        // if (GameState == PlayerTurn)
        // {

        // }
        // else
        // {

        // }
    }

    public void DrawPlayer(int loop)
    {
        for (int i = 0; i < loop; i++)
        {
            int randomCardNumber = Random.Range(0, deck.Count);
            Card randomCard = deck[randomCardNumber];
            deck.RemoveAt(randomCardNumber);
            playerHand.Add(randomCard);
        }
    }

    public void DrawDealer(int loop)
    {
        for (int i = 0; i < loop; i++)
        {
            int randomCardNumber = Random.Range(0, deck.Count);
            Card randomCard = deck[randomCardNumber];
            deck.RemoveAt(randomCardNumber);
            dealerHand.Add(randomCard);
        }
    }
}