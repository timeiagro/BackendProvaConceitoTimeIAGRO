namespace WebLivros.Models;

public class ServiceReponse<T>
{
    public List<T> Dados { get; set; } = new List<T>();
    public string Mensagem { get; set; } = string.Empty;
    public bool Sucesso { get; set; } = true;
}
