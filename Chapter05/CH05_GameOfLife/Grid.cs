using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CH05_GameOfLife
{
    internal class Grid
    {

        private readonly int _sizeX;
        private readonly int _sizeY;
        private readonly Cell[,] _cells;
        private readonly Cell[,] _nextGenerationCells;
        private static Random _rnd;
        private readonly Canvas _drawCanvas;
        private readonly Ellipse[,] _cellsVisuals;


        public Grid(Canvas c)
        {
            _drawCanvas = c;
            _rnd = new Random();
            _sizeX = (int)(c.Width / 5);
            _sizeY = (int)(c.Height / 5);
            _cells = new Cell[_sizeX, _sizeY];
            _nextGenerationCells = new Cell[_sizeX, _sizeY];
            _cellsVisuals = new Ellipse[_sizeX, _sizeY];

            for (var i = 0; i < _sizeX; i++)
                for (var j = 0; j < _sizeY; j++)
                {
                    _cells[i, j] = new Cell(i, j, 0, false);
                    _nextGenerationCells[i, j] = new Cell(i, j, 0, false);
                }

            SetRandomPattern();
            InitCellsVisuals();
            UpdateGraphics();

        }


        public void Clear()
        {
            for (var i = 0; i < _sizeX; i++)
                for (var j = 0; j < _sizeY; j++)
                {
                    _cells[i, j] = new Cell(i, j, 0, false);
                    _nextGenerationCells[i, j] = new Cell(i, j, 0, false);
                    _cellsVisuals[i, j].Fill = Brushes.Gray;
                }
        }


        void MouseMove(object sender, MouseEventArgs e)
        {
            var cellVisual = sender as Ellipse;

            if (cellVisual == null) return;
            var i = (int)cellVisual.Margin.Left / 5;
            var j = (int)cellVisual.Margin.Top / 5;


            if (e.LeftButton != MouseButtonState.Pressed) return;
            if (_cells[i, j].IsAlive) return;
            _cells[i, j].IsAlive = true;
            _cells[i, j].Age = 0;
            cellVisual.Fill = Brushes.White;
        }

        public void UpdateGraphics()
        {
            for (var i = 0; i < _sizeX; i++)
                for (var j = 0; j < _sizeY; j++)
                    _cellsVisuals[i, j].Fill = _cells[i, j].IsAlive
                                                  ? (_cells[i, j].Age < 2 ? Brushes.White : Brushes.DarkGray)
                                                  : Brushes.Gray;
        }

        public void InitCellsVisuals()
        {
            for (var i = 0; i < _sizeX; i++)
                for (var j = 0; j < _sizeY; j++)
                {
                    _cellsVisuals[i, j] = new Ellipse();
                    _cellsVisuals[i, j].Width = _cellsVisuals[i, j].Height = 5;
                    double left = _cells[i, j].PositionX;
                    double top = _cells[i, j].PositionY;
                    _cellsVisuals[i, j].Margin = new Thickness(left, top, 0, 0);
                    _cellsVisuals[i, j].Fill = Brushes.Gray;
                    _drawCanvas.Children.Add(_cellsVisuals[i, j]);

                    _cellsVisuals[i, j].MouseMove += MouseMove;
                    _cellsVisuals[i, j].MouseLeftButtonDown += MouseMove;
                }
            UpdateGraphics();

        }


        public static bool GetRandomBoolean()
        {
            return _rnd.NextDouble() > 0.8;
        }

        public void SetRandomPattern()
        {
            for (var i = 0; i < _sizeX; i++)
                for (var j = 0; j < _sizeY; j++)
                    _cells[i, j].IsAlive = GetRandomBoolean();
        }

        public void UpdateToNextGeneration()
        {
            for (var i = 0; i < _sizeX; i++)
                for (var j = 0; j < _sizeY; j++)
                {
                    _cells[i, j].IsAlive = _nextGenerationCells[i, j].IsAlive;
                    _cells[i, j].Age = _nextGenerationCells[i, j].Age;
                }

            UpdateGraphics();
        }


        public void Update()
        {
            var alive = false;
            var age = 0;

            for (var i = 0; i < _sizeX; i++)
            {
                for (var j = 0; j < _sizeY; j++)
                {
                    _nextGenerationCells[i, j] = CalculateNextGeneration(i, j);          // UNOPTIMIZED
                    //CalculateNextGeneration(i, j, ref alive, ref age);   // OPTIMIZED
                    //_nextGenerationCells[i, j].IsAlive = alive;  // OPTIMIZED
                    //_nextGenerationCells[i, j].Age = age;  // OPTIMIZED
                }
            }
            UpdateToNextGeneration();
        }

        public Cell CalculateNextGeneration(int row, int column)    // UNOPTIMIZED
        {
            var alive = _cells[row, column].IsAlive;
            var age = _cells[row, column].Age;
            var count = CountNeighbors(row, column);

            if (alive && count < 2)
                return new Cell(row, column, 0, false);

            if (alive && (count == 2 || count == 3))
            {
                _cells[row, column].Age++;
                return new Cell(row, column, _cells[row, column].Age, true);
            }

            if (alive && count > 3)
                return new Cell(row, column, 0, false);

            if (!alive && count == 3)
                return new Cell(row, column, 0, true);

            return new Cell(row, column, 0, false);
        }

        public void CalculateNextGeneration(int row, int column, ref bool isAlive, ref int age)     // OPTIMIZED
        {
            isAlive = _cells[row, column].IsAlive;
            age = _cells[row, column].Age;

            var count = CountNeighbors(row, column);

            if (isAlive && count < 2)
            {
                isAlive = false;
                age = 0;
            }

            if (isAlive && (count == 2 || count == 3))
            {
                _cells[row, column].Age++;
                isAlive = true;
                age = _cells[row, column].Age;
            }

            if (isAlive && count > 3)
            {
                isAlive = false;
                age = 0;
            }

            if (!isAlive && count == 3)
            {
                isAlive = true;
                age = 0;
            }
        }

        public int CountNeighbors(int i, int j)
        {
            var count = 0;

            if (i != _sizeX - 1 && _cells[i + 1, j].IsAlive) count++;
            if (i != _sizeX - 1 && j != _sizeY - 1 && _cells[i + 1, j + 1].IsAlive) count++;
            if (j != _sizeY - 1 && _cells[i, j + 1].IsAlive) count++;
            if (i != 0 && j != _sizeY - 1 && _cells[i - 1, j + 1].IsAlive) count++;
            if (i != 0 && _cells[i - 1, j].IsAlive) count++;
            if (i != 0 && j != 0 && _cells[i - 1, j - 1].IsAlive) count++;
            if (j != 0 && _cells[i, j - 1].IsAlive) count++;
            if (i != _sizeX - 1 && j != 0 && _cells[i + 1, j - 1].IsAlive) count++;

            return count;
        }
    }
}