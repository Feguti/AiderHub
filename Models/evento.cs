namespace AiderHub.Models 
{
    public class Evento
    {
        public int id_Evento { get; set; }
        public System.DateTime data_Hora { get; set; }
        public string Endereco { get; set; }
        public System.TimeSpan Carga_Horario { get; set; }
        public string Descricao { get; set; }
        public string Responsavel { get; set; }

        public Evento() { }

        public Evento(int id_evento, System.DateTime data_hora, string endereco, System.TimeSpan carga_horario, string descricao, string responsavel)
        {
            id_Evento = id_evento;
            data_Hora = data_hora;
            Endereco = endereco;
            Carga_Horario = carga_horario;
            Descricao = descricao;
            Responsavel = responsavel;
        }
    }
}