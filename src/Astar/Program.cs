using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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
            graph.Attr.BackgroundColor = Microsoft.Msagl.Drawing.Color.Gray;
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

            Microsoft.Msagl.Drawing.Label.DefaultFontSize = 4;

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
                    e.LabelText = r[2];
                }
                else
                {
                    var e = graph.AddEdge(r[0], r[1]);
                    e.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                    e.LabelText = r[2];
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
        private Dictionary<Tuple<string, string>, double> relationsDictionary;
        // nodes with its coordinate
        private Dictionary<string, Double[]> nodes;

        public Graph(List<string[]> relations, Dictionary<string, string[]> adjacency, Dictionary<string, Double[]> nodes)
        {
            this.adjacency = adjacency;
            this.nodes = nodes;
            this.relationsDictionary = new Dictionary<Tuple<string, string>, double>();
            foreach (var rel in relations)
            {
                var k1 = new Tuple<string, string>(rel[0], rel[1]);
                var k2 = new Tuple<string, string>(rel[1], rel[0]);
                if (!relationsDictionary.ContainsKey(k1)) this.relationsDictionary.Add(k1, Convert.ToDouble(rel[2]));
                if (!relationsDictionary.ContainsKey(k2)) this.relationsDictionary.Add(k2, Convert.ToDouble(rel[2]));
            }
        }
        public double G(String start, String n)
        {
            String[] from = { "0", start };
            double cost = 0;
            List<List<String>> simpulHidup = new List<List<String>>();
            List<string> dikunjungi = new List<string>();
            double distanceAtoN = 0;

            while (from[from.Count() - 1] != n && (simpulHidup.Any() || !dikunjungi.Any()))
            {
                dikunjungi.Add(from[from.Count() - 1]);

                String[] children = adjacency[from[from.Count() - 1]];
                foreach (var child in children)
                {
                    if (!dikunjungi.Contains(child))
                    {
                        var jalur = new Tuple<string, string>(child, from[from.Count() - 1]);
                        String distance = Convert.ToString(relationsDictionary[jalur] + distanceAtoN);
                        simpulHidup.Add(from.ToList<string>());
                        simpulHidup[simpulHidup.Count - 1][0] = distance;
                        simpulHidup[simpulHidup.Count - 1].Add(child);
                    }
                }

                var simpulMati = simpulHidup[0];
                double minDistance = 0;

                foreach (var node in simpulHidup)
                {
                    double dist = Convert.ToDouble(node[0]);
                    if (dist < minDistance || minDistance == 0)
                    {
                        minDistance = dist;
                        distanceAtoN = dist;
                        from = node.ToArray();
                        simpulMati = node;
                    }
                }
                simpulHidup.Remove(simpulMati);
            }

            cost = Convert.ToDouble(from[0]);
            return cost;
        }
        public double H(String n, string goal)
        {
            return euclideanDist(nodes[n][0], nodes[n][1], nodes[goal][0], nodes[goal][1]);
        }
        public double F(String start, String n, String goal)
        {
            return G(start, n) + H(n, goal);
        }
        public List<string> Astar(string start, string goal)
        {
            List<string> dikunjungi = new List<string>();
            String[] from = { "0", start };
            List<List<String>> simpulHidup = new List<List<String>>();


            while (from[from.Count() - 1] != goal && (simpulHidup.Any() || !dikunjungi.Any()))
            {
                dikunjungi.Add(from[from.Count() - 1]);
                String[] children = adjacency[from[from.Count() - 1]];
                foreach (var child in children)
                {
                    if (!dikunjungi.Contains(child))
                    {
                        String bobot = Convert.ToString(F(start, child, goal));
                        simpulHidup.Add(from.ToList<string>());
                        simpulHidup[simpulHidup.Count - 1][0] = bobot;
                        simpulHidup[simpulHidup.Count - 1].Add(child);
                    }
                }

                double bobotMin = Convert.ToDouble(simpulHidup[0][0]);
                var simpulMati = simpulHidup[0];

                foreach (var node in simpulHidup)
                {
                    double dist = Convert.ToDouble(node[0]);
                    if (dist < bobotMin)
                    {
                        bobotMin = dist;
                        from = node.ToArray();
                        simpulMati = node;
                    }
                }

                simpulHidup.Remove(simpulMati);
            }
            return from.ToList<string>();
        }
        public double euclideanDist(Double x1, Double y1, Double x2, Double y2) {
            return Math.Sqrt(Math.Pow(x1-x2,2)+Math.Pow(y1-y2,2));
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