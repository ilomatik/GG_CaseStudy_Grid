using System;
using UnityEngine;

namespace Events
{
    public static class ViewEvents
    {
        public static Action<int, int> OnTileClicked;
        public static Action<Vector3>  OnTileMarked;
        public static Action<Vector3>  OnTileUnmarked;

        public static void TileClicked(int col, int row) { OnTileClicked?.Invoke(col, row); }
        public static void TileMarked(Vector3 position)  { OnTileMarked?.Invoke(position); }
        public static void TileUnmarked(Vector3 position) { OnTileUnmarked?.Invoke(position); }
    }
}