﻿using System;
using System.Collections.Generic;
using Microsoft.Msagl.Drawing;
using SvgLayerSample.Svg;

namespace SvgLayerSample {
    internal class Examples {
        internal static string Example_Simple() {
            var drawingGraph = new Graph();
            drawingGraph.AddNode(new ComponentNode("CRM", "CRM", "some cloud service", "This is the CRM component with which we are going to serve customers."));

            var diagram = new Diagram(drawingGraph);
            diagram.Run();
            return diagram.ToString();
        }

        internal static string Example_Simple02() {
            var drawingGraph = new Graph();
            drawingGraph.AddNode(new ComponentNode("CRM", "CRM", "some cloud service", "This is the CRM component with which we are going to serve customers."));
            drawingGraph.AddNode(new ComponentNode("Database", "Database", "mssql", "The database which will hold the data."));

            drawingGraph.AddEdge("CRM", "ole db", "Database");

            var diagram = new Diagram(drawingGraph);
            diagram.Run();
            return diagram.ToString();
        }

        internal static string Example_Simple03() {
            var drawingGraph = new Graph();
            drawingGraph.AddNode(new ComponentNode("CRM", "CRM", "some cloud service", "This is the CRM component with which we are going to serve customers."));
            drawingGraph.AddNode(new ComponentNode("Database", "Database", "mssql", "The database which will hold the data."));
            drawingGraph.AddEdge("CRM", "ole db", "Database");

            var subgraph1 = new Subgraph("Cloud");
            subgraph1.AddNode(drawingGraph.FindNode("CRM"));

            var subgraph2 = new Subgraph("On Prem");
            subgraph2.AddNode(drawingGraph.FindNode("Database"));

            drawingGraph.RootSubgraph.AddSubgraph(subgraph1);
            drawingGraph.RootSubgraph.AddSubgraph(subgraph2);


            var diagram = new Diagram(drawingGraph);
            diagram.Run();
            return diagram.ToString();
        }

        internal static string Example01() {
            var drawingGraph = new Graph();

            drawingGraph.AddNode(new ComponentNode("Foo"));
            drawingGraph.AddNode(new ComponentNode("Bar", "Bar Component", "[Azure Functions]", "This is the Bar component, really really important!"));
            drawingGraph.AddNode(new ComponentNode("Component01", "First Component", null, "Bizar"));
            drawingGraph.AddNode(new ComponentNode("Component02"));
            drawingGraph.AddNode(new LabeledNode("Component05", new List<string> { "Component Nr. 5" }));
            drawingGraph.AddNode(new ComponentNode("Component06"));
            drawingGraph.AddNode(new ComponentNode("Component08"));

            drawingGraph.AddNode(new ComponentNode("Component03"));
            drawingGraph.AddNode(new ComponentNode("Component04"));
            drawingGraph.AddNode(new ComponentNode("Component07"));

            var subGraph = new Subgraph("Section01");
            subGraph.AddNode(drawingGraph.FindNode("Component02"));
            subGraph.AddNode(drawingGraph.FindNode("Component07"));
            subGraph.AddNode(drawingGraph.FindNode("Bar"));
            subGraph.AddNode(drawingGraph.FindNode("Component01"));
            drawingGraph.RootSubgraph.AddSubgraph(subGraph);


            var labels = new List<SvgLabel> {
                new SvgLabel("Component Nr. 9") {
                    Font = new System.Drawing.Font("Consolas", 20f, System.Drawing.FontStyle.Bold),
                    Color = Color.Azure
                },
                new SvgLabel("This is the description. It can become quite large and if all goes to plan; it will wrap itself.") {
                    Color = Color.MediumOrchid
                }
            };
            var labeledNode = new LabeledNode("Component09", labels);
            labeledNode.SvgElement.BackgroundColor = Color.Maroon;
            drawingGraph.AddNode(labeledNode);

            drawingGraph.AddEdge("Foo", "Something", "Bar");
            drawingGraph.AddEdge("Bar", "Bar_Component01", "Component01");
            drawingGraph.AddEdge("Bar", "Bar_Component02", "Component02");
            drawingGraph.AddEdge("Component01", "Bar_Component01", "Component03");
            drawingGraph.AddEdge("Component01", "Bar_Component01", "Component02");
            drawingGraph.AddEdge("Component02", "Bar_Component01", "Component04");
            drawingGraph.AddEdge("Component02", "Bar_Component01", "Component05");
            drawingGraph.AddEdge("Component02", "Bar_Component01", "Component06");
            drawingGraph.AddEdge("Component02", "Bar_Component01", "Component07");
            drawingGraph.AddEdge("Component02", "Bar_Component01", "Component08");
            drawingGraph.AddEdge("Component03", "Bar_Component01", "Component09");


            var diagram = new Diagram(drawingGraph);
            diagram.Run();
            return diagram.ToString();
        }

        
    }
}