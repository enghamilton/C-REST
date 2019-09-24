/*CRIANDO A BASE DE DADOS*/
CREATE DATABASE db_usuario;


/*CRIANDO A NOSSA TABELA*/
CREATE TABLE tb_usuarios(
 
 id_usuario INT AUTO_INCREMENT,
 nm_usuario VARCHAR(100) NOT NULL,
 ds_login	VARCHAR(10)  NOT NULL,
 ds_senha   VARCHAR(10)  NOT NULL,
 fl_tipo    CHAR(1) NOT NULL,
 fl_ativo   CHAR(1) NOT NULL,
 cd_setor	INT  NOT NULL,
 
 CONSTRAINT pk_id_usuario PRIMARY KEY (id_usuario)
);



