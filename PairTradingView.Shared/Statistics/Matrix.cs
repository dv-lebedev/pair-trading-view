/*
    Copyright(c) 2023 Denis Lebedev

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

        http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
*/

using System;

namespace PairTradingView.Shared.Statistics
{
    public class Matrix
    {
        private double[][] matrix;

        public int Rows
        {
            get
            {
                return matrix.Length;
            }
        }

        public int Columns
        {
            get
            {
                return matrix[0].Length;
            }
        }

        public double this[int row, int column]
        {
            get
            {
                return matrix[row][column];
            }
        }

        public double[] GetRow(int row)
        {
            return matrix[row];
        }

        public double[][] GetArray
        {
            get
            {
                return matrix;
            }
        }

        public Matrix(int rows, int columns)
        {
            this.matrix = Create(rows, columns);
        }

        public Matrix(double[][] matrix, bool copy = false)
        {
            if (copy)
            {
                Check.NotNull(matrix);

                this.matrix = Create(matrix.Length, matrix[0].Length);

                Array.Copy(matrix, this.matrix, matrix.Length);
            }
            else
            {
                this.matrix = matrix;
            }
        }

        public Matrix(Matrix matrix, bool copy = false)
            : this(matrix.GetArray, copy)
        {

        }

        private double[][] Create(int rows, int columns)
        {
            var matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new double[columns];
            }

            return matrix;
        }

        public bool AreEqual(Matrix matrix, double epsilon)
        {
            Check.NotNull(matrix);

            if (this.Rows != matrix.Rows || this.Columns != matrix.Columns)
                return false;

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    if (Math.Abs(this[row, col] - matrix[row, col]) > epsilon)
                        return false;
                }
            }

            return true;
        }

        public Matrix ByMatrix()
        {
            double[][] mx = new double[Rows][];

            for (int row = 0; row < Rows; row++)
            {
                mx[row] = new double[Rows];

                for (int col = 0; col < Rows; col++)
                {
                    mx[row][col] = MathUtils.MultiplyArrays(GetRow(row), GetRow(col));
                }
            }

            return new Matrix(mx);
        }

        public double[] GetVector(double[] y)
        {
            double[] mx = new double[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    mx[i] = MathUtils.MultiplyArrays(matrix[i], y);
                }
            }

            return mx;
        }

        public double[] VectorProduct(double[] vector)
        {
            int vectorRows = vector.Length;

            if (Columns != vectorRows)
            {
                throw new ArgumentException("Columns != vectorRows", "vectror");
            }

            double[] result = new double[Rows];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result[i] += matrix[i][j] * vector[j];
                }
            }

            return result;
        }

        public Matrix Duplicate()
        {
            double[][] result = Create(matrix.Length, matrix[0].Length);

            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[i].Length; ++j)
                {
                    result[i][j] = matrix[i][j];
                }
            }

            return new Matrix(result);
        }

        public double[] HelperSolve(double[] b)
        {
            int n = matrix.Length;

            double[] result = new double[n];

            b.CopyTo(result, 0);

            for (int i = 1; i < n; i++)
            {
                double sum = result[i];

                for (int j = 0; j < i; j++)
                {
                    sum -= matrix[i][j] * result[j];
                }

                result[i] = sum;
            }

            result[n - 1] /= matrix[n - 1][n - 1];

            for (int i = n - 2; i >= 0; i--)
            {
                double sum = result[i];

                for (int j = i + 1; j < n; j++)
                {
                    sum -= matrix[i][j] * result[j];
                }

                result[i] = sum / matrix[i][i];
            }

            return result;
        }

        public Matrix Decompose(out int[] perm, out int toggle)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            if (rows != cols)
                throw new Exception("Attempt to MatrixDecompose a non-square mattrix");

            int n = rows;

            double[][] result = Duplicate().GetArray;

            perm = new int[n];

            for (int i = 0; i < n; i++)
            {
                perm[i] = i;
            }

            toggle = 1;

            for (int j = 0; j < n - 1; j++)
            {
                double colMax = Math.Abs(result[j][j]);
                int pRow = j;

                for (int i = j + 1; i < n; i++)
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

                for (int i = j + 1; i < n; i++)
                {
                    result[i][j] /= result[j][j];

                    for (int k = j + 1; k < n; k++)
                    {
                        result[i][k] -= result[i][j] * result[j][k];
                    }
                }
            }

            return new Matrix(result);
        }

        public Matrix Inverse()
        {
            int n = matrix.Length;
            double[][] result = Duplicate().GetArray;

            int[] perm;
            int toggle;

            double[][] decomposedM = Decompose(out perm, out toggle).GetArray;

            if (decomposedM == null)
            {
                throw new Exception("Unable to compute inverse.");
            }

            double[] b = new double[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == perm[j])
                    {
                        b[j] = 1.0;
                    }
                    else
                    {
                        b[j] = 0.0;
                    }
                }

                double[] x = new Matrix(decomposedM).HelperSolve(b);

                for (int j = 0; j < n; j++)
                {
                    result[j][i] = x[j];
                }
            }

            return new Matrix(result);
        }
    }
}