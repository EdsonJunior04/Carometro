USE FACE_CHECK
GO

INSERT INTO TIPOUSUARIO(nomeTipoU)
VALUES ('Administrador'),('Colaborador')
GO

INSERT INTO PERIODOS(nomePeriodo)
VALUES ('Manha'),('Tarde')
GO

INSERT INTO USUARIO(idTipoU,nomeUsuario,email,senha)
VALUES ('1','Adminstrador','adm@adm.com','adm12345'), ('2','Colaborador','colaborador@gmail.com','colab123')
GO

INSERT INTO SALAS(idPeriodo, nomeSala)
VALUES ('1','1A'),('2','1B')
GO

INSERT INTO ALUNOS(idSala, nomeAluno, dataNascimento, RA,imagem)
VALUES ('1','Gustavo Barros','04/03/2004','1234567', 'https://logowik.com/content/uploads/images/911_brasil.jpg'),('2','Nathalia','10/12/2004','7654321', 'https://imagepng.org/wp-content/uploads/2017/04/bandeira-do-brasil.png')
