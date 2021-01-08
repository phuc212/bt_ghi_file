using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Bài_tập_đọc_ghi_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string path =@"D:\module2\week3\test_file\Bài_tập_đọc_ghi_file\dataproject";
            //Directory.CreateDirectory(path);
            string InputData = "InputData.txt";
            string OutputData = "OutputData.txt";
            int[,] mainMatrix ;
            int row =0;
            int colum = 0;
           
            using (StreamWriter sw = new StreamWriter($@"{path}\{InputData}"))
            {
                sw.WriteLine($"{row = 5} {colum = 5}");
                 int[,] matrix1 = Matrix(row,colum);
                 
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    sw.Write(matrix1[i,j] + " ");
                }
                sw.WriteLine(" ");
            }
            }
            using (StreamReader sd = new StreamReader($@"{path}\{InputData}"))
            {
                string line = sd.ReadLine();
                string[] temp = line.Trim().Split(" ");
                row =int.Parse(temp[0]);
                colum = int.Parse(temp[1]);
                mainMatrix = new int[row,colum];
                int count = 0;
                while((line = sd.ReadLine()) != null)
                {
                    temp = line.Trim().Split(" ");
                    for (int i = 0; i < temp.Length; i++)
                    {
                        mainMatrix[count, i] = int.Parse(temp[i]);
                    }
                    count++;
                }
                
            }
            using (StreamWriter sw = new StreamWriter($@"{path}\{OutputData}"))
            {
                //int[,] matrixNhan3; 
                for (int i = 0; i < mainMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < mainMatrix.GetLength(1); j++)
                    {
                        sw.Write(mainMatrix[i,j]+ " ");
                    }
                    sw.WriteLine(" ");
                }
                sw.WriteLine($"tong so chan: {sumEven(mainMatrix)}\n");
                sw.WriteLine($"tong duong bien: {TongDuongBien(mainMatrix)}\n");
                sw.WriteLine($"mang sau khi nhan 3: ");
               Nhan3Matrix(mainMatrix,sw);
                showLanXuatHien(mainMatrix,sw);
                
            }

           
            
            
        }
         static int[,] Matrix(int r, int c)
        {
            int[,] matrx = new int[r,c];
            Random arr = new Random();
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    matrx[i,j] = arr.Next(4,20);
                }
            }
            return matrx;
        }
        static void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine(" ");
            }
        }
        static int sumEven(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] % 2 == 0)
                    {
                        sum += matrix[i,j]; 
                    }
                }
            }
            return sum;
        }
        static void  Nhan3Matrix(int[,] matrix,StreamWriter sw)
        {
            int num1 =matrix.GetLength(0);
            int num2= matrix.GetLength(1);
            int[,] newMAtrix =new int [num1,num2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                  sw.Write($"{matrix[i,j]*3} " );
                }
                sw.WriteLine(" ");
            }
            
        }
        static int TongDuongBien(int[,] matrix)
        {
            int sum =0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
               
                    sum = sum + matrix[0,i] + matrix[i,matrix.GetLength(0) - 1];
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum = sum + matrix[j,0] + matrix[matrix.GetLength(1) -1,j ];
            }
                return sum;
        }
        static string ToStringMatrix(int[,] matrix)
        {
            string KQ = string.Empty;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    KQ += matrix[i,j]  + " ";
                }
                KQ =  "\n";
            }
            return KQ;
        }
        static int dem(int[,] matrix, int num)
        {
            int count =0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i,j]== num)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        static void showLanXuatHien(int[,] matrix,StreamWriter sw )
        {
            Dictionary<int,int> demLanXuatHien = new Dictionary<int, int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(!demLanXuatHien.ContainsKey(matrix[i,j]))
                    {
                        
                        demLanXuatHien.Add((matrix[i,j]),dem(matrix,matrix[i,j]));
                    }
                }
            }
            foreach (KeyValuePair<int,int> item in demLanXuatHien)
            {
                sw.WriteLine($"so lan xuat hien so {item.Key} : {item.Value} lan");
            }

        }


    }
}
