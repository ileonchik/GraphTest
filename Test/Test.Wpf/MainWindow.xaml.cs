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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.WpfGraphControl;
using Test.PathFinder;

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

            foreach (var node in data.NodesList.Values)
            {
                graph.AddNode(new Node(node.UniqueId) {LabelText = node.Label});
            }
            foreach (var adj in data.Adjacencies)
            {
                graph.AddEdge(adj.Key, adj.Value);
            }
            graph.Attr.LayerDirection = LayerDirection.LR;
            graphViewer.Graph = graph; 
      
            var searcher = new DefaultFinder(data);
            var result = searcher.Search("1", "7");
            ShowPath(graphViewer, data, result);
        }

        private void ShowPath(GraphViewer graphViewer, Test.Common.Enities.Graph data, List<string> way)
        {
            Graph graph = new Graph();

            foreach (var nodeData in data.NodesList.Values)
            {
                var node = new Node(nodeData.UniqueId) { LabelText = nodeData.Label };
                node.Attr.FillColor = way.Contains(nodeData.UniqueId) ? Color.DarkGray : Color.White;
                graph.AddNode(node);
            }
            foreach (var adj in data.Adjacencies)
            {
                var edge = graph.AddEdge(adj.Key, adj.Value);
                edge.Attr.Color = way.Contains(adj.Key) && way.Contains(adj.Value) ? Color.Gray : Color.Black;
            }
            graph.Attr.LayerDirection = LayerDirection.LR;
            graphViewer.Graph = graph;

        }


    }
}
