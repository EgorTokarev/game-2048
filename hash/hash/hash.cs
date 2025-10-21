using System;
using Crypt = System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash
{
    public class MD5 : IHash
    {
        public MD5() { }

        public string GetHash(string data)
        {
            Crypt.MD5 MD5Hash = Crypt.MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(data); //преобразуем строку в массив байтов

            byte[] hash = MD5Hash.ComputeHash(inputBytes); //получаем хэш в виде массива байтов

            return Convert.ToHexString(hash); //преобразуем хэш из массива в строку, состоящую из шестнадцатеричных символов в верхнем регистре

        }
    }

    public class SHA1 : IHash
    {
        public SHA1()
        {

        }

        public string GetHash(string data)
        {
            Crypt.SHA1 MD5Hash = Crypt.SHA1.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(data); //преобразуем строку в массив байтов

            byte[] hash = MD5Hash.ComputeHash(inputBytes); //получаем хэш в виде массива байтов

            return Convert.ToHexString(hash); //преобразуем хэш из массива в строку, состоящую из шестнадцатеричных символов в верхнем регистре

        }
    }

    public abstract class AHash
    {
        public abstract string GetHash(string data);
    }

    public interface IHash
    {
        string GetHash(string data);
    }
}
