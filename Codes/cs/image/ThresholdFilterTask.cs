using System;
using Avalonia.Automation;
using Avalonia.Controls.Converters;

namespace Recognizer;

public static class ThresholdFilterTask
{
	public static double CountFilterValue(double[] pixels, int gap)
	{
		Array.Sort(pixels);
		if (gap == 0) return double.PositiveInfinity;
		return pixels[pixels.Length - gap];
	}
	
	public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
	{
		var width = original.GetLength(0);
		var height = original.GetLength(1);
		var pixels = new double[width*height];
		var filteredOriginal= new double[width, height];
		var i = 0;
		foreach (var x in original)
		{
			pixels[i] = x;
			i++;
		}
		var filterValue = CountFilterValue(pixels, (int)Math.Floor(width*height*whitePixelsFraction));
		for (var x = 0; x < width; x++)
		{
			for(var y = 0; y < height; y++)
			{
				if (original[x, y] >= filterValue) filteredOriginal[x, y] = 1;
				else filteredOriginal[x, y] = 0;
			}
		}
		return filteredOriginal;
	}
}
