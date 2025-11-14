namespace Recognizer;

public static class GrayscaleTask
{
	/* 
	 * Яркость = (0.299*R + 0.587*G + 0.114*B) / 255
	 * 
	 * Почему формула именно такая — читайте в википедии 
	 * http://ru.wikipedia.org/wiki/Оттенки_серого
	 */

	public static double[,] ToGrayscale(Pixel[,] original)
	{
		var grayscale = new double[original.GetLength(0), original.GetLength(1)];
		for (int x = 0; x < original.GetLength(0); x++)
			for (int y = 0; y < original.GetLength(1); y++)
				grayscale[x,y] = (original[x,y].R * 0.299 + original[x,y].G * 0.587 + original[x,y].B * 0.114) /255;
		return grayscale;
	}
}
