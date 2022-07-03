// See https://aka.ms/new-console-template for more information
using CalBodyWeight;

Console.WriteLine("Hello, World!");
var x=new CalWeight{
Height=176,
Sex="m"
};
double good=x.GetBodyWeight();
System.Console.WriteLine(good);