using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace ServicoRest
{    
    [ServiceContract]
    public interface IServiceUsuario
    {
        
        /*ENTENDENDO O WebInvoke
          Method         : Determina o tipo de método
          ResponseFormat : Esse parâmetro determina o tipo de resposta que o cliente vai receber (Json ou Xml)
          RequestFormat  : Esse parâmetro determina o tipo de request que o cliente vai enviar  (Json ou Xml)
          UriTemplate    : É onde mapeamos a url que vai ser acessada   
          BodyStyle      : Quando usamos o  WebMessageBodyStyle.Bare não precisamos passar 
                           o nome do parâmetro Exemplo: 
                                                          { "Codigo": 3,
		                                                    "Nome": "Ednilson",		
		                                                    "Login":"ednilson",
		                                                    "Senha": "123456",
		                                                    "Tipo": "D",
		                                                    "RegistroAtivo": true,
		                                                    "CodigoSetor": 1
                                                           }
                           Quando usamos o  WebMessageBodyStyle.Wrapped devemos passar o nome do parâmetro (usuarioEntity) 
                           Exemplo: {

	                                    "usuarioEntity": 
	                                    {
		
		                                    "Nome": "Juliana",		
		                                    "Login":"juli",
		                                    "Senha": "123456",
		                                    "Tipo": "D",
		                                    "RegistroAtivo": true,
		                                    "CodigoSetor": 1
	                                    }
                                    }
         
            Você também pode usar WrappedRequest só para mandar o nome 
            do objeto na request ou WrappedResponse para receber com o nome do objeto na resposta                
            
        */
        [OperationContract]
        [WebInvoke(Method = "POST",
                 ResponseFormat = WebMessageFormat.Json,
                 RequestFormat = WebMessageFormat.Json,
                 BodyStyle = WebMessageBodyStyle.Wrapped,
                 UriTemplate = "InserirNovoRegistro")]
        String InserirNovoRegistro(UsuarioEntity usuarioEntity);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json,
                       BodyStyle = WebMessageBodyStyle.Bare,
                     UriTemplate = "AtualizarRegistro")]
        String AtualizarRegistro(UsuarioEntity usuarioEntity);


        [OperationContract]
        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                        BodyStyle = WebMessageBodyStyle.Wrapped,
                      UriTemplate = "ConsultarRegistroPorCodigo/{codigo}")]
        UsuarioEntity ConsultarRegistroPorCodigo(String codigo);


        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Wrapped,
              UriTemplate = "ConsultarTodosUsuarios")]
        IList<UsuarioEntity> ConsultarTodosUsuarios();


        [OperationContract]
        [WebInvoke(Method = "DELETE",
                   ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                        BodyStyle = WebMessageBodyStyle.Bare,
                      UriTemplate = "ExcluirUsuario/{codigo}")]
        String ExcluirUsuario(String codigo);
    }
}
