namespace CS.Problems.Graph
{
    public class PaintFill
    {
        private readonly Color[][] _screen;

        public PaintFill(Color[][] screen)
        {
            _screen = screen;
        }

        public void Fill(Point point, Color newColor)
        {
            if (_screen[point.X][point.Y] == newColor)
            {
                return;
            }

            Fill(point, newColor, _screen[point.X][point.Y]);
        }

        #region Helpers

        private void Fill(Point point, Color newColor, Color oldColor)
        {
            if (point.X < 0 || point.X >= _screen.Length || point.Y < 0 || point.Y >= _screen[0].Length)
            {
                return;
            }

            if (_screen[point.X][point.Y] == oldColor)
            {
                _screen[point.X][point.Y] = newColor;

                Fill(new Point(point.X - 1, point.Y), newColor, oldColor);
                Fill(new Point(point.X + 1, point.Y), newColor, oldColor);
                Fill(new Point(point.X, point.Y - 1), newColor, oldColor);
                Fill(new Point(point.X, point.Y + 1), newColor, oldColor);
            }
        }

        #endregion

        public enum Color
        {
            Red = 1,
            Blue = 2,
            Black = 3
        }

        public class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; private set; }
            public int Y { get; private set; }
        }
    }
}
