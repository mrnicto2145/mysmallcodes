using System;

namespace Fractals;

internal static class DragonFractalTask
{
    public static double[] GetNextPoint(int selector, double x, double y)
    {
        double nx, ny;
        if (selector == 0)
        {
            nx = (x - y) / 2;
            ny = (x + y) / 2;
        }
        else
        {
            nx = (x + y) / (-2) + 1;
            ny = (x - y) / 2;
        }
        return [nx, ny];
    }
    public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
    {
        /*
        Начните с точки (1, 0)
        Создайте генератор рандомных чисел с сидом seed
        
        На каждой итерации:

        1. Выберите случайно одно из следующих преобразований и примените его к текущей точке:

            Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз):
            x' = (x · cos(45°) - y · sin(45°)) / sqrt(2)
            y' = (x · sin(45°) + y · cos(45°)) / sqrt(2)

            Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу):
            x' = (x · cos(135°) - y · sin(135°)) / sqrt(2) + 1
            y' = (x · sin(135°) + y · cos(135°)) / sqrt(2)
    
        2. Нарисуйте текущую точку методом pixels.SetPixel(x, y)

        */

        var Random = new Random(seed);
        var randSelector = Random.Next(2);
        double[] point = [1.0, 0.0];
        for (var i = 0; i < iterationsCount; i++)
        {
            point = GetNextPoint(randSelector, point[0], point[1]);        
            pixels.SetPixel(point[0], point[1]);
            randSelector = Random.Next(2);          
        }
    }
}