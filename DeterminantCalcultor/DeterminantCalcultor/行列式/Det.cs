using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterminantCalcultor.行列式
{
    class Det
    {
        static void Swap(int x, int y, int[] a)           //用于交换数组的两个数
        {
            int temp = a[x];
            a[x] = a[y];
            a[y] = temp;
        }

        static bool IsOddArrange(int[] a, int n)           //判断是否为奇排列
        {
            int i, j, sum = 0;
            for (i = 0; i < n - 1; i++)
                for (j = i + 1; j < n; j++)
                {
                    if (a[i] > a[j]) sum++;
                }
            if (sum % 2 == 0) return false;
            return true;
        }

        public static void Resove(int Settle, int length, int[] arr, int[,] determinant, ref int Sum)//递归函数   Settle当前固定点下标  length数组长度，                                              //arr为一维数组{0,1,..,M-1}记录变化,b为M阶矩阵                               
        {

            if (Settle == length)                                    //当尝试对不存在的数组元素进行递归时，标明所有数已经排列完成，输出。
            {
                int Multiple = 1;
                for (int i = 0; i < length; i++)
                {
                    Multiple *= determinant[i, arr[i]];
                }
                if (IsOddArrange(arr, length)) Sum -= Multiple;
                else Sum += Multiple;
            }
            for (int i = Settle; i < length; i++)//循环实现交换和之后的全排列  
            {//i是从n开始 i=n;swap(n,i)相当于固定当前位置，在进行下一位的排列。
                Swap(Settle, i, arr);
                Resove(Settle + 1, length, arr, determinant, ref Sum);
                Swap(Settle, i, arr);
            }

        }
        public static void Transposition(int[,] D, int[,] T, int n)  //原矩阵、转置矩阵及阶数
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    T[j, i] = D[i, j];
                }
            }
        }
        public static void Transposition(int[][] D, int[][] T, int n,int m)  //原矩阵、转置矩阵及阶数 重载函数
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    T[j][ i] = D[i][j];
                }
            }
        }
        static void Subdeterminant(int i, int j, int[,] D, int[,] Sub, int length)    //取去除第i行第j列的(n-1)阶子式
        {
            int n = 0, m = 0;
            for (int k = 0; k < length; k++)
            {
                if (k == i) continue;
                for (int p = 0; p < length; p++)
                {
                    if (p == j) continue;
                    Sub[n, m] = D[k, p];
                    m = (m + 1) % (length - 1);

                }
                n++;
            }
        }
        //求代数余子式公式
        public static void Algebraic_Complement(int[,] D, int[,] A, int n)//D 代表原矩阵   A代表代数余子式的矩阵
        {
            int[,] Sub = new int[n - 1, n - 1];

            int[] arr = new int[n - 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n - 1; k++) arr[k] = k;
                    Subdeterminant(i, j, D, Sub, n);
                    int Sum = 0;
                    Det.Resove(0, n - 1, arr, Sub, ref Sum);
                    if ((i + j) % 2 == 0)
                        A[j, i] = Sum;
                    else
                        A[j, i] = -Sum;

                }
            }
        }
        //矩阵相乘函数
        public static void Matrix_Mul(int[,] A, int[,] B, int[,] C, int n, int p, int m)
        {
            int i, j, k;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    C[i, j] = 0;
                }
            }
            for (i = 0; i < n; i++)
            {
                for (k = 0; k < p; k++)
                {
                    for (j = 0; j < m; j++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
        }
        public static void FindTheMinimum(int[,] A, int n, int m, int k)   //寻找第k列绝对值最小的数
        {
            int i, j, Mul, cnt = 0;
            int MIN = Math.Abs(A[k, k]), MIN_LOCATE = 0;           //假设第k列的第一个数最小的绝对值
            for (i = k; i < n; i++)
            {
                if (MIN < Math.Abs(A[i, k]) && A[i, k] != 0)      //不与0比较
                {
                    MIN = Math.Abs(A[i, k]);
                    MIN_LOCATE = i;
                }
            }
            if (MIN == 0)                            //这一列全部为0
            {
                return;
            }
            else
            {
                for (i = k; i < n; i++)
                {
                    if (i == MIN_LOCATE) continue;
                    Mul = A[i, k] / A[MIN_LOCATE, k];
                    for (j = k; j < m; j++)
                    {

                        A[i, j] -= A[i, j] * Mul;
                    }
                }
                if (cnt > 1)
                {
                    FindTheMinimum(A, n, m, k);
                }
            }
            // return 0;
        }
        public static void Normal_Matrix(int[,] D, int[,] A, int n, int m)    //化n*m阶矩阵标准型
        {

        }

        #region

        /// <summary>
        /// 计算矩阵的秩
        /// </summary>
        /// <param name="matrix">矩阵</param>
        /// <returns></returns>
        public  static int Rank(int[][] matrix)
        {
            //matrix为空则直接默认已经是最简形式
            if (matrix == null || matrix.Length == 0) return 0;
            //复制一个matrix到copy，之后因计算需要改动矩阵时并不改动matrix本身
            int[][] copy = new int[matrix.Length][];
            for (int i = 0; i < copy.Length; i++)
            {
                copy[i] = new int[matrix[i].Length];
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    copy[i][j] = matrix[i][j];
                }
            }
            //先以最左侧非零项的位置进行行排序
            Operation1(copy);
            //循环化简矩阵
            while (!isFinished(copy))
            {
                Operation2(copy);
                Operation1(copy);
            }
            //过于趋近0的项，视作0，减小误差
            Operation3(copy);
            //行最简矩阵的秩即为所求
            return Operation4(matrix);
        }
        /// <summary>
        /// 判断矩阵是否变换到最简形式（非零行数达到最少）
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>true:</returns>
        private static bool isFinished(int[][] matrix)
        {
            //统计每行第一个非零元素的出现位置
            int[] counter = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        counter[i]++;
                    }
                    else break;
                }
            }
            //后面行的非零元素出现位置必须在前面行的后面，全零行除外
            for (int i = 1; i < counter.Length; i++)
            {
                if (counter[i] <= counter[i - 1] && counter[i] != matrix[0].Length)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 排序（按左侧最前非零位位置自上而下升序排列）
        /// </summary>
        /// <param name="matrix">矩阵</param>
        private static void Operation1(int[][] matrix)
        {
            //统计每行第一个非零元素的出现位置
            int[] counter = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        counter[i]++;
                    }
                    else break;
                }
            }
            //按每行非零元素的出现位置升序排列
            for (int i = 0; i < counter.Length; i++)
            {
                for (int j = i; j < counter.Length; j++)
                {
                    if (counter[i] > counter[j])
                    {
                        int[] dTemp = matrix[i];
                        matrix[i] = matrix[j];
                        matrix[j] = dTemp;
                    }
                }
            }
        }
        /// <summary>
        /// 行初等变换（左侧最前非零位位置最靠前的行，只保留一个）
        /// </summary>
        /// <param name="matrix">矩阵</param>
        private static void Operation2(int[][] matrix)
        {
            //统计每行第一个非零元素的出现位置
            int[] counter = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        counter[i]++;
                    }
                    else break;
                }
            }
            for (int i = 1; i < counter.Length; i++)
            {
                if (counter[i] == counter[i - 1] && counter[i] != matrix[0].Length)
                {
                    int a = matrix[i - 1][counter[i - 1]];
                    int b = matrix[i][counter[i]]; //counter[i]==counter[i-1]
                    matrix[i][counter[i]] = 0;
                    for (int j = counter[i] + 1; j < matrix[i].Length; j++)
                    {
                        int c = matrix[i - 1][j];
                        matrix[i][j] -= (c * b / a);
                    }
                    break;
                }
            }
        }
        /// <summary>
        /// 将和0非常接近的数字视为0
        /// </summary>
        /// <param name="matrix"></param>
        private static void Operation3(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (Math.Abs(matrix[i][j]) <= 0.00001)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }
        /// <summary>
        /// 计算行最简矩阵的秩
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static int Operation4(int[][] matrix)
        {
            int rank = -1;
            bool isAllZero = true;
            for (int i = 0; i < matrix.Length; i++)
            {
                isAllZero = true;
                //查看当前行有没有0
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] != 0)
                    {
                        isAllZero = false;
                        break;
                    }
                }
                //若第i行全为0，则矩阵的秩为i
                if (isAllZero)
                {
                    rank = i;
                    break;
                }
            }
            //满秩矩阵的情况
            if (rank == -1)
            {
                rank = matrix.Length;
            }
            return rank;
        }
        #endregion
    }
}
