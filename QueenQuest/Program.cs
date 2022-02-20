using System;

namespace QeenQuest
{
	class Program
	{
		static int Nnum;
		static int[] Queens;
		static void Main(string[] args)
		{
			Console.Write("請輸入NXN棋盤N:");
			string N = Console.ReadLine();
			Nnum = int.Parse(N);
			Queens = new int[Nnum];          //設定要記憶多少個已放置皇后位置
			setChess(0);                     //開始放置皇后
			Console.Write("按下任意鍵結束");
			Console.ReadKey(true);
			return;
		}
		static void setChess(int row)         //參考網路寫法
		{
			int QueenNum;                     //準備要放置皇后的位置
			for (QueenNum = 0; QueenNum < Nnum; QueenNum++)
			{
				if (Check(row, QueenNum))     //檢查準備放置位置是否符合規則
				{
					Queens[row] = QueenNum;
					if (row == Nnum - 1)      //檢查已放置的位置是否達到條件
					{
						display();            //輸出顯示
						return;
					}
					setChess(row + 1);
				}
			}
		}
		static bool Check(int row, int QueenNum)            //參考網路寫法
		{
			int checkRow;
			for (checkRow = 0; checkRow < row; checkRow++)  //依序檢查已經放置皇后位置
			{
				int data = Queens[checkRow];                //讀取已放置的皇后位置
				if (QueenNum == data || Math.Abs(checkRow - row) == Math.Abs(QueenNum - data))  //檢查是否與已放置皇后的位置在同一列或斜線上
					return false;                                                               //如在同一列或斜線上則不可以放置皇后
			}
			return true;                                    //如沒有與已放置皇后在同一列或斜線上則可以放置皇后
		}

		static void display()
		{
			int row;                         //顯示幾列 
			int rowcount;                    //計數幾列 
			int clounm;                      //顯示幾行 
			int clounmcount;                 //計數幾行 

			row = Nnum;
			clounm = Nnum;

			for (rowcount = 0; rowcount < row; rowcount++)                 //第幾列開始顯示
			{
				for (clounmcount = 0; clounmcount < clounm; clounmcount++) //第幾行開始顯示
				{
					if (clounmcount == Queens[rowcount])                   //行數與已放置皇后位置相同顯示Q
					{
						Console.Write("Q");
					}
					else
					{
						Console.Write(".");                                //行數與已放置皇后位置不相同顯示.
					}
				}
				Console.Write("\n");                                       //行數顯示完畢換下一列
			}

			Console.Write("\n");                                           //區隔下一個顯示結果
		}
	}
}
