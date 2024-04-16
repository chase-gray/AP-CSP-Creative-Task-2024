using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

public enum GameState { dealerTurn, playerTurn, endGame }                       // Set of game states to determine game flow

public class GameController : MonoBehaviour
{
    public GameState gameState;
    
    [Header("UI")]                                                              // Input to interact with game
        public GameObject hitButton;
        public GameObject standButton;
    [Space(10)]

    [Header("Cards")]
        public List<Card> deck = new List<Card>();                              // Initial deck list
        public List<Card> decks = new List<Card>();                             // Modified deck list based on input amount of decks
        public List<Card> dealerHand = new List<Card>();                        // List to hold dealer hand
        public List<Card> playerHand = new List<Card>();                        // List to hold player hand


    public int dealerHandValue;                                                 // Variable to hold dealer hand value
    public int playerHandValue;                                                 // Variable to hold player hand value
    public int deckAmount;                                                      // Deck amount modifier

    public void Awake()
    {
        for (int i = 0; i < deckAmount; i++)                                    // Creates a new deck based on the deck amount modifier
            foreach (Card card in deck)
                decks.Add(card);
    }

    public void Start()
    {
        DrawPlayer(2);                                                          // Draws two cards for the player and the dealer 
        DrawDealer(2);                                                          
        gameState = GameState.playerTurn;                                       // Sets the game state to the player turn
    }

    public void Update()
    {
        CheckAce();                                                             // Constantly checks ace values

        if (playerHandValue >= 21 || dealerHandValue > 21)                      // Determines if game is over
        {
            gameState = GameState.endGame;
        }

        if (gameState == GameState.playerTurn)                                  // Logic for if it is the player turn
        {
            hitButton.SetActive(true);
            standButton.SetActive(true);
        }
        else if (gameState == GameState.dealerTurn)                             // Logic for if it is the dealer turn
        {
            hitButton.SetActive(false);
            standButton.SetActive(false);
            StartCoroutine(DealerTurn());
        }
        else                                                                    // Logic for if the game is over
        {
            EndGame();
        }
    }

    public void DrawPlayer(int amount)
    {
        for (int i = 0; i < amount; i++)                                        // Draws an amount of cards from the deck and adds it to the player hand
        {
            int randomCardNumber = Random.Range(0, decks.Count);
            Card randomCard = decks[randomCardNumber];
            decks.RemoveAt(randomCardNumber);
            playerHand.Add(randomCard);
            if (randomCard.value == 1)                                          // Determines if a card is an ace or not
            {
                playerHandValue += randomCard.aceValue;
            }
            else
            {
                playerHandValue += randomCard.value;
            }
        }
    }

    public void DrawDealer(int amount)
    {
        for (int i = 0; i < amount; i++)                                        // Draws an amount of cards from the deck and adds it to the dealer hand
        {
            int randomCardNumber = Random.Range(0, decks.Count);
            Card randomCard = decks[randomCardNumber];
            decks.RemoveAt(randomCardNumber);
            dealerHand.Add(randomCard);
            if (randomCard.value == 1)                                          // Determines if a card is an ace or not
            {
                dealerHandValue += randomCard.aceValue;
            }
            else
            {
                dealerHandValue += randomCard.value;
            }
        }
    }

    public void PlayerTurnHit()                                                 // Deals the player a card
    {
        DrawPlayer(1);
        gameState = GameState.dealerTurn;
    }

    public void PlayerTurnStand()                                               // Passes the players turn
    {
        if (dealerHandValue >= 16)                                              // Ends game if dealer cannot draw anymore
            gameState = GameState.endGame;
        else
            gameState = GameState.dealerTurn;
    }

    public IEnumerator DealerTurn()
    {
        yield return new WaitForSeconds(1.5f);                                  // Illusion of waiting for dealer
        if (dealerHandValue < 16)                                               // Dealer draws if below 16, else passes turn
            DrawDealer(1);
        gameState = GameState.playerTurn;
    }

    public void EndGame()                                                       // Ends game, and displays end screens
    {
        hitButton.SetActive(false);
        standButton.SetActive(false);
    }

    public void CheckAce()
    {
        foreach (Card card in playerHand)
        {
            if (card.value == 1 && playerHandValue > 21 && !card.aceValueCheck)     // Goes through each card in hand and if ace and is able, then ace value is changed 
            {
                card.aceValueCheck = true;                                          // Checker so ace cannot infinitely decrease deck value
                playerHandValue -= card.aceValue;
                playerHandValue += card.value; 
            }
        }

        foreach (Card card in dealerHand)
        {
            if (card.value == 1 && dealerHandValue > 21 && !card.aceValueCheck)     // Goes through each card in hand and if ace and is able, then ace value is changed
            {
                card.aceValueCheck = true;                                          // Checker so ace cannot infinitely decrease deck value
                dealerHandValue -= card.aceValue;
                dealerHandValue += card.value; 
            }
        }
    }
}