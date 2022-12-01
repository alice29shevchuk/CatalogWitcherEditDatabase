using System;
using System.Collections.Generic;
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

namespace CatalogWitcherEditDatabase.View
{
    /// <summary>
    /// Логика взаимодействия для Adding.xaml
    /// </summary>
    public partial class Adding : Window
    {
        public Adding()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Singleton singleton = Singleton.getInstance();
            using (SqlConnection conn = singleton.SqlConnectionFunction())
            {
                conn.Open();
                string commStr = $"insert into [Characters]([Name],[Sex],[Race],[Occupation],[Belonging],[Description],[Img],[CharaptersId]) values({this._name.Text},{this._sex.Text},{this._race.Text},{this._occup.Text},{this._belong.Text},{this._desc.Text},{this._img.Text},{this._chapterId.Text})";
                using (SqlCommand command = new SqlCommand(commStr, conn))
                {
                    SqlDataReader sqlData = command.ExecuteReader();

                }
            }
        }
    }
}
