using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DataGame _dataGame;
    [SerializeField] private GridSpawner _gridSpawner;
    [SerializeField] private VisualGame _visualGame;

    private int _currentLevel;
    private string _winingCardID;
    private List<Tile> _tiles;

    private string _lastCardID;

    private void Start()
    {
        RestartGame();
    }

    private bool LoadGame()
    {
        var levelsData = _dataGame.LevelsData;
        var cardBundlesData = _dataGame.CardBundlesData;
        
        if (levelsData.Length <= _currentLevel)
            return false;

        _tiles = _gridSpawner.SpawnGrid(levelsData[_currentLevel]);
        var currentCardData = GenerateCard(cardBundlesData, _tiles);
        UpdateSearchText(currentCardData);
        UpdateCard(currentCardData, _tiles);
        
        return true;
    }

    private List<CardData> GenerateCard(CardBundleData[] cardBundlesData, List<Tile> tiles)
    {
        var generate = new GenerateCard();
        var rBundle = Random.Range(0, cardBundlesData.Length);
        return generate.Generate(tiles, cardBundlesData[rBundle]);
    }
    
    private void UpdateCard(List<CardData> cardData, List<Tile> tiles)
    {
        for (var index = 0; index < tiles.Count; index++)
        {
            tiles[index].Init(cardData[index], _winingCardID);
            tiles[index].OnClickWinningTile += ClickWinningTile;
        }
    }

    private void UpdateSearchText(List<CardData> cardData)
    {
        while (true)
        {
            var indexWiningCard = Random.Range(0, cardData.Count);
            _winingCardID = cardData[indexWiningCard].ID;

            if (_lastCardID == _winingCardID)
                continue;

            _lastCardID = _winingCardID;
            _visualGame.UpdateSearchText(_winingCardID);
            break;
        }
    }

    private void ClickWinningTile()
    {
        _currentLevel++;

        if (LoadGame()) 
            return;
        
        foreach (var tile in _tiles)
        {
            tile.SetActive(false);
        }
        
        _visualGame.FadeIn(.95f);    
        _visualGame.RestartButton(true);
    }

    private void AnimationStart()
    {
        foreach (var tile in _tiles)
        {
            tile.transform.localScale = Vector3.zero;
        }
        
        foreach (var tile in _tiles)
        {
            tile.transform.DOScale(2f, 1f).SetEase(Ease.InBounce);
        }
        
        _visualGame.SearchTextCanvasGroup.DOFade(1f, 2f);
    }
    
    private void RestartGame()
    {
        _currentLevel = 0;
        LoadGame();
        AnimationStart();
        _visualGame.RestartButton(false);
    }

    public void OnRestartClick()
    {
        _visualGame.FadeIn(1f, .1f);
        RestartGame();
        _visualGame.FadeOut();
    }
}
