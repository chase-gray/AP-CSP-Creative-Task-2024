using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card")]
public class Card : ScriptableObject
{
    [Header("Card Info")]
        public int value;
        public int aceValue;
        public GameObject cardObject;
}