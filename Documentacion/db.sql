--TABLA USUARIOS
CREATE TABLE [dbo].[TBL_USUARIOS]
(
	[USUARIOID] NVARCHAR(255) NOT NULL PRIMARY KEY,
	[NOMBRE] NVARCHAR(255) NOT NULL
);

--INSERT EN USUARIOS
CREATE PROCEDURE [dbo].[CRE_USUARIO_PR]
	@P_USUARIOID NVARCHAR(255),
	@P_NOMBRE nvarchar(255) 
AS
	INSERT INTO [dbo].[TBL_USUARIOS] VALUES(@P_USUARIOID,@P_NOMBRE);

-- RETRIEVE USUARIO BY ID
CREATE PROCEDURE [dbo].[RET_USUARIO_PR] 
	@P_USUARIOID NVARCHAR(255)
AS
	SELECT * FROM TBL_USUARIOS WHERE USUARIOID=@P_USUARIOID;	

--------------------------------------------------------------------------------------
-- TABLA DICCIONARIOS
CREATE TABLE [dbo].[TBL_DICCIONARIOS]
(
	[DICCIONARIOID] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[NOMBRE] NVARCHAR(255) NOT NULL UNIQUE
);

--INSERT EN DICCIONARIOS
CREATE PROCEDURE [dbo].[CRE_DICCIONARIO_PR]
	@P_NOMBRE NVARCHAR(255)
AS
	INSERT INTO [dbo].[TBL_DICCIONARIOS] VALUES(@P_NOMBRE);

-- RETRIEVE ALL DICCIONARIOS
CREATE PROCEDURE [dbo].[RET_ALL_DICCIONARIOS_PR]
AS
	SELECT * FROM TBL_DICCIONARIOS;

-- RETRIEVE DICCIONARIO BY NAME
CREATE PROCEDURE [dbo].[RET_DICCIONARIO_PR]
	@P_NOMBRE NVARCHAR(255)
AS
	SELECT * FROM TBL_DICCIONARIOS WHERE NOMBRE=@P_NOMBRE;

----------------------------------------------------------------------------------------
-- TABLA PALABRAS
CREATE TABLE [dbo].[TBL_PALABRAS]
(
	[PALABRAID] INT IDENTITY (1,1) NOT NULL PRIMARY,
	[DICCIONARIOID] INT NOT NULL REFERENCES TBL_DICCIONARIOS(DICCIONARIOID),
	[PALABRA] NVARCHAR(255) NOT NULL,
	[SIGNIFICADO] NVARCHAR(255) NOT NULL
);

--INSERT EN PALABRAS
CREATE PROCEDURE [dbo].[CRE_PALABRA_PR]
	@P_DICCIONARIOID INT,
	@P_PALABRA NVARCHAR(255),
	@P_SIGNIFICADO NVARCHAR(255)
AS
	INSERT INTO [dbo].[TBL_PALABRAS] VALUES(@P_DICCIONARIOID,@P_PALABRA,@P_SIGNIFICADO);

--RETRIEVE ALL PALABRAS BY DICCIONARIO
CREATE PROCEDURE [dbo].[RET_ALL_PALABRAS_ID_PR]
	@P_DICCIONARIOID INT
AS
	SELECT * FROM TBL_PALABRAS WHERE DICCIONARIOID=@P_DICCIONARIOID;


--RETRIEVE PALABRA BY DICCIONARIO & PALABRA
CREATE PROCEDURE [dbo].[RET_PALABRA_DIC_PR]
	@P_PALABRA NVARCHAR(255),
	@P_DICCIONARIOID INT
AS
	SELECT * FROM TBL_PALABRAS WHERE DICCIONARIOID=@P_DICCIONARIOID AND PALABRA=@P_PALABRA;

----------------------------------------------------------------------------------------
--TABLA TRADUCCIONES
CREATE TABLE [dbo].[TBL_TRADUCCIONES]
(
	[TRADUCCIONID] INT IDENTITY (1,1) NOT NULL PRIMARY,
	[PALABRAID] INT NOT NULL REFERENCES TBL_PALABRAS(PALABRAID),
	[USUARIOID] NVARCHAR(255) NOT NULL REFERENCES TBL_USUARIOS(USUARIOID),
	[DICCIONARIOID] INT NOT NULL REFERENCES TBL_DICCIONARIOS(DICCIONARIOID),
	[FECHA] DATE NOT NULL
);

--INSERT EN TRADUCCIONES
CREATE PROCEDURE [dbo].[CRE_TRADUCCION_PR]
	@P_PALABRAID INT,
	@P_USUARIOID NVARCHAR(255),
	@P_DICCIONARIOID INT,
	@P_FECHA
AS
	INSERT INTO [dbo].[TBL_TRADUCCIONES] VALUES (@P_PALABRAID, @P_USUARIOID, @P_DICCIONARIOID, @P_FECHA);






















