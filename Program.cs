//Console.CursorVisible = false;

char[,] palya = new char[24, 79];

//méret beállítása
Console.SetWindowSize(height: 24, width: 79);

//fileolvasó példányosítása
using StreamReader sr = new(@"..\..\..\src\lab.txt");

//karakterek letárolása a mátrixba
int s = 0;
while(!sr.EndOfStream)
{
    string teljesSor = sr.ReadLine();
    for(int o = 0; o < teljesSor.Length; o++)
        palya[s, o] = teljesSor[o];
    s++;
}

//karakterek kirajzolása a mátrixból
for (int sor = 0; sor < palya.GetLength(0); sor++)
{
    for (int oszlop = 0; oszlop < palya.GetLength(1); oszlop++)
    {
        if (palya[sor, oszlop] == '#')
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.White;
        }
        else if (palya[sor, oszlop] == ' ')
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        Console.Write(palya[sor, oszlop]);
    }
    Console.Write('\n');
}

//kurzor alaphelyzetbe állítása

int left = 0;
int top = 0;
Console.SetCursorPosition(left, top);

while (palya[top, left] != 'O')
{
    ConsoleKey ck = Console.ReadKey().Key;
    if (ck == ConsoleKey.UpArrow)
    {
        //fel
        top--;
    }
    else if (ck == ConsoleKey.DownArrow)
    {
        //le
        top++;
    }
    else if (ck == ConsoleKey.LeftArrow)
    {
        //balra
        left--;
    }
    else if (ck == ConsoleKey.RightArrow)
    {
        //robbra
        left++;
    }
    Console.SetCursorPosition(left, top);
}

Console.Clear();
Console.ResetColor();
Console.WriteLine("nyertél!");

//Console.ReadKey(true);