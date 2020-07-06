namespace Whatsapp
{
    public class Mensagem
    {
        public string Texto { get; set; }
        public string Destinatario { get; set; }

        public string Enviar(string _destinatario){
            this.Destinatario = _destinatario;
            return $"A seguinte mensagem {Texto} foi enviado para {Destinatario}";
        }
    }
}