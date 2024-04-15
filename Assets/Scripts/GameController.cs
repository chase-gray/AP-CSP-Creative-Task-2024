using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

public enum GameState { dealerTurn, playerTurn, endGame }

public class GameController : MonoBehaviour
{
    public GameState gameState;
    
    [Header("UI")]
        public GameObject hitButton;
        public GameObject standButton;
    [Space(10)]

    [Header("Cards")]
        public List<Card> deck = new List<Card>();
        public List<Card> decks = new List<Card>();
        public List<Card> dealerHand = new List<Card>();
        public List<Card> playerHand = new List<Card>();


    public int dealerHandValue;
    public int playerHandValue;

    public void Awake()
    {
        for (int i = 0; i < 4; i++)
            foreach (Card card in deck)
                decks.Add(card);
    }

    public void Start()
    {
        DrawPlayer(2);
        DrawDealer(2);
        gameState = GameState.playerTurn;
    }

    public void Update()
    {
        if (playerHandValue > 21 || dealerHandValue > 21)
        {
            gameState = GameState.endGame;
        }

        if (gameState == GameState.playerTurn)
        {
            hitButton.SetActive(true);
            standButton.SetActive(true);
        }
        else if (gameState == GameState.dealerTurn)
        {
            hitButton.SetActive(false);
            standButton.SetActive(false);
            StartCoroutine(DealerTurn());
        }
        else
        {
            EndGame();
        }
    }

    public void DrawPlayer(int loop)
    {
        for (int i = 0; i < loop; i++)
        {
            int randomCardNumber = Random.Range(0, decks.Count);
            Card randomCard = decks[randomCardNumber];
            decks.RemoveAt(randomCardNumber);
            playerHand.Add(randomCard);
            playerHandValue += randomCard.value;
        }
    }

    public void DrawDealer(int loop)
    {
        for (int i = 0; i < loop; i++)
        {
            int randomCardNumber = Random.Range(0, decks.Count);
            Card randomCard = decks[randomCardNumber];
            decks.RemoveAt(randomCardNumber);
            dealerHand.Add(randomCard);
            dealerHandValue += randomCard.value;
        }
    }

    public void PlayerTurnHit()
    {
        DrawPlayer(1);
        gameState = GameState.dealerTurn;
    }

    public void PlayerTurnStand()
    {
        if (dealerHandValue >= 16)
            gameState = GameState.endGame;
        else
            gameState = GameState.dealerTurn;
    }

    public IEnumerator DealerTurn()
    {
        if (dealerHandValue <= 16)
            DrawDealer(1);
        yield return new WaitForSeconds(3);
        gameState = GameState.playerTurn;
    }

    public void EndGame()
    {
        hitButton.SetActive(false);
        standButton.SetActive(false);
    }
}