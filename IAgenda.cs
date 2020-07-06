
using System.Collections.Generic;

namespace Whatsapp
{
    public interface IAgenda
    {
        void Cadastrar(Contato _cont);

        void Excluir(Contato _delCont);

        List<Contato> Listar(); 
    }
}