using System;
using System.Runtime.Serialization;
 
namespace ServicoRest
{
 
    [DataContract]
    public class UsuarioEntity
    {
 
        private Nullable<int> codigo;
        private String nome;
        private String login;
        private String senha;
        private String tipo;
        private Boolean registroAtivo;
        private Int32 codigoSetor;
 
 
        [DataMember]
        public int? Codigo
        {
            get
            {
                return codigo;
            }
 
            set
            {
                codigo = value;
            }
        }
 
        [DataMember]
        public string Nome
        {
            get
            {
                return nome;
            }
 
            set
            {
                nome = value;
            }
        }
 
        [DataMember]
        public string Login
        {
            get
            {
                return login;
            }
 
            set
            {
                login = value;
            }
        }
 
        [DataMember]
        public string Senha
        {
            get
            {
                return senha;
            }
 
            set
            {
                senha = value;
            }
        }
 
        [DataMember]
        public string Tipo
        {
            get
            {
                return tipo;
            }
 
            set
            {
                tipo = value;
            }
        }
 
        [DataMember]
        public bool RegistroAtivo
        {
            get
            {
                return registroAtivo;
            }
 
            set
            {
                registroAtivo = value;
            }
        }
 
        [DataMember]
        public int CodigoSetor
        {
            get
            {
                return codigoSetor;
            }
 
            set
            {
                codigoSetor = value;
            }
        }
    }
}
