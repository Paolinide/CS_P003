using System;

namespace CS_P003
{
    public class Menu
    {
        string nome;
        string[] menu;
        public Menu(string n = "NUOVO MENU", string[] m = new string[] {"  1) Primo.", "  2) Secondo.", "  3) Terzo."}) {
            nome = n;
            menu = m;
        }
    }
}