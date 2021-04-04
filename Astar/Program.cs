using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astar
{
    public class Visualizer
    {
        private Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        private Microsoft.Msagl.Drawing.Graph graph;
        private Panel panel;
        public Visualizer() // visualizer's constructor
        {
            viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            graph = new Microsoft.Msagl.Drawing.Graph("graph");
        }
        public Microsoft.Msagl.GraphViewerGdi.GViewer Viewer //viewer getter
        {
            get { return viewer; }
        }
        public Microsoft.Msagl.Drawing.Graph Graph // graph getter
        {
            get { return graph; }
        }

        public void Initialize(Panel pnl) // initialize visualizer on pnl panel
        {
            panel = pnl;
            panel.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(viewer);
            panel.ResumeLayout();
        }
        public void SetNodeColor(String node, Microsoft.Msagl.Drawing.Color color)  // set node's color
        {
            graph.FindNode(node).Attr.FillColor = color;
        }
        public void StartViewer() // set viewer.Graph to graph
        {
            viewer.Graph = graph;
        }
        public void Start(List<string> nodes, List<string[]> relations) // starting visulizer
        {
            Microsoft.Msagl.Drawing.Label.DefaultFontSize = 4;

            // add every relation to graph
            foreach (var r in relations)
            {
                var e = graph.AddEdge(r[0], r[1]);
                e.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                e.LabelText = r[2];
            }

            // coloring every nodes
            foreach (var n in nodes)
            {
                Microsoft.Msagl.Drawing.Color lightslategray = Microsoft.Msagl.Drawing.Color.LightSlateGray;
                SetNodeColor(n, lightslategray);
            }
            StartViewer();
        }
        public void ClearScreen(List<string> nodes) // clear visualizer (back to initialize-like state)
        {
            // remove every node
            foreach (var n in nodes)
            {
                Microsoft.Msagl.Drawing.Node node = graph.FindNode(n);
                graph.RemoveNode(node);
                ;
            }
            //set viewer's graph to null
            viewer.Graph = null;
        }

        public void VisualizePath(List<string> nodes, List<string[]> relations, List<string> Path) // visualize path on graph
        {
            ClearScreen(nodes);   // clear screen before visualize
            // add every relations to graph
            foreach (var r in relations)
            {
                bool isDestination = (Path.IndexOf(r[1]) - Path.IndexOf(r[0]) == 1) || (Path.IndexOf(r[1]) - Path.IndexOf(r[0]) == -1);

                // if relation is the destionation 
                if (Path.Contains(r[0]) && Path.Contains(r[1]) && isDestination)
                {
                    var e = graph.AddEdge(r[0], r[1]);
                    e.Attr.Color = Microsoft.Msagl.Drawing.Color.White;
                    e.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                }
                else
                {
                    var e = graph.AddEdge(r[0], r[1]);
                    e.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                }
            }

            // coloring every nodes
            foreach (var n in nodes)
            {
                // if path get trough the node, set node's color white
                if (Path.Contains(n))
                {
                    Microsoft.Msagl.Drawing.Color white = Microsoft.Msagl.Drawing.Color.White;
                    SetNodeColor(n, white);
                }
                else
                {
                    Microsoft.Msagl.Drawing.Color lightslategray = Microsoft.Msagl.Drawing.Color.LightSlateGray;
                    SetNodeColor(n, lightslategray);
                }
            }
            StartViewer();
        }
    }

    public class Graph
    {
        private Dictionary<string, string[]> adjacency;
        // [from, to] as key, distace as value
        private Dictionary<string[], double> relationsDictionary;

        public Graph(List<string[]> relations, Dictionary<string, string[]> adjacency)
        {
            this.adjacency = adjacency;
            foreach(var rel in relations)
            {
                String[] k1 = { rel[0], rel[1] };
                String[] k2 = { rel[1], rel[0] };
                this.relationsDictionary.Add(k1, Convert.ToDouble(rel[2]));
                this.relationsDictionary.Add(k2, Convert.ToDouble(rel[2]));
            }
        }
        public double G(String start, String n)
        {
            String from = start;
            double cost = 0;

            List<String[]> simpulHidup = new List<string[]>();

            while(from != n)
            {
                String[] children = adjacency[from];
                foreach (var child in children)
                {
                    String[] jalur = { child, from };
                    String[] distance = { Convert.ToString(relationsDictionary[jalur]) };
                    simpulHidup.Add(distance);
                    // simpulHidup[simpulHidup.Count - 1][(simpulHidup[simpulHidup.Count-1]).Count] = from;
                }
            }

            return cost;
        }
        public double H(String n, string goal)
        { 
            String from = n;
            double heuristik = 0;

            while (from != goal)
            {
                String[] children = adjacency[from];

                String[] rel = { children[0], from };
                double greedyBFS = relationsDictionary[rel];

                foreach (var child in children)
                {
                    String[] relation = { child, from };
                    double distance = relationsDictionary[relation];
                    if (distance < greedyBFS)
                    {
                        greedyBFS = distance;
                        rel = relation;
                    }
                }

                heuristik += greedyBFS;
                from = rel[0];
            }

            return heuristik;
        }
        public double F(String start, String n, String goal)
        {
            return G(start, n) + H(n, goal);
        }

    }

    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
