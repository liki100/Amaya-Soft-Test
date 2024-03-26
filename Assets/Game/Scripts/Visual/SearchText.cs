using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SearchText : MonoBehaviour
{
    private Text _searchText;
    
    private void Awake()
    {
        _searchText = GetComponent<Text>();
    }

    public void UpdateText(string id)
    {
        _searchText.text = "Find " + id;
    }
}
