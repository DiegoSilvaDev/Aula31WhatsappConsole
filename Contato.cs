namespace Whatsapp
{
    public class Contato
    {
        // Propriedade - PascalCase
        public string Nome { get; set; }
        // Atributo - CamelCase
        public string Telefone { get; set; }
        
        public Contato(){
            
        }
        public Contato(string _nome, string _telefone){
            this.Nome = _nome;
            this.Telefone = _telefone;
        }
    }
}