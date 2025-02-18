using System;

namespace Events
{
    public static class ViewEvents
    {
        public static Action<int, int> OnTileClicked;
        
        public static void TileClicked(int col, int row) { OnTileClicked?.Invoke(col, row); }
    }
}