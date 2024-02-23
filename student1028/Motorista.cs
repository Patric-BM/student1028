
namespace student1028;

public class Motorista
{

   public Motorista()
    {
    }

    public string EncontrarMotoristas(List<Pessoa> pessoas)
    {
        var motoristas = new List<Pessoa>();
        foreach (var pessoa in pessoas)
        {
            if (pessoa.Idade < 18)
            {
                continue;
            }

            if (pessoa.PossuiHabilitacaoB)
            {
                motoristas.Add(pessoa);
                if (motoristas.Count >= 2)
                {
                    return string.Join(", ", motoristas.Select(p => p.Nome));
                }
            }
        }

        throw new Exception("A viagem não será realizada devido falta de motoristas!");
    }

    public class Pessoa
    {
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public bool PossuiHabilitacaoB { get; set; }
    }

}

