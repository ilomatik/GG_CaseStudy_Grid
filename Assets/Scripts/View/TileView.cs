using System;
using DG.Tweening;
using UnityEngine;

namespace View
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private GameObject _markObject;

        public int Col { get; private set; }
        public int Row { get; private set; }
        
        private Action<int, int> _onTileClicked;

        public void SetId(int col, int row, Action<int, int> onTileClicked)
        {
            Col = col;
            Row = row;
            
            _onTileClicked = onTileClicked;
        }
        
        public void Mark()
        {
            _markObject.transform.DOScale(Vector3.one, 0.25f)
                                 .SetEase(Ease.InOutBounce);
        }
        
        public void Unmark()
        {
            _markObject.transform.DOScale(Vector3.zero, 0.25f)
                                 .SetEase(Ease.InOutBounce);
        }
    }
}