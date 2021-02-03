USE dbTeste

GO

--SP_HELPTEXT CADASTRAR_PESSOA


-- O IDEAL SERIA USAR DATATABLE

CREATE OR ALTER PROCEDURE CADASTRAR_PESSOA
(
     @Numero varchar(max),
     @Nome varchar(max),
     @Email varchar(max),
     @Idade INT,
	 @Sexo varchar(max),
)
  
AS    
BEGIN    
DECLARE @ERRMSG NVARCHAR(MAX), @ErrSeverity INT     
    
BEGIN TRY;    
BEGIN TRAN    
    
    
UPDATE Pessoa     
SET Nome = @Nome
,Email = @Email
,Idade = @Idade
,Sexo = @Sexo

WHERE Numero = @Numero     
    
    
COMMIT    
END TRY    
BEGIN CATCH               
SELECT  @ERRMSG = ERROR_MESSAGE(),                    
@ErrSeverity = ERROR_SEVERITY()                                 
RAISERROR(@ERRMSG, @ErrSeverity, 1)                      
ROLLBACK;                               
END CATCH                                     
END    
