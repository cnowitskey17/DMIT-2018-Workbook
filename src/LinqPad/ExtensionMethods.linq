<Query Kind="Program" />

void Main()
{
	//Write a program to make a string quack
	string result = "Bob".Quack();
	int size = result.Length;
	
	
	result.Dump("Here is the result");
	size.Dump("The string is this length");
}

// Define other methods and classes here

public static class StringExentions
{
	public static string Quack(this string self)
	{
		return self + " (quack)";
	}
}