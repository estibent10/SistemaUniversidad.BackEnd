
CREATE DATABASE Universidades
GO

USE Universidades
GO

CREATE OR ALTER PROCEDURE SP_Sedes_Actualizar
    @CodigoSede INT,
    @CodigoUniversidad INT,
    @Direccion VARCHAR(500),
    @Email VARCHAR(20),
    @Telefono VARCHAR(20),
	@ModificadoPor VARCHAR(60),
	@ExisteError BIT OUTPUT,
	@DetalleError VARCHAR(60) OUTPUT
	AS
	BEGIN TRY
		BEGIN TRANSACTION
			DECLARE @ExisteSede BIT
		
			SET @ExisteSede = dbo.FN_Sedes_VerificaExistenciaPorId(@CodigoSede)
		
			IF(@ExisteSede = 1)
				BEGIN
					UPDATE Sedes
					SET
						CodigoUniversidad=@CodigoUniversidad,
						Direccion = @Direccion,
						Email = @Email,
						Telefono=@Telefono,
						FechaModificacion = GETDATE(),
						ModificadoPor = @ModificadoPor
					WHERE 
						CodigoSede = @CodigoSede

					SET @ExisteError = 0
				END
			ELSE
				BEGIN
					SET @ExisteError = 1
					SET @DetalleError = 'Sede: '+	@CodigoSede	+'. No Existe'
				END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH

		ROLLBACK TRANSACTION
		
		DECLARE @NumeroDeError INT 
		EXEC @NumeroDeError = SP_ErroresBD_Insertar @ModificadoPor

		SET @ExisteError = 1
		SET @DetalleError = 'Error al actualizar la sede: '+	@CodigoSede	+ '. Número de Error: ' + @NumeroDeError		

	END CATCH
GO

CREATE OR ALTER PROCEDURE SP_EmailDeDocentes_Actualizar
		@Identificacion VARCHAR(20),
		@EmailUniversidad VARCHAR(50),
		@EmailPersonal VARCHAR(50),
		@ModificadoPor VARCHAR(60),
		@ExisteError BIT OUTPUT,
		@DetalleError VARCHAR(60) OUTPUT
	AS
	BEGIN TRY
		BEGIN TRANSACTION
			DECLARE @ExisteEmailDeDocente BIT
		
			SET @ExisteEmailDeDocente = dbo.FN_EmailDeDocentes_VerificaExistenciaPorId(@Identificacion)
		
			IF(@ExisteEmailDeDocente = 1)
				BEGIN
					UPDATE EmailDeDocentes
					SET
						EmailUniversidad = @EmailUniversidad,
						EmailPersonal = @EmailPersonal,
						FechaModificacion = GETDATE(),
						ModificadoPor = @ModificadoPor
					WHERE 
						Identificacion = @Identificacion

					SET @ExisteError = 0
				END
			ELSE
				BEGIN
					SET @ExisteError = 1
					SET @DetalleError = 'Email de Docente: ' + @Identificacion +'. No Existe'
				END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH

		ROLLBACK TRANSACTION
		
		DECLARE @NumeroDeError INT 
		EXEC @NumeroDeError = SP_ErroresBD_Insertar @ModificadoPor

		SET @ExisteError = 1
		SET @DetalleError = 'Error al actulizar el Email del Docente: '+ @Identificacion	+ '. Número de Error: ' + @NumeroDeError		

	END CATCH
GO
