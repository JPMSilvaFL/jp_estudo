create table Person
(
    id        uniqueidentifier   not null
        primary key,
    cpf       varchar(11)        not null
        unique,
    full_name nvarchar(100)      not null,
    email     nvarchar(100)      not null,
    contato   bigint             not null,
    isActive  bit      default 1 not null,
    endereco  nvarchar(150)      not null,
    createdAt datetime           not null,
    updatedAt datetime default NULL
)
go

