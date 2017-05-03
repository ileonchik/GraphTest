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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.WpfGraphControl;

namespace Test.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DockPanel Panel = new DockPanel();
        public MainWindow()
        {
            InitializeComponent();
            this.Content = Panel;
            Loaded += Window_Loaded;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var respository = new GraphRepository();
            var data = respository.Get();
            GraphViewer graphViewer = new GraphViewer();
            graphViewer.BindToPanel(Panel);
            Graph graph = new Graph();

            foreach (var adj in data.Adjacencies)
            {
                graph.AddEdge(adj.Key,adj.Value);
            }
            graph.Attr.LayerDirection = LayerDirection.LR;
            graphViewer.Graph = graph; // throws exception
        }
    }
}
