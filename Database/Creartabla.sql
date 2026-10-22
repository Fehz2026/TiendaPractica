
CREATE TABLE [dbo].[Categorias] (
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Nombre] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[Productos] (
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Nombre] NVARCHAR(100) NOT NULL,
    [Precio] DECIMAL(18,2) NOT NULL,
    [CategoriaId] INT NOT NULL,
    CONSTRAINT [PK_Productos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Productos_Categorias] FOREIGN KEY ([CategoriaId])
        REFERENCES [dbo].[Categorias]([Id]) ON DELETE CASCADE
);
  
INSERT INTO dbo.Categorias (Nombre)
VALUES
    ('Papelería'),
    ('Ropa'),
    ('Alimentos'),
    ('Electrónica'),
    ('Hogar');

