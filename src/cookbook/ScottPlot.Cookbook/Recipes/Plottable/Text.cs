﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ScottPlot.Cookbook.Recipes.Plottable
{
    public class TextQuickstart : IRecipe
    {
        public string Category => "Plottable: Text";
        public string ID => "text_quickstart";
        public string Title => "Text";
        public string Description =>
            "The Text plottable displays a string at an X/Y coordinate in unit space. " +
            "Unlike the Annotation plottable, text moves when the axes are adjusted.";

        public void ExecuteRecipe(Plot plt)
        {
            int pointCount = 51;
            double[] x = DataGen.Consecutive(pointCount);
            double[] sin = DataGen.Sin(pointCount);
            double[] cos = DataGen.Cos(pointCount);

            plt.PlotScatter(x, sin);
            plt.PlotScatter(x, cos);

            plt.AddText("sample text", 10, .5, size: 16, color: Color.Blue);
        }
    }

    public class TextAlignment : IRecipe
    {
        public string Category => "Plottable: Text";
        public string ID => "text_alignment";
        public string Title => "Text Alignment and Rotation";
        public string Description =>
            "Advanced options are available to customize rotation and alignment. " +
            "Note that if rotation is used, alignment is ignored.";

        public void ExecuteRecipe(Plot plt)
        {
            int pointCount = 51;
            double[] x = DataGen.Consecutive(pointCount);
            double[] sin = DataGen.Sin(pointCount);
            double[] cos = DataGen.Cos(pointCount);

            plt.PlotScatter(x, sin);
            plt.PlotScatter(x, cos);

            plt.AddPoint(25, 0.8, color: Color.Green);
            var t1 = plt.AddText(" Important Point (1)", 25, 0.8, 16, Color.Green);

            plt.AddPoint(30, 0.3, color: Color.Black, markerSize: 15);
            var t2 = plt.AddText(" Default alignment (2)", 30, 0.3, 16);

            plt.AddPoint(30, 0, color: Color.Black, markerSize: 15);
            var t3 = plt.AddText("Middle center (3)", 30, 0, 16);
            t3.alignment = Alignment.MiddleCenter;

            plt.AddPoint(30, -0.3, color: Color.Black, markerSize: 15);
            var t4 = plt.AddText("Upper left (4)", 30, -0.3, 16);
            t4.alignment = Alignment.UpperLeft;

            plt.AddPoint(5, -.5, color: Color.Blue, markerSize: 15);
            var t5 = plt.AddText(" Rotated Text (5)", 5, -.5, 16);
            t5.rotation = -30;

            var t6 = plt.AddText(" Filled Background (6)", 15, -.6, 16);
            t6.FontColor = Color.Red;
            t6.FontBold = true;
            t6.FillBackground = true;
            t6.BackgroundColor = Color.LightBlue;
        }
    }

    public class CustomFonts : IRecipe
    {
        public string Category => "Plottable: Text";
        public string ID => "text_fonts";
        public string Title => "Custom Fonts";
        public string Description => "You can pass in a Font to further customize font options";

        public void ExecuteRecipe(Plot plt)
        {
            // display some interesting data in the background
            plt.PlotSignal(DataGen.Sin(51), label: "Sin");
            plt.PlotSignal(DataGen.Cos(51), label: "Cos");

            // add text with custom fonts
            plt.AddText("very graph", 25, .8, new Drawing.Font() { Name = "comic sans ms", Size = 24, Color = Color.Blue, Bold = true });
            plt.AddText("so data", 0, 0, new Drawing.Font() { Name = "comic sans ms", Size = 42, Color = Color.Magenta, Bold = true });
            plt.AddText("many documentation", 3, -.6, new Drawing.Font() { Name = "comic sans ms", Size = 18, Color = Color.DarkBlue, Bold = true });
            plt.AddText("wow.", 10, .6, new Drawing.Font() { Name = "comic sans ms", Size = 36, Color = Color.Green, Bold = true });
            plt.AddText("NuGet", 32, 0, new Drawing.Font() { Name = "comic sans ms", Size = 24, Color = Color.Gold, Bold = true });

            // continue the theme by using custom fonts in axes
            plt.Title("Impressive Graph", fontName: "courier new", fontSize: 24, color: Color.Purple, bold: true);
            plt.YLabel("vertical units", fontName: "impact", fontSize: 24, color: Color.Red, bold: true);
            plt.XLabel("horizontal units", fontName: "georgia", fontSize: 24, color: Color.Blue, bold: true);
            plt.Legend(fontName: "comic sans ms", fontSize: 18, bold: true, fontColor: Color.DarkBlue);
            plt.XAxis.ConfigureTickLabelStyle(color: Color.DarkBlue, fontName: "comic sans ms", fontSize: 16);
            plt.YAxis.ConfigureTickLabelStyle(color: Color.DarkGreen, fontName: "comic sans ms", fontSize: 16);
        }
    }
}
