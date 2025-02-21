using DG.Tweening;
using UnityEngine;

namespace GameVariable
{
    [CreateAssetMenu(fileName = "GameVariables", menuName = "Game Variables")]
    public class GameVariables : ScriptableObject
    {
        [Header("Grid Variable")]
        [SerializeField] private int   _colCount;
        [SerializeField] private int   _rowCount;
        [SerializeField] private int   _unmarkLimit;
        [SerializeField] private Color _startColor;
        [SerializeField] private Color _endColor;

        [Header("Marked Tile")]
        [SerializeField] private float _markedScaleUpDuration;
        [SerializeField] private float _markedScaleDownDuration;
        [SerializeField] private Ease  _markedScaleUpEase;
        [SerializeField] private Ease  _markedScaleDownEase;
        
        public int   ColCount    => _colCount;
        public int   RowCount    => _rowCount;
        public int   UnmarkLimit => _unmarkLimit;
        public Color StartColor  => _startColor;
        public Color EndColor    => _endColor;

        public float MarkedScaleUpDuration   => _markedScaleUpDuration;
        public float MarkedScaleDownDuration => _markedScaleDownDuration;
        public Ease  MarkedScaleUpEase       => _markedScaleUpEase;
        public Ease  MarkedScaleDownEase     => _markedScaleDownEase;
    }
}