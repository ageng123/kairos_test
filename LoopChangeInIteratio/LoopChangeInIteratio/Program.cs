// See https://aka.ms/new-console-template for more information
int limit = 100;
Console.WriteLine("Limit Given" + limit);
for(int i = 0; i <= limit; i++)
{
    if(i > 0)
    {
        
        if (i % 5 == 0)
        {
            Console.WriteLine(" IDIC ");
        }
        else if(i % 6 == 0)
        {
            Console.Write(" LPS ");
        }
        else
        {
            Console.Write(" "+i+" ");
        }
    }
}
