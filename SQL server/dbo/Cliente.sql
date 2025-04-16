create table Cliente
(
    id       uniqueidentifier not null
        primary key,
    idPerson uniqueidentifier not null
        constraint FK_Cliente_Person
            references Person
            on delete cascade
)
go

