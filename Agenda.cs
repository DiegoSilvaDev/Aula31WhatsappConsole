using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Whatsapp
{
    public class Agenda : IAgenda
    {

        List<Contato> contatos = new List<Contato>();
        private const string PATH = "Database/agenda.csv";


        public Agenda(){
            if(!(Directory.Exists(PATH))){
                Directory.CreateDirectory("Database");
            }
            if(!(File.Exists(PATH))){
                File.Create(PATH).Close();
            }
        }
    
        /// <summary>
        /// Cadastra um novo contato
        /// </summary>
        /// <param name="_cont">argumento "Contato novo"</param>
        public void Cadastrar(Contato _cont)
        {
            var linha = new string[] { PrepararLinhaCSV(_cont) };
            File.AppendAllLines(PATH, linha);
        }

        public void CadastrarMensagem(Mensagem mensagem){
            var linha = new string[] { PrepararLinhaCSV(mensagem) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Exclui um contato
        /// </summary>
        /// <param name="_delCont">Argumento "Contato deletado"</param>
        public void Excluir(string _delCont){
            List<string> linhas =  new List<string>();

            LerCSV(linhas);

            linhas.RemoveAll(l => l.Contains(_delCont));

            ReescreverCSV(linhas);
        }

        public List<Contato> Listar()
        {
            List<Contato> contatos = new List<Contato>();

            string[] linhas = File.ReadAllLines(PATH);
            
            foreach (var linha in linhas){
                string[] dados = linha.Split(";");

                Contato cont = new Contato();
                cont.Nome = Separar(dados[0]);
                cont.Telefone = Separar(dados[1]);

                contatos.Add(cont);
            }

            contatos = contatos.OrderBy(y => y.Nome).ToList();

            return contatos;

        }

        public void ReescreverCSV(List<string> lines){
            using(StreamWriter output = new StreamWriter(PATH)){
                // output.Write(String.Join(Environment.NewLine, linhas.ToArray()));
                foreach(string ln in lines){
                    output.Write(ln + "\n");
                }
            }
        }

        public void LerCSV(List<string> lines){
            using(StreamReader arquivo = new StreamReader(PATH)){
                string line;
                while((line = arquivo.ReadLine()) != null){
                    lines.Add(line);
                }
            }
        }

        public string Separar(string dado)
        {
            return dado.Split("=")[1];
        }
        

        private string PrepararLinhaCSV(Contato novoContato){
            return $"nome = {novoContato.Nome};telefone = {novoContato.Telefone}";
        }
        private string PrepararLinhaCSV(Mensagem men){
            return $"Mensagem = {men.Texto};Destinatario = {men.Destinatario}";
        }
    }

}