
// See https://aka.ms/new-console-template for more information

String line;
try
{
    // kör filvägen 
    StreamReader sr = new StreamReader("C:\\Users\\wiha\\source\\repos\\MariaSliufko\\LynkApi\\LynkApi\\Workshopexamples.txt");
    //Läser texten
    line = sr.ReadLine();
    //Fortsätt till slutet
    while (line != null)
    {
        Console.WriteLine(line);
        //Läs nästa
        line = sr.ReadLine();
    }
    //Stäng filen
    sr.Close();
    Console.ReadLine();
}
catch(Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    Console.WriteLine("Executing finally block.");
}