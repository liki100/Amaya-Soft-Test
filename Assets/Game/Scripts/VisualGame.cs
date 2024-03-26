using System.Collections.Generic;
using Game.Scripts.Data;
using Game.Scripts.Visual;
using UnityEngine;

namespace Game.Scripts
{
    public class VisualGame : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private UIGame uiGame;
    
        public void UpdateVisual(List<CardData> cardData, List<Tile> tiles, string winingCardID)
        {
            for (var index = 0; index < tiles.Count; index++)
            {
                tiles[index].Init(cardData[index], winingCardID);
                tiles[index].OnClickWinningTile += _gameState.ClickWinningTile;
            }
        }
    
        public void UpdateWinningText(string winingCardID)
        {
            uiGame.UpdateSearchText(winingCardID);
        }
    }
}
