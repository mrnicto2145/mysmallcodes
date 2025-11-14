using System;

namespace Recognizer;
internal static class SobelFilterTask
{
    public static double MultiplyMatrixElements(double[,] p, double[,] s)
    {
        var result = 0.0;
        for (var x = 0; x < s.GetLength(0); x++)
        {
            for (var y = 0; y < s.GetLength(0); y++)
            {
                result += p[x, y] * s[x, y];
            }
        }
        return result;
    }

    public static double[,] GetTransparentMatrix(double[,] original)
	{
		var width = original.GetLength(0);
		var height = original.GetLength(1);
		var transparentMatrix = new double[height, width];
		for (var x = 0; x < width; x++)
		{
			for (var y = 0; y < height; y++)
			{
				transparentMatrix[y, x] = original[x, y];
			}
		}
		return transparentMatrix;		
	}

    public static double[,] GetMinorMatrix(double[,] original, int x, int y, int k)
    {
        var result= new double[k,k];
        for (int i = x; i < x+k; i++)
        {
            for (int j = y; j < y + k; j++)
            {
                result[i-x, j-y] = original[i, j];
            }
        }
        return result;
    }
    public static double[,] SobelFilter(double[,] g, double[,] sx)
    {
        var width = g.GetLength(0);
        var height = g.GetLength(1);
        var sxSize = sx.GetLength(0);
        var result = new double[width, height];
        for (int x = sxSize/2; x < width - sxSize/2; x++)
            for (int y = sxSize/2; y < height - sxSize/2; y++)
            {
                var ox = GetMinorMatrix(g,x - sxSize/2, y - sxSize/2, sxSize);
                var gx = MultiplyMatrixElements(ox, sx);
                var sy = GetTransparentMatrix(sx);
                var gy = MultiplyMatrixElements(ox, sy);
                result[x,y] = Math.Sqrt(gx * gx + gy * gy);                
            }
        return result;
    }
}