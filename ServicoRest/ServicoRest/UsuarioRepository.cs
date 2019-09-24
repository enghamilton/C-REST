using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicoRest
{
    public class UsuarioRepository
    {


        /*INSERINDO UM NOVO REGISTRO*/
        public void Insert(UsuarioEntity usuarioEntity)
        {


            db_usuarioEntities context = new db_usuarioEntities();

            tb_usuarios usuario = new tb_usuarios();

            usuario.cd_setor = usuarioEntity.CodigoSetor;
            usuario.ds_login = usuarioEntity.Login;
            usuario.ds_senha = usuarioEntity.Senha;
            usuario.fl_ativo = (usuarioEntity.RegistroAtivo ? "S" : "N");
            usuario.fl_tipo = usuarioEntity.Tipo;
            usuario.nm_usuario = usuarioEntity.Nome;

            context.tb_usuarios.Add(usuario);
            context.SaveChanges();
        }

        /*ATUALIZANDO UM REGISTRO EXISTENTE*/
        public void Update(UsuarioEntity usuarioEntity)
        {

            using (db_usuarioEntities context = new db_usuarioEntities())
            {

                /*LOCALIZA O USUÁRIO PELO SEU CÓDIGO*/
                tb_usuarios usuario = context.tb_usuarios.Where(n => n.id_usuario == usuarioEntity.Codigo).First();


                usuario.cd_setor = usuarioEntity.CodigoSetor;
                usuario.ds_login = usuarioEntity.Login;
                usuario.ds_senha = usuarioEntity.Senha;
                usuario.fl_ativo = (usuarioEntity.RegistroAtivo ? "S" : "N");
                usuario.fl_tipo = usuarioEntity.Tipo;
                usuario.nm_usuario = usuarioEntity.Nome;
                usuario.id_usuario = usuarioEntity.Codigo.Value;


                /*SALVA AS ALTERAÇÕES REALIZADAS*/
                context.SaveChanges();
            }

        }

        public void Delete(Int32 codigo)
        {

            db_usuarioEntities context = new db_usuarioEntities();


            tb_usuarios usuario = (from n in context.tb_usuarios
                                   where n.id_usuario == codigo
                                   select n).First();


            /*EXCLUI UM REGISTRO EXISTENTE*/
            context.tb_usuarios.Remove(usuario);
            context.SaveChanges();

        }

        /*CONSULTA USUÁRIO PELO CÓDIGO*/
        public UsuarioEntity SelectPorID(Int32 codigo)
        {

            db_usuarioEntities context = new db_usuarioEntities();

            UsuarioEntity usuarioEntity = new UsuarioEntity();

            tb_usuarios usuario = (from n in context.tb_usuarios
                                   where n.id_usuario == codigo
                                   select n).First();


            usuarioEntity.Codigo = usuario.id_usuario;
            usuarioEntity.CodigoSetor = usuario.cd_setor;
            usuarioEntity.Login = usuario.ds_login;
            usuarioEntity.Nome = usuario.nm_usuario;
            usuarioEntity.RegistroAtivo = (usuario.fl_ativo == "S" ? true : false);
            usuarioEntity.Senha = usuario.ds_senha;
            usuarioEntity.Tipo = usuario.fl_tipo;

            return usuarioEntity;
        }

        /*RETORNA TODOS OS USUÁRIOS CADASTRADOS*/
        public IList<UsuarioEntity> Select()
        {
            db_usuarioEntities context = new db_usuarioEntities();

            IList<UsuarioEntity> listaUsuariosEntity = new List<UsuarioEntity>();

            IList<tb_usuarios> usuarios = (from n in context.tb_usuarios
                                           select n).ToList();

            UsuarioEntity usuarioEntity = null;

            foreach (tb_usuarios usuario in usuarios)
            {

                usuarioEntity = new UsuarioEntity();
                usuarioEntity.Codigo = usuario.id_usuario;
                usuarioEntity.CodigoSetor = usuario.cd_setor;
                usuarioEntity.Login = usuario.ds_login;
                usuarioEntity.Nome = usuario.nm_usuario;
                usuarioEntity.RegistroAtivo = (usuario.fl_ativo == "S" ? true : false);
                usuarioEntity.Senha = usuario.ds_senha;
                usuarioEntity.Tipo = usuario.fl_tipo;

                listaUsuariosEntity.Add(usuarioEntity);
            }


            return listaUsuariosEntity;
        }

    }
}
