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

namespace OsmSharp.Osm.Core
{
    /// <summary>
    /// Represents a change in a change set.
    /// </summary>
    [Serializable]
    public class Change
    {
        /// <summary>
        /// Contains the type of change.
        /// </summary>
        private ChangeType _type;

        /// <summary>
        /// Contains the object to change.
        /// </summary>
        private OsmGeo _obj;

        /// <summary>
        /// Creates a new change object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        public Change(ChangeType type, OsmGeo obj)
        {
            _type = type;
            _obj = obj;
        }

        /// <summary>
        /// The type of this change.
        /// </summary>
        public ChangeType Type
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// The object this change is for.
        /// </summary>
        public OsmGeo Object
        {
            get
            {
                return _obj;
            }
        }
    }

    public enum ChangeType
    {
        Create,
        Delete,
        Modify
    }
}