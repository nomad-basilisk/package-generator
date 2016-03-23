using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Data;

namespace SPC_Package_Generator
{
    /// <summary>
    /// Interaction logic for SqlColumnMapping.xaml
    /// </summary>
    public partial class SqlColumnMapping : Window
    {
        String suggestionCol;
        String actualCol;
        String typeCol;
        DataTable dt = new DataTable(); 

        public SqlColumnMapping()
        {
            InitializeComponent();

            dt.Columns.Add("FileColumn");
            dt.Columns.Add("ActualColumn");
            dt.Columns.Add("TypeColumn");

            populateGridTable();

            loopThrough();
        }

        private void populateGridTable() 
        {
            Label lbSuggestion = new Label();
            lbSuggestion.Content = File.schema + "." + File.filename.Replace("\"", "").Replace(" ", "").Replace(".csv", "").Replace("SPC", "");

            Label lbName = new Label();
            lbName.Content = File.filename.Replace("\"", "");

            spanel_FileName.Children.Add(lbName);
            spanel_SqlTable.Children.Add(lbSuggestion);


            foreach (string column in File.fileColumns)
            {
                Label lbCol = new Label();
                TextBox tsCol = new TextBox();
                ComboBox st = new ComboBox();

                suggestionCol = column.Replace("\"", "");
                actualCol = column.Replace("\"", "").Replace(" ", "");

                lbCol.Content = suggestionCol;
                tsCol.Text = actualCol;

                ObservableCollection<string> list = new ObservableCollection<string>();
                list.Add("datetime");
                list.Add("money");
                list.Add("bit");
                list.Add("varchar(50)");
                list.Add("varchar(250)");

                
                st.ItemsSource = list;
                String type;

                if (column.Contains("Date") || column.Contains("date"))
                {
                    type = "datetime";
                }
                else if (column.Contains("MarketCap")){
                    type = "money";
                }
                else if (column.Contains("Traded") || column.Contains("Confirmed"))
                {
                    type = "money";
                }
                else if (column.Contains("Settled") || column.Contains("Ordered"))
                {
                    type = "money";
                }
                else if (column.Contains("indicator")  || column.Contains("Indicator"))
                {
                    type = "bit";
                }
                else if (column.Contains("code") || column.Contains("Code"))
                {
                    type = "varchar(50)";
                }
                else {
                    type = "varchar(250)";
                }

                st.SelectedItem = type;
                typeCol = type;

                lbCol.Height = 30;
                tsCol.Height = 30;
                st.Height = 30;

                lbCol.Margin = new Thickness(20, 5, 20, 0);
                tsCol.Margin = new Thickness(20, 5, 20, 0);
                st.Margin = new Thickness(20, 5, 20, 0);

                lbCol.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;

                dt.Rows.Add(actualCol, suggestionCol, typeCol);
            }

            mainGridView.ItemsSource = dt.AsDataView();
        }

        private void loopThrough() {

            foreach (DataRow dr in dt.Rows) {
                foreach (var item in dr.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
