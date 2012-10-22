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
using Oracle.DataAccess.Client;
using Osm.Core.Simple;
using Osm.Data.Core.Processor;

namespace Osm.Data.Oracle.Raw.Processor
{
    public class OracleSimpleDataProcessorTruncateTarget : DataProcessorTarget
    {
        private OracleConnection _connection;
        
        private string _connection_string;

        public OracleSimpleDataProcessorTruncateTarget(string connection_string)
        {
            _connection_string = connection_string;
        }


        public override void Initialize()
        {
            _connection = new OracleConnection(_connection_string);
            _connection.Open();

            OracleCommand command;

            this.Constraints(false);

            try
            {
                command = new OracleCommand("truncate table node");
                command.Connection = _connection;
                command.ExecuteNonQuery();
                command.Dispose();

                command = new OracleCommand("truncate table node_tags");
                command.Connection = _connection;
                command.ExecuteNonQuery();
                command.Dispose();

                command = new OracleCommand("truncate table way");
                command.Connection = _connection;
                command.ExecuteNonQuery();
                command.Dispose();

                command = new OracleCommand("truncate table way_tags");
                command.Connection = _connection;
                command.ExecuteNonQuery();
                command.Dispose();

                command = new OracleCommand("truncate table way_nodes");
                command.Connection = _connection;
                command.ExecuteNonQuery();
                command.Dispose();

                command = new OracleCommand("truncate table relation");
                command.Connection = _connection;
                command.ExecuteNonQuery();
                command.Dispose();

                command = new OracleCommand("truncate table relation_tags");
                command.Connection = _connection;
                command.ExecuteNonQuery();
                command.Dispose();

                command = new OracleCommand("truncate table relation_members");
                command.Connection = _connection;
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Constraints(true);
            }
        }
        private void Constraints(bool enable)
        {
            OracleCommand command;

            string enable_str = "enable";
            if (!enable)
            {
                enable_str = "disable";
            }

            string sql
                = "select c.table_name,constraint_name "
                + "from user_constraints c, user_tables u "
                + "where c.table_name = u.table_name "
                + "and constraint_type = 'R' "
                ;
            command = new OracleCommand(sql);
            command.Connection = _connection;
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sql = string.Format("alter table {0} {2} constraint {1}",
                    reader["table_name"].ToString(),
                    reader["constraint_name"].ToString(),
                    enable_str);
                command = new OracleCommand(sql);
                command.Connection = _connection;
                command.ExecuteNonQuery();
                command.Dispose();
            }
            reader.Close();
            reader.Dispose();
        }

        public override void ApplyChange(SimpleChangeSet change)
        {

        }

        public override void AddNode(SimpleNode node)
        {

        }

        public override void AddWay(SimpleWay way)
        {

        }

        public override void AddRelation(SimpleRelation relation)
        {

        }

        public override void Close()
        {
            _connection.Close();
        }
    }
}
