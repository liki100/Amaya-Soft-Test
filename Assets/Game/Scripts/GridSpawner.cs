using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] private Tile _tileTemplate;

    private readonly List<Tile> _tiles = new List<Tile>();
    
    public List<Tile> SpawnGrid(LevelData levelData)
    {
        if (_tiles.Count != 0)
        {
            foreach (var tile in _tiles)
            {
                Destroy(tile.gameObject);
            }
            _tiles.Clear();
            transform.position = Vector3.zero;
        }

        var tileSize = _tileTemplate.transform.localScale.x;
        
        for (var row = 0; row < levelData.Row; row++)
        {
            for (var colum = 0; colum < levelData.Colum; colum++)
            {
                var newTile = Instantiate(_tileTemplate, new Vector3(colum * tileSize, row * tileSize),
                    Quaternion.identity, transform);

                _tiles.Add(newTile);
            }
        }
        
        var gridWidth = levelData.Colum * tileSize;
        var gridHeight = levelData.Row * tileSize;
        transform.position = new Vector2(-gridWidth / 2 + tileSize / 2, -gridHeight / 2 + tileSize / 2);

        return _tiles;
    }
}
