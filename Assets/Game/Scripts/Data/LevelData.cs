using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data", order = 41)]
public class LevelData : ScriptableObject
{
    [SerializeField] private int _row;
    [SerializeField] private int _colum;
    
    public int Row => _row;
    public int Colum => _colum;
}
