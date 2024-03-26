using UnityEngine;

public class DataGame : MonoBehaviour
{
    [SerializeField] private LevelData[] _levelsData;
    [SerializeField] private CardBundleData[] _cardBundlesData;

    public LevelData[] LevelsData => _levelsData;
    public CardBundleData[] CardBundlesData => _cardBundlesData;
}
