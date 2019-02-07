using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace loginScreen
{
    /// <summary>
    /// Interaction logic for loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        public loginWindow()
        {
            InitializeComponent();
        }

        private void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConn =
                new SqlConnection(
                    @"Data Source=LAPTOP-F9H6RS0J\SQLEXPRESS;Initial Catalog=loginDB;Integrated Security=True");
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
                String query = "Select Count(1) from tblUser Where Username =@Username AND Password =@Password";
                SqlCommand SqlCmd = new SqlCommand(query, sqlConn);
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                SqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int count = Convert.ToInt32(SqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();


                }
                else
                {
                    MessageBox.Show("username or password is incorrect");

                }
            }
            catch (Exception exception)


            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlConn.Close();
            }
          }
        }
    }
