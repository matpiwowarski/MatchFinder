#define PROGRAM 0

#if (PROGRAM == 0)

// C++ program to demonstrate 
// Basic Euclidean Algorithm 
//#include <bits/stdc++.h> 
#include<iostream>
using namespace std;

// Function to return  
// gcd of a and b 
int gcd(int a, int b)
{
	if (a == 0)
		return b;
	return gcd(b % a, a);
}

// Driver Code 
int main()
{
	int a = 10, b = 15;
	cout << "GCD(" << a << ", "
		<< b << ") = " << gcd(a, b)
		<< endl;
	a = 35, b = 10;
	cout << "GCD(" << a << ", "
		<< b << ") = " << gcd(a, b)
		<< endl;
	a = 31, b = 2;
	cout << "GCD(" << a << ", "
		<< b << ") = " << gcd(a, b)
		<< endl;
	return 0;
}

// This code is contributed  
// by Nimit Garg 

#endif // (PROGRAM == 0)


#if (PROGRAM == 1)

// C++ program to calculate pow(x,n) 
#include<iostream> 
using namespace std;
class gfg
{

	/* Function to calculate x raised to the power y */
public:
	int power(int x, unsigned int y)
	{
		if (y == 0)
			return 1;
		// int temp = power(x, y / 2);
		else if (y % 2 == 0)
			return power(x, y / 2) * power(x, y / 2);
		else
			return x * power(x, y / 2) * power(x, y / 2);
	}
};

/* Driver code */
int main()
{
	gfg g;
	int x = 2;
	unsigned int y = 3;

	cout << g.power(x, y);
	return 0;
}

// This code is contributed by SoM15242 


#endif // (PROGRAM == 1)



#if (PROGRAM == 2)

// C++ program to compute factorial of big numbers 
#include<iostream> 
using namespace std;

// Maximum number of digits in output 
#define MAX 500 

int multiply(int x, int res[], int res_size);

// This function finds factorial of large numbers 
// and prints them 
void factorial(int n)
{
	int res[MAX];

	// Initialize result 
	res[0] = 1;
	int res_size = 1;

	// Apply simple factorial formula n! = 1 * 2 * 3 * 4...*n 
	for (int x = 2; x <= n; x++)
		res_size = multiply(x, res, res_size);

	cout << "Factorial of given number is \n";
	for (int i = res_size - 1; i >= 0; i--)
		cout << res[i];
}

// This function multiplies x with the number  
// represented by res[]. 
// res_size is size of res[] or number of digits in the  
// number represented by res[]. This function uses simple  
// school mathematics for multiplication. 
// This function may value of res_size and returns the  
// new value of res_size 
int multiply(int x, int res[], int res_size)
{
	int carry = 0;  // Initialize carry 

	// One by one multiply n with individual digits of res[] 
	for (int i = 0; i < res_size; i++)
	{
		int prod = res[i] * x + carry;

		// Store last digit of 'prod' in res[]   
		res[i] = prod % 10;

		// Put rest in carry 
		carry = prod / 10;
	}

	// Put carry in res and increase result size 
	while (carry)
	{
		res[res_size] = carry % 10;
		carry = carry / 10;
		res_size++;
	}
	return res_size;
}

// Driver program 
int main()
{
	factorial(100);
	return 0;
}


#endif // (PROGRAM == 2)