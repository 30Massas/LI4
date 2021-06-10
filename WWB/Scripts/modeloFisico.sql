USE master
GO
IF NOT EXISTS (
 SELECT name
 FROM sys.databases
 WHERE name = N'WWB'
)
 CREATE DATABASE [WWB];
GO
-- -----------------------------------------------------
-- Table "WWB"."Utilizador"
-- -----------------------------------------------------

-- IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL
-- DROP TABLE dbo.Customers;
-- GO

USE WWB;
IF OBJECT_ID('dbo.Utilizador','U') IS NULL
CREATE TABLE dbo."Utilizador" (
  "Id" INT PRIMARY KEY IDENTITY(1,1),
  "Username" VARCHAR(30) NOT NULL,
  "Password" VARCHAR(30) NOT NULL,
  "Data_de_nascimento" DATE NOT NULL,
  "Email" VARCHAR(45) NOT NULL,
  "Nome" VARCHAR(45) NOT NULL 
  )


-- -----------------------------------------------------
-- Table "WWB"."Liga"
-- -----------------------------------------------------
IF OBJECT_ID('dbo.Liga','U') IS NULL
CREATE TABLE dbo."Liga" (
  "Id" INT PRIMARY KEY NOT NULL,
  "Nome" VARCHAR(45) NOT NULL,
  "Localizacao" VARCHAR(45) NOT NULL,
)

-- -----------------------------------------------------
-- Table "WWB"."Equipa"
-- -----------------------------------------------------
IF OBJECT_ID('dbo.Equipa','U') IS NULL
CREATE TABLE dbo."Equipa" (
  "Id" INT PRIMARY KEY NOT NULL,
  "Nome" VARCHAR(45) NOT NULL,
  "Localizacao" VARCHAR(45) NOT NULL,
  "Liga_Id" INT NOT NULL,
  CONSTRAINT "fk_Equipa_Liga1"
    FOREIGN KEY ("Liga_Id")
    REFERENCES dbo."Liga" ("Id")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table "WWB"."Estatísticas"
-- -----------------------------------------------------
IF OBJECT_ID('dbo.Estatisticas','U') IS NULL
CREATE TABLE dbo."Estatisticas" (
  "Pontos_a_favor" INT NOT NULL,
  "Pontos_contra" INT NOT NULL,
  "Vitorias" INT NOT NULL,
  "Derrotas" INT NOT NULL,
  "Classificacao" INT NOT NULL,
  "Dif_pontos" INT NOT NULL,
  "Equipa_Id" INT PRIMARY KEY NOT NULL,
  CONSTRAINT "fk_Estatísticas_Equipa"
    FOREIGN KEY ("Equipa_Id")
    REFERENCES dbo."Equipa" ("Id")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table "WWB"."Jogo"
-- -----------------------------------------------------
IF OBJECT_ID('dbo.Jogo','U') IS NULL
CREATE TABLE dbo."Jogo"(
  "Id" INT PRIMARY KEY NOT NULL,
  "Data" DATE NOT NULL,
  "Hora" TIME NOT NULL,
  "Resultado" VARCHAR(45) NOT NULL,
  "Equipa_Casa" INT NOT NULL,
  "Equipa_Visitante" INT NOT NULL,
  CONSTRAINT "fk_Jogo_Equipa1"
    FOREIGN KEY ("Equipa_Casa")
    REFERENCES dbo."Equipa" ("Id")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT "fk_Jogo_Equipa2"
    FOREIGN KEY ("Equipa_Visitante")
    REFERENCES dbo."Equipa" ("Id")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table "WWB"."Equipas_favoritas"
-- -----------------------------------------------------
IF OBJECT_ID('dbo.Equipas_Favoritas','U') IS NULL
CREATE TABLE dbo."Equipas_Favoritas"(
  "Utilizador_Id" INT NOT NULL,
  "Equipa_Id" INT NOT NULL,
  PRIMARY KEY ("Utilizador_Id", "Equipa_Id"),
  CONSTRAINT "fk_Favoritos_Utilizador1"
    FOREIGN KEY ("Utilizador_Id")
    REFERENCES dbo."Utilizador" ("Id")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT "fk_Equipas_favoritas_Equipa1"
    FOREIGN KEY ("Equipa_Id")
    REFERENCES dbo."Equipa" ("Id")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table "WWB"."Ligas_favoritas"
-- -----------------------------------------------------
IF OBJECT_ID('dbo.Ligas_favoritas','U') IS NULL
CREATE TABLE dbo."Ligas_favoritas" (
  "Utilizador_Id" INT NOT NULL,
  "Liga_Id" INT NOT NULL,
  PRIMARY KEY ("Utilizador_Id", "Liga_Id"),
  CONSTRAINT "fk_Ligas_favoritas_Utilizador1"
    FOREIGN KEY ("Utilizador_Id")
    REFERENCES dbo."Utilizador" ("Id")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT "fk_Ligas_favoritas_Liga1"
    FOREIGN KEY ("Liga_Id")
    REFERENCES dbo."Liga" ("Id")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)


