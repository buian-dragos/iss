Console.WriteLine("Input string 1: ");
string string1 = Console.ReadLine().ToLower();

Console.WriteLine("Input string2: ");
string string2 = Console.ReadLine().ToLower();

Dictionary<char, int> dict_s1 = new Dictionary<char, int>();
Dictionary<char, int> dict_s2 = new Dictionary<char, int>();

for (int i = 0; i < string1.Length; i++)
{
    if (char.IsLetter(string1[i]))
        if (dict_s1.ContainsKey(string1[i]))
            dict_s1[string1[i]]++;
        else
            dict_s1.Add(string1[i], 1);
}

for (int i = 0;i < string2.Length; i++)
{
    if (char.IsLetter(string2[i]))
        if (dict_s2.ContainsKey(string2[i]))
            dict_s2[string2[i]]++;
        else
            dict_s2.Add(string2[i], 1);
}

foreach (char c in dict_s1.Keys)
{
    if (!dict_s2.ContainsKey(c) || dict_s1[c] != dict_s2[c])
    {
        Console.WriteLine("Strings are not anagrams!");
        return;
    }
}
Console.WriteLine("Strings are anagrams");