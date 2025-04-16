create table Funcionario
(
    id             uniqueidentifier not null
        primary key,
    idPerson       uniqueidentifier not null
        constraint PK_Funcionario_Person
            references Person
            on delete cascade,
    idCargo        int              not null,
    dataDeIngresso datetime         not null
)
go

