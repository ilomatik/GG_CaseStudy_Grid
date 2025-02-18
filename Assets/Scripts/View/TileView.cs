using System;
using DG.Tweening;
using UnityEngine;

namespace View
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private GameObject _markObject;

        public int Id  { get; private set; }
        public int Col { get; private set; }
        public int Row { get; private set; }

        private float _scaleUpDuration;
        private float _scaleDownDuration;
        private Tween _tileTween;
        
        private Action<int, int> _onTileClicked;

        public void Initialize(int id, int col, int row, Action<int, int> onTileClicked)
        {
            Id  = id;
            Col = col;
            Row = row;
            
            _onTileClicked = onTileClicked;
        }
        
        public void SetDurations(float scaleUpDuration, float scaleDownDuration)
        {
            _scaleUpDuration   = scaleUpDuration;
            _scaleDownDuration = scaleDownDuration;
        }
        
        public void Mark()
        {
            if (_tileTween != null)
            {
                _tileTween.Kill();
                _tileTween = null;
            }

            _tileTween = _markObject.transform.DOScale(Vector3.one, _scaleUpDuration)
                                              .SetEase(Ease.InOutBounce);
        }
        
        public void Unmark()
        {
            if (_tileTween != null)
            {
                _tileTween.Kill();
                _tileTween = null;
            }
            
            _tileTween = _markObject.transform.DOScale(Vector3.zero, _scaleDownDuration)
                                              .SetEase(Ease.InOutBounce);
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