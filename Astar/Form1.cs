using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace Astar
{
    public partial class Form1 : Form
    {
        // num of relation
        int nRelations = 0;
        
        // contains all relations and its distance [from, to, distance]
        List<string[]> relations = new List<string[]>();

        // contains all unique nodes
        List<string> nodes = new List<string>();

        // nodes dictionary contains node's name as key, and its coordinat
        Dictionary<string, int[]> nodesDictionary = new Dictionary<string, int[]>();

        // adjacency dict, contains parent as key, children as values
        Dictionary<string, string[]> adjacency = new Dictionary<string, string[]>();

        // open file
        OpenFileDialog openFile = new OpenFileDialog();

        //visualizer
        Visualizer v = new Visualizer();

        public Form1()
        {
            InitializeComponent();
            v.Initialize(graphVis); // initialize graph
        }

        private void chooseGraph_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {   
                    // open .txt file
                    StreamReader sr = new StreamReader(openFile.FileName);
                    int lineNum = 0;
                    string line = "";

                    if (v.Viewer.Graph != null)
                    {
                        v.ClearScreen(nodes);
                    }

                    nodes.Clear();
                    relations.Clear();
                    fromdropdown.Items.Clear();

                    while (line != null)
                    {
                        // read every line
                        line = sr.ReadLine();

                        // skip 1st line (num of relation)
                        if (line != null)
                        {
                            if (lineNum == 0)
                            {
                                nRelations = Convert.ToInt32(line);

                                Debug.WriteLine("Banyak relasi {0}", nRelations);
                            }
                            else if(lineNum <= nRelations)
                            {
                                // array of splitted line
                                String[] splitLine = new String[3];
                                // split every line read
                                splitLine = line.Split(' ');
                                int[] koordinat = { Convert.ToInt32(splitLine[0]), Convert.ToInt32(splitLine[1]) };

                                nodesDictionary.Add(splitLine[2], koordinat);
                                nodes.Add(splitLine[2]);

                                Debug.WriteLine("Node ke {0}: {1}", lineNum, nodes[lineNum-1]);
                                Debug.WriteLine("Node Directory key {0}, koordinat({1}, {2})", nodesDictionary.Keys.ElementAt(lineNum - 1), nodesDictionary.Values.ElementAt(lineNum-1)[0], nodesDictionary.Values.ElementAt(lineNum - 1)[1]);

                            }
                            else    // adjacency 
                            {
                                String[] splitLine = new String[nRelations];
                                splitLine = line.Split(' ');
                                
                                int idxFrom = lineNum - 1 - nRelations;
                                Debug.WriteLine("line ke {0}", lineNum-nRelations);

                                List<String> child = new List<String>();

                                for (int i = 0; i<nRelations; i++)
                                {
                                    Debug.WriteLine(i);
                                    int currentValue = Convert.ToInt32(splitLine[i]);

                                    if ((i<= lineNum - nRelations - 1) && currentValue == 1)
                                    {
                                        int idxTo = i;

                                        String[] fromTo = { nodes[idxFrom], nodes[idxTo], "" };

                                        double absis = Convert.ToDouble(nodesDictionary[fromTo[0]][0]) - Convert.ToDouble(nodesDictionary[fromTo[1]][0]);
                                        double ordinat = Convert.ToDouble(nodesDictionary[fromTo[0]][1]) - Convert.ToDouble(nodesDictionary[fromTo[1]][1]);

                                        double distance = Math.Sqrt(Math.Pow(absis, 2.00) + Math.Pow(ordinat, 2.00));

                                        fromTo[2] = Convert.ToString(Math.Round(distance, 2));

                                        Debug.WriteLine("idx from {0}", idxFrom);
                                        Debug.WriteLine("idx to {0}", idxTo);
                                         
                                        relations.Add(fromTo);
                                        Debug.WriteLine("Relation from {0} to {1}. jaraknya {2}", relations[relations.Count-1][0], relations[relations.Count - 1][1], relations[relations.Count - 1][2]);
                                    }
                                    
                                    if (currentValue == 1)
                                    {
                                        child.Add(nodes[i]);
                                    }
                                }
                                adjacency[nodes[idxFrom]] = child.ToArray();


                            }
                        }
                        lineNum++;
                    }

                    nodes.Sort();
                    foreach (var node in nodes)
                    {
                        fromdropdown.Items.Add(node);
                    }

                    // display filename
                    filename.Text = Path.GetFileName(openFile.FileName);

                    //var a = nodes.SelectedItem;
                    //g = new Graph(nRelations);
                    //g.fromRead(nodes, relations);

                    v.Initialize(graphVis);

                    v.Start(nodes, relations);

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Failed to Open File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            // failed to open file
            else
            {
                MessageBox.Show("Choose .txt File", "Failed to Open File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // to filter only .txt file
            openFile.Filter = "Text Files (.txt) | *.txt";
        }

        private void fromdropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clear "To dropdown
            todropdown.Items.Clear();
            // chosen point "from" dropdown
            String from = fromdropdown.Text;

            // add unselected account to "Explore Friends With" dropdown
            foreach (var item in fromdropdown.Items)
            {
                if (item.ToString() == from) continue;
                todropdown.Items.Add(item);
            }
        }
    }
}
