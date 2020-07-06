using System;
using System.Collections.Generic;

namespace Whatsapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Contato cont1 = new Contato("José", "11991235324");
            Agenda contact = new Agenda();
            Mensagem men1 = new Mensagem();
        

            Contato c1 = new Contato("Paulo     ", "(11) 999999-99999");
            Contato c2 = new Contato("Roberto   ", "(11) 999999-99999");
            Contato c3 = new Contato("Brandao   ", "(11) 999999-99999");

            contact.Cadastrar(c1);
            contact.Cadastrar(c2);
            contact.Cadastrar(c3);
            
            List<Contato> lista = new List<Contato>();
            lista = contact.Listar();
            contact.Excluir(c1);

            foreach( Contato item in lista)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine($"{item.Nome} - {item.Telefone}");
                Console.ResetColor();
            }

            Mensagem msg = new Mensagem();
            msg.Destinatario = c3;
            msg.Texto  = "Olá " + msg.Destinatario.Nome + "!";
            Console.WriteLine( msg.Enviar());


        }
    }
}
