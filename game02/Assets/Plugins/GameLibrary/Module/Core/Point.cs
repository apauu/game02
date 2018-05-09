using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameLibrary
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public Point(Vector2 v2)
        {
            x = (int)v2.x;
            y = (int)v2.y;
        }

        public Vector2 ToVector2()
        {
            return new Vector2(x, y);
        }
    }
}
