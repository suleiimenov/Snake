﻿using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 4;
        private Point _myHeadPosition;
        private Point _myFoodPosition;

        public string Name => "Kurttyn goi tagy";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection)
        {
            if(currentDirection == SnakeDirection.Up && _myHeadPosition.Y < _wallDistanceThreshold -1)
            {
                return SnakeDirection.Left;
            }

            if(currentDirection == SnakeDirection.Right && _myHeadPosition.X > _width - _wallDistanceThreshold +1)
            {
                return SnakeDirection.Up;
            }

            if(currentDirection == SnakeDirection.Down && _myHeadPosition.Y > _width - _wallDistanceThreshold +1)
            {
                return SnakeDirection.Right;
            }

            if (currentDirection == SnakeDirection.Left && _myHeadPosition.X <  _wallDistanceThreshold -1)
            {
                return SnakeDirection.Down;
            }




            if (currentDirection == SnakeDirection.Up &&  _myHeadPosition.Y == _myFoodPosition.Y)
            {
                return SnakeDirection.Left;
            }

            if (currentDirection == SnakeDirection.Right  && _myHeadPosition.X == _myFoodPosition.X)
            {
                return SnakeDirection.Up;
            }

            if (currentDirection == SnakeDirection.Down  && _myHeadPosition.Y == _myFoodPosition.Y)
            {
                return SnakeDirection.Right;
            }

            if (currentDirection == SnakeDirection.Left  && _myHeadPosition.X == _myFoodPosition.X)
            {
                return SnakeDirection.Down;
            }


            return currentDirection;
        }

        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
            _myFoodPosition = getMyFoodPosition(map);


        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');

            return new Point(headIndex % _width, headIndex / _width);
        }
        private Point getMyFoodPosition(string map)
        {
            var foodIndex = map.IndexOf('7');
            return new Point(foodIndex % _width, foodIndex / _width);
        }
    }
}
