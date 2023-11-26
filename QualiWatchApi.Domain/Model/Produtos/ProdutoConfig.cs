namespace QualiWatchApi.Domain.Model.Produtos;

public static class ProdutoConfig
{
    public static int MaximoTamanho => 255;
    public static string MenssagemTamanhoMaximo => "{PropertyName} não pode exceder " + MaximoTamanho + "caracteres";
    public static string MenssagemNulo => "{PropertyName} não pode ser vazio";

}
