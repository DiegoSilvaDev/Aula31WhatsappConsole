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
        

            contact.Cadastrar(cont1);
            contact.Excluir("José");
            
            List<Contato> lista = new List<Contato>();
            lista = contact.Listar();

            foreach( Contato item in lista)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine($"{item.Nome} - {item.Telefone}");
                Console.ResetColor();
            }

            System.Console.WriteLine();

            men1.Texto="'Eae po, suave' \n";
            men1.Enviar("Pedro");
            contact.CadastrarMensagem(men1);
            System.Console.WriteLine($"{men1.Texto}foi enviado para {men1.Destinatario}");
        }
    }
}
