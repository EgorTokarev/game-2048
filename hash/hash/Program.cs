// See https://aka.ms/new-console-template for more information
using hash;


List<IHash> hashList = new List<IHash>() { new SHA1(), new MD5() };

string data = File.ReadAllText(@"d:\Мои документы\1234.TXT");

foreach (var hash in hashList)
{
    Console.WriteLine(hash.GetHash(data));   
}
