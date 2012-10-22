﻿// OsmSharp - OpenStreetMap tools & library.
// Copyright (C) 2012 Abelshausen Ben
// 
// This file is part of OsmSharp.
// 
// OsmSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// OsmSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with OsmSharp. If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools.Math.Units.Angle
{
    public class Radian : Unit
    {
        private Radian()
            : base(0.0d)
        {

        }

        public Radian(double radians)
            : base(radians)
        {

        }

        #region Conversion

        public static implicit operator Radian(double value)
        {
            return new Radian(value);
        }

        public static implicit operator Radian(Degree deg)
        {
            double value = (deg.Value / 180d) * System.Math.PI;
            return new Radian(value);
        }

        #endregion

        public static Radian operator -(Radian rad1, Radian rad2)
        {
            return rad1.Value - rad2.Value;
        }
    }
}
