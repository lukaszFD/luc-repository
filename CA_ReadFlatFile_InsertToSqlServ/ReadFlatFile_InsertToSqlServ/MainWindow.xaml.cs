using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ReadFlatFile_InsertToSqlServ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = ConvertToDataTable();

                foreach (DataRow dr in dt.Rows)
                {

                        using (SqlConnection con = new SqlConnection(@"Data Source=;Initial Catalog=;Integrated Security=True"))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand(@"INSERT INTO dbo.table(
                           Column1
                        ) 
                            VALUES 
                        (
                           @test
                          
                        )", con);

                            cmd.Parameters.AddWithValue("@test", dr[0].ToString());

                            cmd.ExecuteNonQuery();
                        con.Close();
                        }
                    
                }
                MessageBox.Show("robione");
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public DataTable ConvertToDataTable()
        {

            string filePath = @"C:\Users\name\Documents\test.csv";
            int numberOfColumns = 12;

            DataTable tbl = new DataTable();

            for (int col = 0; col < numberOfColumns; col++)
                tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));


            string[] lines = System.IO.File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                var cols = line.Split(',');

                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < 3; cIndex++)
                {
                    dr[cIndex] = cols[cIndex];
                }

                tbl.Rows.Add(dr);
            }

            return tbl;
        }
    }
}
