using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
using ParseReportResharper;
using FinalDecisionGatingParameter;

namespace StaticAnalysisGUI
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            string username, reponame, level;
            username = User.Text;
            reponame = Repo.Text;
            level = Level.Text;
            WebClient analyser = new WebClient();
            string url =string.Format(
                "http://localhost:60202/Service1.svc/StaticAnalyserTool/Absolute/{0}/{1}/{2}",
                username,reponame,level);
          
            byte[] data = analyser.DownloadData(url);
            
            MessageBox.Show(Encoding.ASCII.GetString(data));

            analyser.Dispose();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Scroller.Text = "Analyzing...";
            string report = File.ReadAllText("C:" + "\\Users\\" + Environment.UserName +@"\Desktop\Reports\ToolErrorDuplicationReport.txt");
            Scroller.Text = report;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Service1 obj=new Service1();
            int issues = obj.ParseResharperErrorReport();
            int dups = obj.ParseResharperDuplicationReport();
            tb1.Text = dups.ToString();
            tb2.Text = issues.ToString();
        }

        
    }
}
