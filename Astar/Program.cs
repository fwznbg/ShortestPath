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

        public Graph(List<string[]> relations, Dictionary<string, string[]> adjacency)
        {
            this.adjacency = adjacency;
            this.relationsDictionary = new Dictionary<Tuple<string, string>, double>();
            foreach(var rel in relations)
            {
                var k1 = new Tuple<string, string>(rel[0], rel[1]);
                var k2 = new Tuple<string, string>(rel[1], rel[0]);
                if (!relationsDictionary.ContainsKey(k1)) this.relationsDictionary.Add(k1, Convert.ToDouble(rel[2]));
                if (!relationsDictionary.ContainsKey(k2)) this.relationsDictionary.Add(k2, Convert.ToDouble(rel[2]));
            }
        }
        //public double G(String start, String n)
        //{
        //    String[] from = { start };
        //    double cost = 0;

        //    List<List<String>> simpulHidup = new List<List<String>>();
        //    List<string> dikunjungi = new List<string>();

        //    String[] children = adjacency[from[from.Count() - 1]];
        //    foreach (var child in children)
        //    {
        //        var jalur = new Tuple<string, string>(child, from[from.Count() - 1]);
        //        String distance = Convert.ToString(relationsDictionary[jalur]);
        //        simpulHidup.Add(new List<string> { distance });
        //        simpulHidup[simpulHidup.Count - 1].Add(from[from.Count() - 1]);
        //        simpulHidup[simpulHidup.Count - 1].Add(child);

        //    }

        //    dikunjungi.Add(from[from.Count() - 1]);

        //    while (from[from.Count() - 1] != n)
        //    {
        //        double minDistance = 0;
        //        var simpulMati = simpulHidup[0];
        //        foreach (var node in simpulHidup)
        //        {
        //            double dist = Convert.ToDouble(node[0]);
        //            if (dist < minDistance || minDistance == 0)
        //            {
        //                minDistance = dist;
        //                from = node.ToArray();
        //                simpulMati = node;
        //            }
        //        }

        //        simpulHidup.Remove(simpulMati);

        //        children = adjacency[from[from.Count() - 1]];
        //        foreach (var child in children)
        //        {
        //            if (!dikunjungi.Contains(child))
        //            {
        //                var jalur = new Tuple<string, string>(child, from[from.Count() - 1]);
        //                String distance = Convert.ToString(relationsDictionary[jalur] + minDistance);
        //                simpulHidup.Add(from.ToList<string>());
        //                simpulHidup[simpulHidup.Count - 1][0] = distance;
        //                simpulHidup[simpulHidup.Count - 1].Add(child);
        //            }
        //        }

        //        dikunjungi.Add(from[from.Count() - 1]);
        //    }

        //    cost = Convert.ToDouble(from[0]);
        //    return cost;
        //}
        public double G(String start, String n)
        {
            String[] from = { "0", start };
            double cost = 0;
            List<List<String>> simpulHidup = new List<List<String>>();
            List<string> dikunjungi = new List<string>();
            double minDistance = 0;

            while (from[from.Count() - 1] != n)
            {
                dikunjungi.Add(from[from.Count() - 1]);

                String[] children = adjacency[from[from.Count() - 1]];
                foreach (var child in children)
                {
                    if (!dikunjungi.Contains(child))
                    {
                        var jalur = new Tuple<string, string>(child, from[from.Count() - 1]);
                        String distance = Convert.ToString(relationsDictionary[jalur] + minDistance);
                        simpulHidup.Add(from.ToList<string>());
                        simpulHidup[simpulHidup.Count - 1][0] = distance;
                        simpulHidup[simpulHidup.Count - 1].Add(child);
                    }
                }

                var simpulMati = simpulHidup[0];

                foreach (var node in simpulHidup)
                {
                    double dist = Convert.ToDouble(node[0]);
                    if (dist < minDistance || minDistance == 0)
                    {
                        minDistance = dist;
                        from = node.ToArray();
                        simpulMati = node;
                    }
                }
                Debug.WriteLine(from[0]);
                simpulHidup.Remove(simpulMati);
            }

            cost = Convert.ToDouble(from[0]);
            return cost;
        }
        public double H(String n, string goal)
        { 
            String from = n;
            double heuristik = 0;
            List<string> dikunjungi = new List<string>();

            while (from != goal)
            {
                String[] children = adjacency[from];

                var rel = new Tuple<string, string>(children[0], from);
                double greedyBFS = 0;
                foreach (var child in children)
                {
                    if (!dikunjungi.Contains(child))
                    {
                        var relation = new Tuple<string, string>(child, from);
                        double distance = relationsDictionary[relation];
                        if (distance < greedyBFS || greedyBFS == 0)
                        {
                            greedyBFS = distance;
                            rel = relation;
                        }
                    }
                }
                
                dikunjungi.Add(rel.Item2);
                heuristik += greedyBFS;
                from = rel.Item1;
            }

            return heuristik;
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


            while (from[from.Count()-1] != goal)
            {
                dikunjungi.Add(from[from.Count() - 1]);
                String[] children = adjacency[from[from.Count() - 1]];
                foreach(var child in children)
                {
                    if (!dikunjungi.Contains(child))
                    {
                        String bobot = Convert.ToString(F(start, child, goal));
                        simpulHidup.Add(from.ToList<string>());
                        simpulHidup[simpulHidup.Count - 1][0] = bobot;
                        simpulHidup[simpulHidup.Count - 1].Add(child);
                    }
                }

                double bobotMin = 0;
                var simpulMati = simpulHidup[0];

                foreach(var node in simpulHidup)
                {
                    double dist = Convert.ToDouble(node[0]);
                    if (dist < bobotMin || bobotMin == 0)
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
    }

    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Dictionary<string, string[]> adjacency = new Dictionary<string, string[]>();
            adjacency["A"] = new string[] { "Z", "S", "T" };
            adjacency["Z"] = new string[] { "O", "A" };
            adjacency["S"] = new string[] { "O", "F", "R", "A" };
            adjacency["T"] = new string[] { "A", "L" };
            adjacency["O"] = new string[] { "Z", "S" };
            adjacency["F"] = new string[] { "B", "S" };
            adjacency["R"] = new string[] { "S", "C", "P" };
            adjacency["L"] = new string[] { "M", "T" };
            adjacency["M"] = new string[] { "D", "L" };
            adjacency["C"] = new string[] { "P", "R", "D" };
            adjacency["P"] = new string[] { "C", "B", "R" };
            adjacency["B"] = new string[] { "U", "F", "G", "P" };
            adjacency["D"] = new string[] { "M", "C" };
            adjacency["G"] = new string[] { "B"};
            adjacency["U"] = new string[] { "B", "H", "V" };
            adjacency["H"] = new string[] { "U", "E" };
            adjacency["E"] = new string[] { "H"};
            adjacency["V"] = new string[] { "U", "I" };
            adjacency["I"] = new string[] { "V", "N" };
            adjacency["N"] = new string[] { "I"};

            List<string[]> relations = new List<string[]> { };
            relations.Add(new string[] { "A", "Z", "75" });
            relations.Add(new string[] { "Z", "A", "75" });
            relations.Add(new string[] { "O", "Z", "71" });
            relations.Add(new string[] { "Z", "O", "71" });
            relations.Add(new string[] { "S", "O", "151" });
            relations.Add(new string[] { "O", "S", "151" });
            relations.Add(new string[] { "A", "S", "140" });
            relations.Add(new string[] { "S", "A", "140" });
            relations.Add(new string[] { "S", "R", "80" });
            relations.Add(new string[] { "R", "S", "80" });
            relations.Add(new string[] { "S", "F", "99" });
            relations.Add(new string[] { "F", "S", "99" });
            relations.Add(new string[] { "F", "B", "211" });
            relations.Add(new string[] { "B", "F", "211" });
            relations.Add(new string[] { "P", "B", "101" });
            relations.Add(new string[] { "B", "P", "101" });
            relations.Add(new string[] { "P", "R", "97" });
            relations.Add(new string[] { "R", "P", "97" });
            relations.Add(new string[] { "P", "C", "138" });
            relations.Add(new string[] { "C", "P", "138" });
            relations.Add(new string[] { "C", "R", "146" });
            relations.Add(new string[] { "R", "C", "146" });
            relations.Add(new string[] { "D", "C", "120" });
            relations.Add(new string[] { "C", "D", "120" });
            relations.Add(new string[] { "M", "D", "75" });
            relations.Add(new string[] { "D", "M", "75" });
            relations.Add(new string[] { "M", "L", "70" });
            relations.Add(new string[] { "L", "M", "70" });
            relations.Add(new string[] { "T", "L", "111" });
            relations.Add(new string[] { "L", "T", "111" });
            relations.Add(new string[] { "A", "T", "118" });
            relations.Add(new string[] { "T", "A", "118" });
            relations.Add(new string[] { "U", "B", "85" });
            relations.Add(new string[] { "B", "U", "85" });
            relations.Add(new string[] { "B", "G", "90" });
            relations.Add(new string[] { "G", "B", "90" });
            relations.Add(new string[] { "U", "H", "98" });
            relations.Add(new string[] { "H", "U", "98" });
            relations.Add(new string[] { "E", "H", "86" });
            relations.Add(new string[] { "H", "E", "86" });
            relations.Add(new string[] { "U", "V", "142" });
            relations.Add(new string[] { "V", "U", "142" });
            relations.Add(new string[] { "I", "V", "92" });
            relations.Add(new string[] { "V", "I", "92" });
            relations.Add(new string[] { "N", "I", "87" });
            relations.Add(new string[] { "I", "N", "87" });

            Graph g = new Graph(relations, adjacency);

            //List<string> ucs = g.Astar("A", "B");
            //foreach (var x in ucs)
            //{
            //    Debug.WriteLine(x);
            //}

            double x = g.G("A", "B");
            Debug.WriteLine(x);

            Debug.WriteLine("Succes");

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); 
        }
    }
}
