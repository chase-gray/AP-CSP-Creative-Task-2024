using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card")]
public class Card : ScriptableObject
{
    [Header("Card Info")]                                   
        public int value;                           // Values of card
        public int aceValue;
        public bool aceValueCheck;                  // Ace checker to prevent bug
        public GameObject cardObject;               // Card game object
}