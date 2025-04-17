create table Cargos
(
    id        uniqueidentifier not null
        primary key,
    nome      varchar(20)      not null,
    descricao varchar(60) default NULL,
    salario   float            not null
)
go

