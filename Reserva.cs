namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public bool confirmacao = false;

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            //  Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            Hospedes = hospedes;
            if (ObterQuantidadeHospedes() <= Suite.Capacidade)
            {
                Hospedes = hospedes;
                confirmacao = true;
                ResumoReserva();
            }
            else
            {
                confirmacao = false;    
                ResumoReserva();             
                              
                throw new Exception("Quantidade de hóspedes excede a capacidade da suíte.");
                              
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
            
        }

        public decimal CalcularValorDiaria()
        {
            //  Retorna o valor da diária
            decimal valor = 0;

            // Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
   
            valor = DiasReservados * Suite.ValorDiaria;

            if ( DiasReservados > 10)
            {
                valor = valor  * 10 / 100;
            }

            return valor;
        }

        public void ResumoReserva(){
            string resumo = "" ;

            if(confirmacao){
                resumo += "\n\n---------------- Dados da Reserva -------------------\n\n";
                resumo += "Reserva confirmada.";
                resumo += "\nDados da suíte: " + this.Suite.TipoSuite + " capacidade: " + this.Suite.Capacidade + " pessoas";
                resumo += "\nReservada para: ";
                foreach( Pessoa p in Hospedes) {
                    resumo += p.NomeCompleto + "/ ";
                }
                resumo += "\nQuantidade de dias: " + DiasReservados;
                resumo += "\nValor da diária: " + Suite.ValorDiaria;
                resumo += "\nValor Total:" + CalcularValorDiaria();
                
                Console.WriteLine(resumo);
            }
            else{
                resumo += "\n\n---------------- Dados da Reserva -------------------\n\n";
                resumo += "********* Reserva não confirmada! *********";
                resumo += "\nDados da suíte: " + Suite.TipoSuite + " - Capacidade: " + Suite.Capacidade + " pessoas";
                resumo += "\nPor favor, procure uma suíte capaz de acolher " + ObterQuantidadeHospedes() + " hóspedes.";               
                

                Console.WriteLine(resumo);
            }
        }
    }
}