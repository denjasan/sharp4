Console.WriteLine("Введите диапозон");
var d1 = Convert.ToInt32(Console.ReadLine());
var d2 = Convert.ToInt32(Console.ReadLine());
MyMatrix m1 = new(5, 5, d1, d2);
MyMatrix m2 = new(5, 5, d1, d2);
Console.WriteLine("m1:");
m1.Print();
Console.WriteLine("m2:");
m2.Print();

Console.WriteLine("m1 + m2");
var res = m1 + m2;
res.Print();

Console.WriteLine("m1 - m2:");
res = m1 - m2;
res.Print();

var m3 = new MyMatrix(5, 3, d1, d2);
Console.WriteLine("m3:");
m3.Print();
res = m1 * m3;
Console.WriteLine("m1 * m2:");
res.Print();

Console.WriteLine("m1 * 2:");
res = m1 * 2;
res.Print();

Console.WriteLine("m1 / 2:");
res = m1 / 2;
res.Print();


internal class MyMatrix
{
    private int _m;
    private int _n;
    private double[,] _matrix;
    private Random _random = new();

    public MyMatrix(int m, int n, int d1, int d2)
    {
        _m = m;
        _n = n;
        _matrix = new double[m, n];
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                _matrix[i, j] = _random.Next(d1, d2);
            }
        }
    }

    public double this[int i, int j]
    {
        get => _matrix[i, j];

        set => _matrix[i, j] = value;
    }

    public static MyMatrix operator +(MyMatrix m1, MyMatrix m2)
    {
        if (m1._m != m2._m || m1._n != m2._n) throw new Exception("Матрицы разной размерности");

        MyMatrix result = new(m1._m, m1._n, 0, 0);
        for (var i = 0; i < m1._m; i++)
        {
            for (var j = 0; j < m1._n; j++)
            {
                result[i, j] = m1[i, j] + m2[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator -(MyMatrix m1, MyMatrix m2)
    {
        if (m1._m != m2._m || m1._n != m2._n) throw new Exception("Матрицы разной размерности");

        MyMatrix result = new(m1._m, m1._n, 0, 0);
        for (var i = 0; i < m1._m; i++)
        {
            for (var j = 0; j < m1._n; j++)
            {
                result[i, j] = m1[i, j] - m2[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator *(MyMatrix m1, MyMatrix m2)
    {
        if (m1._n != m2._m) throw new Exception("Матрицы нельзя перемножить");
        
        MyMatrix result = new(m1._m, m2._n, 0, 0);
        for (var i = 0; i < m1._n; i++)
        {
            for (var j = 0; j < m2._n; j++)
            {
                for (var k = 0; k < m2._m; k++)
                {
                    result[i, j] += m1[i, k] * m2[k, j];
                }
            }
        }

        return result;
    }
    
    public static MyMatrix operator *(MyMatrix m1, int num)
    {

        MyMatrix result = new(m1._m, m1._n, 0, 0);
        for (var i = 0; i < m1._m; i++)
        {
            for (var j = 0; j < m1._n; j++)
            {
                result[i, j] = m1[i, j] * num;
            }
        }

        return result;
    }
    
    public static MyMatrix operator /(MyMatrix m1, int num)
    {

        MyMatrix result = new(m1._m, m1._n, 0, 0);
        for (var i = 0; i < m1._m; i++)
        {
            for (var j = 0; j < m1._n; j++)
            {
                result[i, j] = m1[i, j] / num;
            }
        }

        return result;
    }

    public void Print()
    {
        for (var i = 0; i < _m; i++)
        {
            for (var j = 0; j < _n; j++)
            {
                Console.Write($"{_matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}

