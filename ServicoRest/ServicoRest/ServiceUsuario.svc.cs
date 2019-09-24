using System;
using System.Collections.Generic;

namespace ServicoRest
{

    public class ServiceUsuario : IServiceUsuario
    {


        UsuarioRepository usuarioRepository = new UsuarioRepository();

        public string AtualizarRegistro(UsuarioEntity usuarioEntity)
        {
            try
            {
                usuarioRepository.Update(usuarioEntity);

                return "Registro atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro ao atualizar o registro: " + ex.Message;
            }

        }

        public UsuarioEntity ConsultarRegistroPorCodigo(string codigo)
        {
            return usuarioRepository.SelectPorID(Convert.ToInt32(codigo));
        }

        public IList<UsuarioEntity> ConsultarTodosUsuarios()
        {
            return usuarioRepository.Select();
        }

        public string ExcluirUsuario(string codigo)
        {
            try
            {
                usuarioRepository.Delete(Convert.ToInt32(codigo));

                return "Registro excluido com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro ao excluir o registro: " + ex.Message;
            }
        }

        public string InserirNovoRegistro(UsuarioEntity usuarioEntity)
        {
            try
            {
                usuarioRepository.Insert(usuarioEntity);

                return "Registro inserido com sucesso!";

            }
            catch (Exception ex)
            {
                return "Erro ao inserir o registro: " + ex.Message;
            }
        }
    }
}
