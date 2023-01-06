using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Carolina");
Pessoa p2 = new Pessoa(nome: "Diana");

Pessoa p3 = new Pessoa(nome: "Hóspede 3");
Pessoa p4 = new Pessoa(nome: "Hóspede 4");

Pessoa p5 = new Pessoa(nome: "Hóspede 5");
Pessoa p6 = new Pessoa(nome: "Hóspede 6");

hospedes.Add(p1);
hospedes.Add(p2);
//hospedes.Add(p3);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 130);

// Cria uma nova reserva, passando a suíte e os hóspedes

Reserva reserva = new Reserva(diasReservados: 5);
Console.WriteLine($"Hóspedes: {hospedes}");
reserva.CadastrarSuite(suite);
try
{
    reserva.CadastrarHospedes(hospedes);    
}
catch (System.Exception e)
{
    
    Console.WriteLine("Erro: {0}", e.Message);
}

