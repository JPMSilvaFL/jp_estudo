create table Funcionarios
(
    id             uniqueidentifier not null
        primary key,
    idPerson       uniqueidentifier not null
        constraint FK_Funcionario_Person
            references Person
            on delete cascade,
    idCargo        uniqueidentifier not null
        constraint FK_Funcionario_Cargos
            references Cargos,
    dataDeIngresso datetime         not null
)
go

