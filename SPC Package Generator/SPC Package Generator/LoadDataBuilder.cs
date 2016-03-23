using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace SPC_Package_Generator
{
    class LoadDataBuilder
    {
        
        //Strings for package
        String variableXMLList;
        String cSharpTaskList;
        String xmlTaskList;

        //end

        List<String> variablesList_3 = new List<string>();

        //##### BUILD PACKAGE ####################
        public void buildPackage(List<string> filenames)
        {
            int count = 0;

            foreach (string filename in filenames)
            {
                String filepath = Files.files[count];

                File.filename = filename;
 
                String namePattern = filename.Substring(0, (filename.Length - 4));
                namePattern = namePattern.Replace(" ", "");

                createXMLVars(namePattern, filename);
                addCSharpTask(namePattern);
                addXMLTask(namePattern, filepath);

                count += 1;

            }

            string final = LoadDataStrings.loadDataInitial_1 +
                           LoadDataStrings.variablesNodeBegin_2 +
                           variableXMLList + Environment.NewLine + Environment.NewLine +
                           LoadDataStrings.variablesNodeEnd_4 +
                           LoadDataStrings.taskNodeBegin_5 +
                           cSharpTaskList + Environment.NewLine + Environment.NewLine +
                           LoadDataStrings.taskNodeEnd_7 +
                           xmlTaskList + Environment.NewLine + Environment.NewLine +
                           LoadDataStrings.end_8;
            System.IO.File.WriteAllText(@"C:\Test\load-data.dspkg", final);

        }
        //####################################################

        //##### Create Variable XML Lists ####################
        public void createXMLVars(String namePattern, String filename)
        {
            string beginVar = @"        <Variable name=""";
            string midVar = @""" value=""";
            string endVar = @""" />";

            string var = String.Format("{0}{1}{2}{3}{4}", beginVar, namePattern, midVar, filename, endVar);

            variableXMLList = variableXMLList + Environment.NewLine + var;
            
        }
        //####################################################

        //##### Create C# Task XML Lists ####################

        private void addCSharpTask(String namePattern)
        {
            string taskString = @"
            TaskResult result = TaskResult.Success;
            result = runTask(package, ""{0}"", package.Variables[""{1}""].Value, ""{0}"");
            if (result != TaskResult.Success)
            return result;" + Environment.NewLine 
                            + Environment.NewLine;

            string taskName = "Load" + namePattern.Replace("Pattern", "");

            string finalTaskString = String.Format(taskString, taskName, namePattern);

            cSharpTaskList = cSharpTaskList + finalTaskString + "\n";
        }
        //####################################################

        //##### Create XML Tasks Lists ####################

        private void addXMLTask(String namePattern, String filePath)
        {
            string taskString = @"
                <Task  name=""{0}""
                       description=""""
                       type=""Symmetrix.DataStage.Tasks.DelimitedFileImportTask2, Symmetrix.DataStage""
                       depends=""""
                       hidden=""True""
                       enabled=""False"">

                       <Property name=""FileName"" value=""{1}"" />
                       <Property name=""FirstRowHeaders"" value=""True"" />
                       <Property name=""TargetConnectionName"" value=""Stage"" />
                       <Property name=""TargetTableName"" value=""{2}"" />
                       <Property name=""TruncateTable"" value=""True"" />
                       <Property name=""DecimalSymbol"" value=""."" />  
                       <Property name=""WhereClause"" value="""" />
                       <Property name=""IgnoreDataErrors"" value=""False"" />
                       <ColumnMappings>
                              {3}
                       </ColumnMappings>
                </Task>" + Environment.NewLine 
                         + Environment.NewLine;

            string taskName = "Load" + namePattern.Replace("Pattern", "");
            string sqlTable = "<<FILL IN>>";
            string columnMappings = "<<COLUMN MAPPING>>" + Environment.NewLine;

            string columnMapping = getColumnMappings(filePath);
            
            string finalTaskString = String.Format(taskString, taskName, namePattern, sqlTable, columnMappings);

            xmlTaskList = xmlTaskList + finalTaskString + Environment.NewLine;

            
        }
        //####################################################

        private string getColumnMappings(String filePath) 
        {
            List<string> loadDT = new List<string>();
            StreamReader sr = new StreamReader(filePath);

            string[] headers = sr.ReadLine().Split(',');
            foreach (string header in headers)
            {
                String head = header.Replace("\"", "");
                loadDT.Add(header); // I've added the column headers here.
            }

            File.fileColumns = loadDT;
            SqlColumnMapping sqlCol = new SqlColumnMapping();
            sqlCol.Show();

            return "";
        }
    }
}
