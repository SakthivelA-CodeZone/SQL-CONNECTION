using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace SQLCONNECTION
{
    /// <summary>
    /// Interaction logic for Executed.xaml
    /// </summary>
    public partial class Dataset : Window
    {
        string connected;

        int COUNTING = 0;
        public Dataset(string connection)
        {
            InitializeComponent();
            connected = connection;

            SqlConnection final = new SqlConnection();
            final.ConnectionString = @"data source=LAPHP640\SQLEXPRESS;initial catalog=INCREMENT;integrated security=true;encrypt=false";
            final.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = final;
            cmd1.CommandText = $"SELECT CID,CNAME FROM COURSE";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            dataAdapter1.Fill(DS);
            //combo 
            final.Close();//disconnect
            courselist.DisplayMemberPath = "CID";
            courselist.SelectedValuePath = "CNAME ";
            courselist.ItemsSource = DS.Tables[0].DefaultView;


        }

        private void txttest_Click(object sender, RoutedEventArgs e)
        {

            if (COUNTING > 0)
            {
                MessageBox.Show("EMAIL ALREADY EXISTS");
            }
            else
            {



                SqlConnection final = new SqlConnection();
                final.ConnectionString = @"data source=LAPHP640\SQLEXPRESS;initial catalog=INCREMENT;integrated security=true;encrypt=false";
                final.Open();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = final;
                cmd1.CommandText = $"SELECT COUNT(*) FROM EMPLOYEE WHARE EMAIL=@EMAIL";
                int COUNTING = (int)cmd1.ExecuteScalar();

                final.Close();



            }
        }

        private void txtLOGIN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection final = new SqlConnection();
                final.ConnectionString = @"data source=LAPHP640\SQLEXPRESS;initial catalog=INCREMENT;integrated security=true;encrypt=false";
                final.Open();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = final;
                cmd1.CommandText = $"SELECT COUNT(*) FROM EMPLOYEE WHARE EMAIL=@EMAIL and PASSWORD=@PASSWORD AND NAME=@NAME";

                cmd1.Parameters.AddWithValue(@"EMAIL", txtemail);
                cmd1.Parameters.AddWithValue(@"NAME", txtname);
                cmd1.Parameters.AddWithValue(@"age", txtage);
                int COUNTING = (int)cmd1.ExecuteScalar();

                // ANOHER WAY TO DO THE SAME THING

                bool VAL = COUNTING > 0 ? true : false;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);



            }

        }

        private void txtset_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection final = new SqlConnection();
            final.ConnectionString = @"data source=LAPHP640\SQLEXPRESS;initial catalog=INCREMENT;integrated security=true;encrypt=false";
            final.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = final;
            cmd1.CommandText = $"SELECT CID,CNAME FROM COURSE";
           SqlDataAdapter dataAdapter1= new SqlDataAdapter(cmd1);
            DataSet DS=new DataSet();
            dataAdapter1.Fill(DS);
            



        }

        private void courselist_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            SqlConnection final = new SqlConnection();
            final.ConnectionString = @"data source=LAPHP640\SQLEXPRESS;initial catalog=INCREMENT;integrated security=true;encrypt=false";
            final.Open();
            SqlCommand cmd1 = new SqlCommand("INSERT INTO DISCONNECT VALUES(@SNAME,@SAGE,@GAMIL",final);
            

            cmd1.Parameters.AddWithValue(@"SNAME", txtemail.Text);
            cmd1.Parameters.AddWithValue(@"SGMAIL", txtemail);
            cmd1.Parameters.AddWithValue(@"SAGE", txtage);
            
            int val2= cmd1.ExecuteNonQuery();
            if (val2 > 0)
            {
                MessageBox.Show("DATA INSERTED");
            }
            else
            {
                MessageBox.Show("DATA NOT INSERTED");
            }

        }
    }

        
    }
