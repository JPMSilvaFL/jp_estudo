using System;
using Persons;

namespace Application;

internal class Teste{
    private static void Main(string[] args) {
        var client = new Cliente("042.581.811-02", "Joao Pedro", "joao.pedro.69461@gmail.com", "64 99314-0912",
            "av 7 qd 33 lt 1r");
        Console.WriteLine(client.cpf);
        Console.WriteLine(client.createdAt);
        Console.WriteLine(client.id);
    }
}