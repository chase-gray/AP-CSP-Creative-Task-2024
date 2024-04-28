using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card")]
public class Card : ScriptableObject
{
    // Card asset by Game Asset Studio: https://assetstore.unity.com/packages/3d/props/tools/free-playing-cards-pack-154780
    [Header("Card Info")]                                   
        public int value;               // Values of card
        public int aceValue;            // Ace value
        public bool aceValueCheck;      // Ace checker to prevent bug
        public bool isSpawned;          // Makes sure card cant be spawned on screen more than once
        public GameObject cardObject;   // Card game object
}