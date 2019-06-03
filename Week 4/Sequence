using System;

class Sequence
{
    public static void Main()
    {
        string DNA;
        Console.WriteLine(string.Join(", ", Kmers(4, "AGA", "TCG", "AGT", "G", "GT")));
        Console.WriteLine();

        DNA = "CATGCGCCAAGCATTGC";
        Console.WriteLine(DNA);
        ReverseComplement(ref DNA);
        Console.WriteLine(DNA);
        Console.WriteLine();

        DNA = "CATGCGCCAAGCGCATG";
        Console.WriteLine(Dyad(DNA));
        Console.WriteLine();
        Console.ReadLine();
    }

    public static string[] Kmers(int k, params string[] DNA)
    {
        string DNAString = string.Join("", DNA);
        int index = (DNAString.Length - k + 1);
        string kmer;
        string[] kmers = new string[index];
        for (int i = 0; i < (index); i++)
        {
            kmer = DNAString.Substring(i, k);
            kmers[i] = kmer;
        }
        return kmers;
    }

    public static void ReverseComplement(ref string DNAInput)
    {
        char[] DNAArray = DNAInput.ToCharArray();
        char bit;
        for (int i = 0; i  < DNAArray.Length; i++)
        {
            bit = DNAArray[i];
            switch (bit)
            {
                case 'A':
                    {
                        bit = 'T';
                        break;
                    }
                case 'T':
                    {
                        bit = 'A';
                        break;
                    }
                case 'G':
                    {
                        bit = 'C';
                        break;
                    }
                case 'C':
                    {
                        bit = 'G';
                        break;
                    }
                default:
                    break;
            }
            DNAArray[i] = bit;
        }
        Array.Reverse(DNAArray);
        DNAInput = new string(DNAArray);

    }

    public static bool Dyad(string DNAInput, int min = 5)
    {
        Console.WriteLine(DNAInput);
        bool output = false;
        string init = DNAInput.Substring(0, min);
        Console.WriteLine(init);
        ReverseComplement(ref DNAInput);
        string end = DNAInput.Substring(0, min);
        if (init == end)
        {
            
            output = true;
        }
        return output;
    }
}
