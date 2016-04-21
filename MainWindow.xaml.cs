using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using TestApplicationWPF.WPFTestDatabaseDataSetTableAdapters;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _previewWindowXaml =
  @"<Window
        xmlns                 ='http://schemas.microsoft.com/netfx/2007/xaml/presentation'
        xmlns:x               ='http://schemas.microsoft.com/winfx/2006/xaml'
        Title                 ='Print Preview - @@TITLE'
        Height                ='200'
        Width                 ='300'
        WindowStartupLocation ='CenterOwner'>
        <DocumentViewer Name='dv1'/>
     </Window>";

        WPFTestDatabaseDataSet db1 = new WPFTestDatabaseDataSet();
        UserTableAdapter db = new UserTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txt_username.Text) || String.IsNullOrEmpty(txt_password.Password))
            {
                MessageBox.Show("Please provide a username and password", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Validating User
                var d = db.GetData();
                bool isVerified = false;
                for (int i = 0; i < d.Count && isVerified == false; i++)
                {
                    var user = d[i];
                    if (user.Username == txt_username.Text && user.Password == txt_password.Password)
                        isVerified = true;
                    else
                        isVerified = false;
                }
                if (isVerified)
                {
                    HomePage hp = new HomePage();
                    hp.Show();
                    this.Close();
                }                                        
                else
                {
                    MessageBox.Show("Not Verified");
                }                    
            }
        }
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }       
    }
}
