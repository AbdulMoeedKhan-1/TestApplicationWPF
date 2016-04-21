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
using Telerik.Windows.Controls.GridView;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
            this.gridView.ItemsSource = new MyViewModel().Clubs;
        }      
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            gridView.Print(true);
        }

        private void PrintPreview_Click(object sender, RoutedEventArgs e)
        {
            RadPrintDocument document = new RadPrintDocument();
            document.HeaderHeight = 30;
            document.HeaderFont = new Font("Arial", 22);
            document.Logo = System.Drawing.Image.FromFile(@"C:\MyLogo.png");
            document.LeftHeader = "[Logo]";
            document.MiddleHeader = "Middle header";
            document.RightHeader = "Right header";
            document.ReverseHeaderOnEvenPages = true;
            document.FooterHeight = 30;
            document.FooterFont = new Font("Arial", 22);
            document.LeftFooter = "Left footer";
            document.MiddleFooter = "Middle footer";
            document.RightFooter = "Right footer";
            document.ReverseFooterOnEvenPages = true;
            document.AssociatedObject = this.radGridView1;
            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog(document);
            dialog.Show();
            gridView.PrintPreview();    
                   
        }
    }
}
