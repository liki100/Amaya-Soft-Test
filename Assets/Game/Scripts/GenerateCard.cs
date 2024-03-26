using System.Collections.Generic;
using UnityEngine;

public class GenerateCard
{
    public List<CardData> Generate(List<Tile> tiles, CardBundleData cardBundleData)
    {
        var cardData = new List<CardData>(cardBundleData.CardData);
        var currentCardData = new List<CardData>();
        
        for (var index = 0; index < tiles.Count; index++)
        {
            var rData = Random.Range(0, cardData.Count);
            currentCardData.Add(cardData[rData]);
            cardData.RemoveAt(rData);
        }

        return currentCardData;
    }
}
