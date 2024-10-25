using System;

class Program
{
    static void Main()
    {
        string input = "29535123p48723487597645723645";
        long totalSum = 0; // Håller summan av alla matchande delsträngar
        int length = input.Length;

        // Itererar över tecken i strängen
        for (int i = 0; i < length - 1; i++)
        {
            if (char.IsDigit(input[i]))
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (input[i] == input[j] && char.IsDigit(input[j]))
                    {
                        string substring = input.Substring(i, j - i + 1);

                        // Validera att delsträngen innehåller olika tal och endast det första och sista tecknet är samma
                        if (IsValidSubstring(substring))
                        {
                            DisplayHighlightedSubstring(input, i, j);
                            totalSum += long.Parse(substring); // Lägg till numeriskt värde av delsträng
                        }
                    }

                    // Avsluta loopen om vi stöter på ett icke-siffra-tecken
                    if (!char.IsDigit(input[j]))
                        break;
                }
            }
        }

        Console.WriteLine(); // Separera utdata
        Console.WriteLine($"Summa = {totalSum}");
    }

    // Validerar om en delsträng är giltig för att adderas till summan
    static bool IsValidSubstring(string substring)
    {
        for (int i = 1; i < substring.Length - 1; i++)
        {
            if (substring[i] == substring[0] || !char.IsDigit(substring[i]))
                return false;
        }
        return true;
    }

    // Skriver ut strängen med en markerad delsträng
    static void DisplayHighlightedSubstring(string input, int start, int end)
    {
        Console.Write(input.Substring(0, start));
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(input.Substring(start, end - start + 1));
        Console.ResetColor();
        Console.WriteLine(input.Substring(end + 1));
    }
}
