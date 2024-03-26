using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Visual
{
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
}
