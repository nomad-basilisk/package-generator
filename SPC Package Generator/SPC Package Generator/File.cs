using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC_Package_Generator
{
    class File
    {
        static public string filename;
        static public string schema;
        string sqlTableName;
        static public List<String> fileColumns = new List<String>();
        static public List<String> sqlColumns = new List<String>();

        public string getSqlTableName()
        {
            return sqlTableName;
        }

        public void setSqlTableName(string x)
        {
            sqlTableName = x;
        }

        public List<String> getSqlColumns() 
        {
            return sqlColumns;
        }

        public void setSqlColumns(List<String> x)
        {
            sqlColumns = x;
        }

        public List<String> getFileColumns()
        {
            return fileColumns;
        }

        public void setFileColumns(List<String> x)
        {
            fileColumns = x;
        }

    }
}
