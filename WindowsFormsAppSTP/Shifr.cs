using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppSTP
{
    internal class Shifr
    {
        private static ushort key = 0x008800;
        public static string EncodeDecrypt(string str)
        {
            var ch = str.ToArray(); //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
                newStr += TopSecret(c);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return newStr;
        }
        public static char TopSecret(char character)
        {
            character = (char)(character ^ key); //Производим XOR операцию
            return character;
        }
    }
}
