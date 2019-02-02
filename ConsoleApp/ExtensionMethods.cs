using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public static class ExtensionMethods
    {
        public static int ContadorPalavras(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
