using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITtask2
{
    public class CaesarCipher
    {
        const string alfabetRU = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        const string alfabetUS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static string CodeEncode(string text, int k, bool a)
        {
            string alfabet;
            if (a)
            {
                alfabet = alfabetRU;
            } else
            {
                alfabet = alfabetUS;
            }
            var fullAlfabet = alfabet + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }
            return retVal;
        }

        public static string Encrypt(string plainMessage, int key, bool a)
            => CodeEncode(plainMessage, key, a);

        public static string Decrypt(string encryptedMessage, int key, bool a)
            => CodeEncode(encryptedMessage, -key, a);
    }
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
