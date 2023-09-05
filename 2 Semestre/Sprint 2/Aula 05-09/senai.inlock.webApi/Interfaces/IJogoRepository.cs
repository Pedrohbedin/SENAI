using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IJogoRepository
    {
        List<JogoDomain> ListarTodos();

        void Cadastrar(JogoDomain novoJogo);
    }
}
