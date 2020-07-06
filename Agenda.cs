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

        /// <summary>
        /// Responsável por criar o diretório "Database" e o arquivo "Agenda" caso não existir
        /// </summary>
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
        /// <param name="_cont">argumento "Contato novo" salvo no CSV</param>
        public void Cadastrar(Contato _cont)
        {
            var linha = new string[] { PrepararLinhaCSV(_cont) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Cadastra a mensagem no CSV
        /// </summary>
        /// <param name="mensagem">mensagem salva no CSV</param>
        public void CadastrarMensagem(Mensagem mensagem){
            var linha = new string[] { PrepararLinhaCSV(mensagem) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Exclui um contato
        /// </summary>
        /// <param name="_delCont">Argumento "Contato deletado"</param>
        public void Excluir(Contato _delCont){
            List<string> linhas =  new List<string>();

            LerCSV(linhas);

            linhas.RemoveAll(l => l.Contains(_delCont.Nome));

            ReescreverCSV(linhas);
        }

        /// <summary>
        /// Lê os contatos 
        /// </summary>
        /// <returns>retorna os contatos por nome e número</returns>
        public List<Contato> Listar()
        {
            List<Contato> contatos = new List<Contato>();

            string[] linhas = File.ReadAllLines(PATH);
            
            foreach (var linha in linhas){
                string[] dados = linha.Split(";");

                Contato cont = new Contato( dados[0], dados[1]);

                contatos.Add(cont);
            }

            contatos = contatos.OrderBy(y => y.Nome).ToList();

            return contatos;

        }

        /// <summary>
        /// Reescreve o CSV
        /// </summary>
        /// <param name="lines">Lista de linhas</param>
        public void ReescreverCSV(List<string> lines){
            using(StreamWriter output = new StreamWriter(PATH)){
                // output.Write(String.Join(Environment.NewLine, linhas.ToArray()));
                foreach(string ln in lines){
                    output.Write(ln + "\n");
                }
            }
        }

        /// <summary>
        /// Lê o CSV
        /// </summary>
        /// <param name="lines">lista de linhas</param>
        public void LerCSV(List<string> lines){
            using(StreamReader arquivo = new StreamReader(PATH)){
                string line;
                while((line = arquivo.ReadLine()) != null){
                    lines.Add(line);
                }
            }
        }

        /// <summary>
        /// Separa os itens por colunas
        /// </summary>
        /// <param name="dado">separa os itens do csv</param>
        /// <returns>valor da indice [1] da coluna</returns>
        public string Separar(string dado)
        {
            return dado.Split("=")[1];
        }
        
        /// <summary>
        /// Prepara as linhas 
        /// </summary>
        /// <param name="novoContato">item colocado no console</param>
        /// <returns>itens</returns>
        private string PrepararLinhaCSV(Contato novoContato){
            return $"nome = {novoContato.Nome};telefone = {novoContato.Telefone}";
        }

        /// <summary>
        /// Prepara as linhas
        /// </summary>
        /// <param name="men">Armazena a mensagem</param>
        /// <returns>mensagens</returns>
        private string PrepararLinhaCSV(Mensagem men){
            return $"Mensagem = {men.Texto};Destinatario = {men.Destinatario}";
        }
    }

}