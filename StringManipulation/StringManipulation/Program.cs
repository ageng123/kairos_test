// See https://aka.ms/new-console-template for more information
using System.Globalization;

String Input = "SeLamAT PAGi semua halOo";
String OutputBiasa = " ";
String OutputJudul = " ";
Array InputArray = Input.Split(' ');
int index = 0;
TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
foreach (String InputString in InputArray)
{
    String InputStringLower = InputString.ToLower();
    if(index == 0)
    {
        OutputBiasa += textInfo.ToTitleCase(InputStringLower);
        OutputJudul += textInfo.ToTitleCase(InputStringLower);

    }
    else
    {
        OutputJudul += " " + textInfo.ToTitleCase(InputStringLower);
        OutputBiasa += " " + InputStringLower;
    }
    
    index++;
}
Console.WriteLine("Input : "+Input);
Console.WriteLine("Format Judul: " + OutputJudul);
Console.WriteLine("Format Biasa: " + OutputBiasa);
Console.ReadKey();