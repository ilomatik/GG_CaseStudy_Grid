using System;
using DG.Tweening;
using UnityEngine;

namespace View
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private GameObject _markObject;
        [SerializeField] private Renderer   _renderer;

        public int Id  { get; private set; }
        public int Col { get; private set; }
        public int Row { get; private set; }

        private float _scaleUpDuration;
        private float _scaleDownDuration;
        private Ease  _scaleUpEase;
        private Ease  _scaleDownEase;
        private Tween _tileTween;
        
        private Action<int, int> _onTileClicked;
        private Action<Vector3>  _onTileMarked;
        private Action<Vector3>  _onTileUnmarked;

        public void Initialize(int id, 
                               int col,
                               int row, 
                               Action<int, int> onTileClicked, 
                               Action<Vector3> onTileMarked, 
                               Action<Vector3> onTileUnmarked)
        {
            Id  = id;
            Col = col;
            Row = row;
            
            _onTileClicked  = onTileClicked;
            _onTileMarked   = onTileMarked;
            _onTileUnmarked = onTileUnmarked;
        }
        
        public void SetDurations(float scaleUpDuration, float scaleDownDuration)
        {
            _scaleUpDuration   = scaleUpDuration;
            _scaleDownDuration = scaleDownDuration;
        }
        
        public void SetEases(Ease scaleUpEase, Ease scaleDownEase)
        {
            _scaleUpEase   = scaleUpEase;
            _scaleDownEase = scaleDownEase;
        }

        public void SetColor(Color color)
        {
            _renderer.material.color = color;
        }
        
        public void Mark()
        {
            if (_tileTween != null)
            {
                _tileTween.Kill();
                _tileTween = null;
            }

            _tileTween = _markObject.transform.DOScale(Vector3.one, _scaleUpDuration).SetEase(_scaleUpEase);
            _onTileMarked?.Invoke(transform.position);
        }
        
        public void Unmark()
        {
            if (_tileTween != null)
            {
                _tileTween.Kill();
                _tileTween = null;
            }
            
            _tileTween = _markObject.transform.DOScale(Vector3.zero, _scaleDownDuration).SetEase(_scaleDownEase);
            _onTileUnmarked?.Invoke(transform.position);
        }

        private void OnMouseDown()
        {
            _onTileClicked?.Invoke(Col, Row);
        }
        
        private void OnDestroy()
        {
            if (_tileTween == null) return;
            
            _tileTween.Kill();
            _tileTween = null;
        }
    }
}