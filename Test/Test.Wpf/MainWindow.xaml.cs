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
        Button calculate = new Button();
        Grid mainGrid = new Grid();
        DockPanel graphViewerPanel = new DockPanel();
        ToolBar toolBar = new ToolBar();
        GraphViewer graphViewer = new GraphViewer();
        public MainWindow()
        {
            InitializeComponent();
  
           
            calculate.Click+=CalculateOnClick;
            calculate.Content = "Calculate";
            calculate.IsEnabled = false;
            Loaded += Window_Loaded;
            graphViewerPanel.ClipToBounds = true;
            mainGrid.Children.Add(toolBar);
            toolBar.VerticalAlignment = VerticalAlignment.Top;
            toolBar.Items.Add(calculate);
            mainGrid.Children.Add(graphViewerPanel);
            graphViewer.BindToPanel(graphViewerPanel);
            Content = mainGrid;

        }

        private void CalculateOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var respository = new GraphRepository();
            var data = respository.Get();
            var finder = FinderFactory.GetFinder(FinderType.Dijkstra, data);
            var result = finder.Find(start, stop);
            ShowPath(graphViewer, data, result, start, stop);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var respository = new GraphRepository();
            var data = respository.Get();

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
            graphViewer.MouseDown += graphViewer_MouseDown;
       
        }

        private string start;
        private string stop;
        void graphViewer_MouseDown(object sender, MsaglMouseEventArgs e)
        {
            
            var node = graphViewer.ObjectUnderMouseCursor as IViewerNode;
            if (node != null)
            {
                if (string.IsNullOrEmpty(start))
                {
                    var drawingNode = (Node) node.DrawingObject;
                    drawingNode.Attr.FillColor = Color.Green;
                    start = node.Node.Id;
                }
                else
                {
                    if (node.Node.Id != start)
                    {
                        var drawingNode = (Node) node.DrawingObject;
                        drawingNode.Attr.FillColor = Color.Red;
                        stop = node.Node.Id;
                        calculate.IsEnabled = true;
                    }
                }
            }
        }

        private void ShowPath(GraphViewer graphViewer, Test.Common.Enities.Graph data, List<string> way, string start, string stop)
        {
            Graph graph = new Graph();

            foreach (var nodeData in data.NodesList.Values)
            {
                var node = new Node(nodeData.UniqueId) { LabelText = nodeData.Label };
                if ((nodeData.UniqueId != start) && (nodeData.UniqueId != stop))
                {
                    node.Attr.FillColor = way.Contains(nodeData.UniqueId) ? Color.DarkGray : Color.White;
                }
                else
                {
                    node.Attr.FillColor = nodeData.UniqueId == start ? Color.Green : Color.Red;
                }

             
              
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
