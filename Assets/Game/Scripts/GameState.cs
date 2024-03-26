using DG.Tweening;
using Game.Scripts.Visual;
using UnityEngine;

namespace Game.Scripts
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private LoadGame _loadGame;
        [SerializeField] private UIGame uiGame;
    
        private void Start()
        {
            RestartGame();
        }
    
        private void RestartGame()
        {
            _loadGame.SetCurrentLevel(0);
            _loadGame.Load();
            AnimationStart();
            uiGame.RestartButton(false);
        }
    
        private void AnimationStart()
        {
            foreach (var tile in _loadGame.Tiles)
            {
                tile.transform.localScale = Vector3.zero;
            }
        
            foreach (var tile in _loadGame.Tiles)
            {
                tile.transform.DOScale(2f, 1f).SetEase(Ease.InBounce);
            }
        
            uiGame.SearchTextCanvasGroup.DOFade(1f, 2f);
        }
    
        public void ClickWinningTile()
        {
            _loadGame.SetCurrentLevel(_loadGame.CurrentLevel + 1);

            if (_loadGame.Load()) 
                return;
        
            foreach (var tile in _loadGame.Tiles)
            {
                tile.SetActive(false);
            }
        
            uiGame.FadeIn(.95f);    
            uiGame.RestartButton(true);
        }
    
        public void OnRestartClick()
        {
            uiGame.FadeIn(1f, .1f);
            RestartGame();
            uiGame.FadeOut();
        }
    }
}
