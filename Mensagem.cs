namespace Whatsapp
{
    public class Mensagem
    {
        public string Texto { get; set; }
        public Contato Destinatario { get; set; }

        /// <summary>
        /// Envia a mensagem
        /// </summary>
        /// <returns>Retorna a mensagem e para quem foi enviada</returns>
        public string Enviar(){
            return $"A seguinte mensagem {Texto} foi enviado para {Destinatario}";
        }
    }
}