﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SPC_Package_Generator
{
    class SqlTableStrings
    {
        public string GenerateCreateTable(string schema, string tableName, DataTable columnsDT)
        {
            //
            string final = String.Concat(
                                            "CREATE TABLE "
                                           ,tableName
                                           ,"( "
                                           ,    CreateColumnList(columnsDT)
                                           ,")"
                                            );

            return final;
        }

        //loop through DataTable from SqlColumnMapping form and generate sql script columns.
        private string CreateColumnList(DataTable dt)
        {
            string columns = "";

            foreach (DataRow dr in dt.Rows)
            {
                columns = String.Concat(
                                columns,
                                "   " + dr["ActualColumn"], //add space in front for indentation formatting.
                                " ",
                                dr["TypeColumn"],
                                " ",
                                GetNullable(bool.Parse(dr["Nullable"].ToString())),
                                ",",
                                Environment.NewLine);
            }
            return columns;
        }

        //checks bool value from datatable and converts to sql NULL/NOT NULL codes.
        private string GetNullable(bool nullable)
        {
            if (nullable)
            {
                return "NULL";
            }
            else
            {
                return "NOT NULL";
            }
        }
    }
}
