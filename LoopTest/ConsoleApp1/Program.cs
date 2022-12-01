// See https://aka.ms/new-console-template for more information
int givenNumber = 1225441;
Console.WriteLine("Given Number: "+givenNumber);
string givenNumberArr = givenNumber.ToString();
int givenNumberLength = givenNumberArr.Length;

for(int i = 0; i < givenNumberLength; i++)
{
    string output = null;
    for(int j = 0; j < givenNumberLength - 1 - i; j++)
    {
        output = output + '0';
    }
    Console.WriteLine(givenNumberArr[i] + output);
}
Console.ReadKey();
