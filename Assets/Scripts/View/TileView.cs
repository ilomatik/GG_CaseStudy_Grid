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
        
        private Action<int, int> _onTileClicked;

        public void Initialize(int id, int col, int row, Action<int, int> onTileClicked)
        {
            Id  = id;
            Col = col;
            Row = row;
            
            _onTileClicked = onTileClicked;
        }
        
        public void Mark()
        {
            _markObject.transform.DOScale(Vector3.one, 0.1f)
                                 .SetEase(Ease.InOutBounce);
        }
        
        public void Unmark()
        {
            _markObject.transform.DOScale(Vector3.zero, 0.1f)
                                 .SetEase(Ease.InOutBounce);
        }

        private void OnMouseDown()
        {
            Debug.Log($"TileView{Id} OnMouseEnter");
            _onTileClicked?.Invoke(Col, Row);
        }
    }
}