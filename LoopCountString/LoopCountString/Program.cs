// See https://aka.ms/new-console-template for more information
String givenText = "hello world";
Console.WriteLine("Given Text is : "+givenText);
int givenTextLength = givenText.Length;
var givenTextDictionary = new Dictionary<String,int>();
Console.WriteLine("Output is :");
for(int i = 0; i < givenTextLength; i++)
{
    char letter = givenText[i];
    var test = givenTextDictionary.ContainsKey(letter.ToString());
    if (!test)
    {
        if (letter.ToString() == " ")
        {

        }
        else
        {
            givenTextDictionary.Add(letter.ToString(), 0);
        }
    }
    if(letter.ToString() == " ")
    {

    }
    else
    {
        givenTextDictionary[letter.ToString()]++;
    }
}
foreach(KeyValuePair<String, int> val in givenTextDictionary)
{
    Console.WriteLine(val.Key + " -- " + val.Value);
}
Console.ReadKey();


