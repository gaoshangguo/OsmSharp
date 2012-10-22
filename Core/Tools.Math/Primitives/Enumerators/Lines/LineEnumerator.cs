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
using System.Collections;

namespace Tools.Math.Primitives.Enumerators.Lines
{
    internal class LineEnumerator<PointType> :
        IEnumerator<GenericLineF2D<PointType>>,
        IEnumerator
        where PointType : PointF2D
    {
        /// <summary>
        /// Holds the enumerable being enumerated.
        /// </summary>
        private ILineList<PointType> _enumerable;

        /// <summary>
        /// Holds the current line.
        /// </summary>
        private GenericLineF2D<PointType> _current_line;

        /// <summary>
        /// Holds the current index.
        /// </summary>
        private int _current_idx;

        /// <summary>
        /// Creates a new enumerator.
        /// </summary>
        /// <param name="enumerable"></param>
        public LineEnumerator(ILineList<PointType> enumerable)
        {
            _enumerable = enumerable;
        }

        #region IEnumerator<GenericLineF2D<PointType>> Members

        public GenericLineF2D<PointType> Current
        {
            get { return _current_line; }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _current_line = null;
        }

        #endregion

        #region IEnumerator Members

        object IEnumerator.Current
        {
            get { return _current_line; }
        }

        public bool MoveNext()
        {
            _current_idx++;
            if (_current_idx < _enumerable.Count)
            {
                _current_line = _enumerable[_current_idx];
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _current_idx = -1;
        }

        #endregion

        #region IEnumerator Members


        bool IEnumerator.MoveNext()
        {
            return this.MoveNext();
        }

        void IEnumerator.Reset()
        {
            this.Reset();
        }

        #endregion
    }
}
