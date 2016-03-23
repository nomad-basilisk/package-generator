using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC_Package_Generator
{
    class VariablePackageStrings
    {

        public static string variable_1 = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                                <!--
                                                /**********************************************************************/
                                                 *                                                                    * 
                                                 *               Symmetrix DataStage Package File                     * 
                                                 *                 Copyright (c) StatPro                              * 
                                                 *                                                                    * 
                                                 * Change Control:                                                    * 
                                                 * Date (yyyy-MM-dd) Who (Init) Comment                               * 
                                                 * 2008/06/02      RC   Changed source amdata path to                 *
                                                 *                              FRIASP\raison\JFCSPC\                 *  
                                                 *====================================================================* 
                                                 *                                                                    * 
                                                /**********************************************************************/
                                                -->
                                                <?xml-stylesheet type=""text/xsl"" href=""packages/report.xslt""?>
                                                <configuration>

                                                  <Variables>

                                                    <!-- add variables here -->

                                                    <!-- NOTE: this variable will be set dynamically at run-time -->
                                                    <Variable name=""ProfileName"" value="""" />

                                                    <!-- NOTE: this variable will be set dynamically at run-time -->
                                                    <Variable name=""RunDateTime"" value="""" />

                                                    <!-- NOTE: this variable will be set dynamically at run-time -->
                                                    <Variable name=""BasePath"" value="""" />

                                                    <Variable name=""PackageFilePath"" value=""$(BasePath)\packages"" />
                                                    <Variable name=""DataFilePath"" value=""$(BasePath)\data"" />
                                                    <Variable name=""ManualDataFilePath"" value=""$(DataFilePath)\manual"" />
                                                    <Variable name=""UtilityDataFilePath"" value=""$(DataFilePath)\utility"" />
                                                    <Variable name=""ScriptsFilePath"" value=""$(BasePath)\scripts"" />
                                                    <Variable name=""LogFilePath"" value=""$(BasePath)\logs"" />

                                                    <!-- NOTE: this variable will be set dynamically at run-time -->
                                                    <Variable name=""SMTPServer"" value="""" />
                                                    <Variable name=""UseCDO"" value="""" />

                                                    <Variable name=""SQLServerName"" value="""" />

                                                    <Variable name=""ComplianceDatabaseName"" value="""" />
                                                    <Variable name=""StageDatabaseName"" value="""" />

                                                    <!-- NOTE: this variable will be set dynamically at run-time -->
                                                    <Variable name=""NotificationEmailAddress"" value="""" />

                                                    <!-- NOTE: this variable will be set dynamically at run-time and prompted for -->
                                                    <Variable name=""SystemDate"" value="""" prompt=""True"" />

                                                    <Variable name=""DefaultCountry"" value=""ZA"" />
                                                    <Variable name=""DefaultCurrency"" value=""ZAR"" />

                                                    <Variable name=""MoveProcessedFiles"" value=""True"" />
    
                                                    <!-- path to the Symmetrix.Server.Console.exe executable -->
                                                    <Variable name=""SymmetrixServerConsolePath"" value=""$(AppPath)Symmetrix.Server.Console.exe"" />
    
                                                    <Variable name=""DebugMode"" value=""False"" />
    
                                                    <Variable name=""EOD"" value=""True"" />
                                                    <Variable name=""RunType"" value=""EOD"" />
                                                      <Variable name=""OverridePortfolioData"" value=""False"" />
    
                                                    <!-- NOTE Data File Paths -->
                                                    {0}
                                                    <!-- NOTE Data Sources -->
    
                                                  </Variables>

                                                </configuration>";
    }
}
