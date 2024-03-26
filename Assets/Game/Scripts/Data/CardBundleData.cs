using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data", order = 41)]
public class CardBundleData : ScriptableObject
{
    [SerializeField] private List<CardData> _cardData;

    public IEnumerable<CardData> CardData => _cardData;
}

[Serializable]
public class CardData
{
    [SerializeField] private string _id;
    [SerializeField] private Sprite _sprite;

    public string ID => _id;
    public Sprite Sprite => _sprite;
}
