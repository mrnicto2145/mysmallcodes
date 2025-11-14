using System;

namespace Recognizer;

internal static class MedianFilterTask
{
	public static double GetMedianValue(params double[] arr)
	{
		if (arr.Length == 0) return double.NaN;
		Array.Sort(arr);
		if (arr.Length % 2 == 0)
		{
			return (arr[arr.Length / 2 - 1] + arr[arr.Length / 2]) / 2;
		}
		else
		{
			return arr[arr.Length / 2];
		}
	}

	public static double GetAroundMedian(double[,] original, int x, int y)
	{
		return GetMedianValue(
			original[x - 1, y - 1], 
			original[x, y - 1], 
			original[x + 1, y - 1],
			original[x - 1, y], 
			original[x, y], 
			original[x + 1, y],
			original[x - 1, y + 1], 
			original[x, y + 1], 
			original[x + 1, y + 1]);
	}

	public static double GetUpperMedian(double[,] original, int x)
	{
		return GetMedianValue(
			original[x - 1, 0], 
			original[x, 0], 
			original[x + 1, 0],
			original[x - 1, 1],
			original[x, 1],
			original[x + 1, 1]);
	}

	public static double GetDownerMedian(double[,] original, int x, int height)
	{
		return GetMedianValue(
			original[x - 1, height - 2], 
			original[x, height - 2], 
			original[x + 1, height - 2],
			original[x - 1, height - 1], 
			original[x, height - 1], 
			original[x + 1, height - 1]);
	}

	public static double GetLeftUpMedian(double[,] original)
	{
		return GetMedianValue(
			original[0, 0], 
			original[0, 1], 
			original[1, 0], 
			original[1, 1]);
	}

	public static double GetLeftDownMedian(double[,] original, int height)
	{
		return GetMedianValue(
			original[0, height - 1], 
			original[0,	height - 2], 
			original[1, height - 1], 
			original[1, height - 2]);
	}

	public static double GetRightUpMedian(double[,] original, int width)
	{
		return GetMedianValue(
			original[width - 1, 0], 
			original[width - 1, 1], 
			original[width - 2, 0], 
			original[width - 2, 1]);
	}

	public static double GetRightDownMedian(double[,] original, int width, int height)
	{
		return GetMedianValue(
			original[width - 2, height - 1], 
			original[width - 2,	height - 2], 
			original[width - 1, height - 1], 
			original[width - 1, height - 2]);
	}

	public static double[,] GetTransparentPicture(double[,] original)
	{
		var width = original.GetLength(0);
		var height = original.GetLength(1);
		var transparentPicture = new double[height, width];
		for (var x = 0; x < width; x++)
		{
			for (var y = 0; y < height; y++)
			{
				transparentPicture[y, x] = original[x, y];
			}
		}
		return transparentPicture;		
	}

	public static double[,] GetOneSizedMedian(double[,] original)
	{
		var height = original.GetLength(1);
		var filteredOriginal = new double[1, height];
		filteredOriginal[0, 0] = GetMedianValue(original[0, 0], original[0, 1]);
		filteredOriginal[0, height - 1] = GetMedianValue(original[0, height - 2], original[0, height - 1]);
		for (var y = 1; y < height - 1; y++)
		{
			filteredOriginal[0, y] = GetMedianValue(original[0, y - 1], original[0, y], original[0, y + 1]);
		}
		return filteredOriginal;
	}

	public static double[,] GetMedianBorder(double[,] original)
	{
		var width = original.GetLength(0);
		var height = original.GetLength(1);
		var filteredOriginal = new double[width, height];
		filteredOriginal[0, 0] = GetLeftUpMedian(original);
		filteredOriginal[width - 1, 0] = GetRightUpMedian(original, width);
		filteredOriginal[0, height - 1] = GetLeftDownMedian(original, height);
		filteredOriginal[width - 1, height - 1] = GetRightDownMedian(original, width, height);
		for (var x = 1; x < width - 1; x++)
		{
			filteredOriginal[x, 0] = GetUpperMedian(original, x);
			filteredOriginal[x, height - 1] = GetDownerMedian(original, x, height);					  
		}
		return filteredOriginal;
	}

	public static double[,] GetFullMedian(double[,] original, int width, int height)
	{
		var border1 = GetMedianBorder(original);
		var filteredOriginal = GetMedianBorder(GetTransparentPicture(original));
		filteredOriginal = GetTransparentPicture(filteredOriginal);
		for (var x = 1; x < width - 1; x++)
		{
			filteredOriginal[x, 0] = border1[x, 0];
			filteredOriginal[x, height - 1] = border1[x, height - 1];
			for (var y = 1; y < height - 1; y++)
			{	
				filteredOriginal[x, y] = GetAroundMedian(original, x, y);
			}
		}
		return filteredOriginal;
	}

	public static double[,] MedianFilter(double[,] original)
	{
		var width = original.GetLength(0);
		var height = original.GetLength(1);
		if (width <= 1 && height <= 1) return original;
		else if (width == 1)
		{
			return GetOneSizedMedian(original);
		}
		else if (height == 1)
		{
			var transparentOriginal = GetTransparentPicture(original);
			var filteredOriginal = GetOneSizedMedian(transparentOriginal);
			return GetTransparentPicture(filteredOriginal);
		}
		else{
			return GetFullMedian(original, width, height);
		}
	}
}
