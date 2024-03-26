using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _item;
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private ParticleSystem _winningParticle;

    private CardData _cardData;
    private bool _active = true;
    private string _winningID;

    public Action OnClickWinningTile;
    
    public void Init(CardData cardData, string winningID)
    {
        _cardData = cardData;
        _winningID = winningID;
        _item.sprite = _cardData.Sprite;
        
        if (_cardData.ID is "7" or "8")
        {
            _item.gameObject.transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, -90f));
        }
        
        var r = Random.Range(0.5f, 1f);
        var g = Random.Range(0.5f, 1f);
        var b = Random.Range(0.25f, 0.75f);
        _background.color = new Color(r, g, b);
    }
    
    private void OnMouseDown()
    {
        if (!_active) 
            return;
        
        SetActive(false);
        
        if (_winningID == _cardData.ID)
        {
            Correct();
        }
        else
        {
            Incorrect();
        }
    }

    private void Correct()
    {
        _winningParticle.Play();
        var scaleX = _item.transform.localScale.x;
        _item.transform.localScale = new Vector2(0f,0f);
        _item.transform.DOScale(scaleX, 1f).SetEase(Ease.InBounce).OnComplete(()=> OnClickWinningTile?.Invoke());
    }

    private void Incorrect()
    {
        _item.transform.DOShakePosition(1f, new Vector3(.25f, 0, 0)).SetEase(Ease.InBounce).OnComplete(()=> SetActive(true));
    }

    public void SetActive(bool active)
    {
        _active = active;
    }
}
