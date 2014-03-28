/*
 *    File Name: title_vector.cpp
 *       Author: Jiang
 *        Email: ligelaige@gmail.com
 * Created Time: 2014-03-28 18:15:11.299477 
 */

//col=column 竖行  row=row 横行

#include <iostream>
#include <ctime>
#include <cstdlib>
#include <iomanip>

using namespace std;

void Print(int** num, int row, int col);
int** CreateVector(int row, int col, int value);
void DeleteVector(int** num, int row);

int main(void)
{
	int row = 5;
	int col = 10;
	
	int** num = CreateVector(row, col, 0);

	srand(int(time(0)));
	
	int number = rand()%(col*row/6) + col*row/3;
	int* value = new int [number];
	for (int i = 0; i < number; ++i)
	{
		value[i] = i+1;
	}
	
	int n = 0;
	
	while(n < number)//1×2 色块
	{
		int i = rand() % row;
		int j = rand() % (col-1);
		
		if (num[i][j] == 0 && num[i][j+1] == 0)
		{
			num[i][j] = value[n];
			num[i][j+1] = value[n];
			n++;
		}
		
	}
	
	
	Print(num, row, col);

	DeleteVector(num, row);
	
	return 0;
}

void DeleteVector(int** num, int row)
{
	for (int i = 0; i < row; ++i)
	{
		delete[] num[i];
	}
	
	delete[] num;
}

int** CreateVector(int row, int col, int value = 0)
{
	int** num = new int*[row];
	for (int i = 0; i < row; ++i)
	{
		num[i] = new int[col];
		for (int j = 0; j < col; ++j)
		{
			num[i][j] = value;
		}
	}
	
	
	
	return num;
}

void Print(int** num, int row, int col)
{
	for (int i = 0; i < row; ++i)
	{
		for (int j = 0; j < col; ++j)
		{
			cout << setw(3) << num[i][j] << " ";
		}
		cout << endl;
	}
}
