using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTradingView.Econometrics.Basics
{
    public static class Matrix
    {
        public static double[][] MatrixCreate(int rows, int cols)
        {
            double[][] result = new double[rows][];

            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];

            return result;
        }

        public static double[][] MatrixRandom(int rows, int cols, double minVal, double maxVal, int seed)
        {
            Random ran = new Random(seed);

            double[][] result = MatrixCreate(rows, cols);

            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    result[i][j] = (maxVal - minVal) * ran.NextDouble() + minVal;

            return result;
        }

        public static double[][] MatrixIdentity(int n)
        {
            double[][] result = MatrixCreate(n, n);

            for (int i = 0; i < n; ++i)
                result[i][i] = 1.0;

            return result;
        }

        public static string MatrixAsString(double[][] matrix)
        {
            string s = "";

            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[i].Length; ++j)
                    s += matrix[i][j].ToString("F3").PadLeft(8) + " ";
                s += Environment.NewLine;
            }

            return s;
        }

        public static bool MatrixAreEqual(double[][] matrixA, double[][] matrixB, double epsilon)
        {

            int aRows = matrixA.Length; int aCols = matrixA[0].Length;
            int bRows = matrixB.Length; int bCols = matrixB[0].Length;

            if (aRows != bRows || aCols != bCols)
                throw new Exception("Non-conformable matrices in MatrixAreEqual");

            for (int i = 0; i < aRows; ++i)
                for (int j = 0; j < aCols; ++j)
                    if (Math.Abs(matrixA[i][j] - matrixB[i][j]) > epsilon)
                        return false;
            return true;
        }

        public static double[][] MatrixProduct(double[][] matrixA, double[][] matrixB)
        {
            int aRows = matrixA.Length; int aCols = matrixA[0].Length;
            int bRows = matrixB.Length; int bCols = matrixB[0].Length;
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices in MatrixProduct");

            double[][] result = MatrixCreate(aRows, bCols);

            for (int i = 0; i < aRows; ++i)
                for (int j = 0; j < bCols; ++j)
                    for (int k = 0; k < aCols; ++k)
                        result[i][j] += matrixA[i][k] * matrixB[k][j];


            return result;
        }

        public static double[] MatrixVectorProduct(double[][] matrix, double[] vector)
        {
            int mRows = matrix.Length; int mCols = matrix[0].Length;
            int vRows = vector.Length;

            if (mCols != vRows)
                throw new Exception("Non-conformable matrix and vector in MatrixVectorProduct");

            double[] result = new double[mRows];

            for (int i = 0; i < mRows; ++i)
                for (int j = 0; j < mCols; ++j)
                    result[i] += matrix[i][j] * vector[j];

            return result;
        }

        public static double[][] MatrixDecompose(double[][] matrix, out int[] perm, out int toggle)
        {

            int rows = matrix.Length;
            int cols = matrix[0].Length;

            if (rows != cols)
                throw new Exception("Attempt to MatrixDecompose a non-square mattrix");

            int n = rows;

            double[][] result = MatrixDuplicate(matrix);

            perm = new int[n];

            for (int i = 0; i < n; ++i) { perm[i] = i; }

            toggle = 1;

            for (int j = 0; j < n - 1; ++j)
            {
                double colMax = Math.Abs(result[j][j]);
                int pRow = j;
                for (int i = j + 1; i < n; ++i)
                {
                    if (result[i][j] > colMax)
                    {
                        colMax = result[i][j];
                        pRow = i;
                    }
                }

                if (pRow != j)
                {
                    double[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[pRow];
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle;
                }

                for (int i = j + 1; i < n; ++i)
                {
                    result[i][j] /= result[j][j];
                    for (int k = j + 1; k < n; ++k)
                    {
                        result[i][k] -= result[i][j] * result[j][k];
                    }
                }
            }

            return result;
        }

        public static double[][] MatrixInverse(double[][] matrix)
        {
            int n = matrix.Length;
            double[][] result = MatrixDuplicate(matrix);

            int[] perm;
            int toggle;
            double[][] lum = MatrixDecompose(matrix, out perm, out toggle);

            if (lum == null)
                throw new Exception("Unable to compute inverse");

            double[] b = new double[n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;
                }

                double[] x = HelperSolve(lum, b);

                for (int j = 0; j < n; ++j)
                    result[j][i] = x[j];
            }
            return result;
        }

        public static double MatrixDeterminant(double[][] matrix)
        {
            int[] perm;
            int toggle;
            double[][] lum = MatrixDecompose(matrix, out perm, out toggle);

            if (lum == null)
                throw new Exception("Unable to compute MatrixDeterminant");

            double result = toggle;

            for (int i = 0; i < lum.Length; ++i)
                result *= lum[i][i];

            return result;
        }

        public static double[] HelperSolve(double[][] luMatrix, double[] b)
        {
            int n = luMatrix.Length;
            double[] x = new double[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1][n - 1];

            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];

                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i][j] * x[j];

                x[i] = sum / luMatrix[i][i];
            }

            return x;
        }

        public static double[] SystemSolve(double[][] A, double[] b)
        {
            int n = A.Length;

            int[] perm;
            int toggle;

            double[][] luMatrix = MatrixDecompose(A, out perm, out toggle);

            if (luMatrix == null)
                return null;

            double[] bp = new double[b.Length];

            for (int i = 0; i < n; ++i)
                bp[i] = b[perm[i]];

            double[] x = HelperSolve(luMatrix, bp);

            return x;
        }

        public static double[][] MatrixDuplicate(double[][] matrix)
        {
            double[][] result = MatrixCreate(matrix.Length, matrix[0].Length);

            for (int i = 0; i < matrix.Length; ++i)
                for (int j = 0; j < matrix[i].Length; ++j)
                    result[i][j] = matrix[i][j];

            return result;
        }

        public static double[][] ExtractLower(double[][] matrix)
        {
            int rows = matrix.Length; int cols = matrix[0].Length;

            double[][] result = MatrixCreate(rows, cols);

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (i == j)
                        result[i][j] = 1.0;
                    else if (i > j)
                        result[i][j] = matrix[i][j];
                }
            }

            return result;
        }

        public static double[][] ExtractUpper(double[][] matrix)
        {
            int rows = matrix.Length; int cols = matrix[0].Length;

            double[][] result = MatrixCreate(rows, cols);

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (i <= j)
                        result[i][j] = matrix[i][j];
                }
            }

            return result;
        }

        public static double[][] PermArrayToMatrix(int[] perm)
        {
            int n = perm.Length;

            double[][] result = MatrixCreate(n, n);

            for (int i = 0; i < n; ++i)
                result[i][perm[i]] = 1.0;

            return result;
        }

        public static double[][] UnPermute(double[][] luProduct, int[] perm)
        {
            double[][] result = MatrixDuplicate(luProduct);

            int[] unperm = new int[perm.Length];

            for (int i = 0; i < perm.Length; ++i)
                unperm[perm[i]] = i;

            for (int r = 0; r < luProduct.Length; ++r)
                result[r] = luProduct[unperm[r]];

            return result;
        }

        public static string VectorAsString(double[] vector)
        {
            string s = "";

            for (int i = 0; i < vector.Length; ++i)
                s += vector[i].ToString("F3").PadLeft(8) + Environment.NewLine;

            s += Environment.NewLine;

            return s;
        }

        public static string VectorAsString(int[] vector)
        {
            string s = "";

            for (int i = 0; i < vector.Length; ++i)
                s += vector[i].ToString().PadLeft(2) + " ";

            s += Environment.NewLine;

            return s;
        }

        public static double[] GetVector(double[][] xn, double[] y)
        {
            double[] mx = new double[xn.Length];

            for (int i = 0; i < xn.Length; i++)
            {
                for (int j = 0; j < xn.Length; j++)
                    mx[i] = StdFuncs.Multi(xn[i], y);
            }

            return mx;
        }


        public static double[][] MatrixMatrix(double[][] x)
        {
            double[][] mx = new double[x.Length][];

            for (int i = 0; i < x.Length; i++)
            {
                mx[i] = new double[x.Length];

                for (int j = 0; j < x.Length; j++)
                    mx[i][j] = StdFuncs.Multi(x[i], x[j]);
            }

            return mx;
        }
    } 

}
