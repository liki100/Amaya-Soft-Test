using System.Collections.Generic;
using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts
{
    public class LoadGame : MonoBehaviour
    {
        [SerializeField] private DataGame _dataGame;
        [SerializeField] private GridSpawner _gridSpawner;
        [SerializeField] private VisualGame visualGame;
    
        private int _currentLevel;
        private List<Tile> _tiles;
    
        private string _lastCardID;

        public int CurrentLevel => _currentLevel;
        public List<Tile> Tiles => _tiles;
    
        public bool Load()
        {
            var levelsData = _dataGame.LevelsData;
            var cardBundlesData = _dataGame.CardBundlesData;
        
            if (levelsData.Length <= _currentLevel)
                return false;

            _tiles = _gridSpawner.SpawnGrid(levelsData[_currentLevel]);
            var currentCardData = GenerateCard(cardBundlesData, _tiles);
            var winingCardID = GenerateWiningCardId(currentCardData);
            visualGame.UpdateVisual(currentCardData, _tiles, winingCardID);
            visualGame.UpdateWinningText(winingCardID);
        
            return true;
        }
    
        private List<CardData> GenerateCard(CardBundleData[] cardBundlesData, List<Tile> tiles)
        {
            var generate = new GenerateCard();
            var rBundle = Random.Range(0, cardBundlesData.Length);
            return generate.Generate(tiles, cardBundlesData[rBundle]);
        }

        private string GenerateWiningCardId(List<CardData> cardData)
        {
            string winingCardID;
        
            while (true)
            {
                var indexWiningCard = Random.Range(0, cardData.Count);
                winingCardID = cardData[indexWiningCard].ID;

                if (_lastCardID == winingCardID)
                    continue;
            
                _lastCardID = winingCardID;
                break;
            }

            return winingCardID;
        }

        public void SetCurrentLevel(int value)
        {
            _currentLevel = value;
        }
    }
}
