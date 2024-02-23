using System;
namespace student1028
{
    public class VerificadorAnagrama
    {
        public bool VerificarAnagrama(string palavra1, string palavra2)
        {
            if (palavra1 == null || palavra2 == null)
                return false;

            // Remover espaços e converter para minúsculas
            palavra1 = palavra1.Replace(" ", "").ToLower();
            palavra2 = palavra2.Replace(" ", "").ToLower();

            // Verificar se possuem o mesmo comprimento
            if (palavra1.Length != palavra2.Length)
                return false;

            // Ordenar as letras
            char[] palavra1Array = palavra1.ToCharArray();
            char[] palavra2Array = palavra2.ToCharArray();
            Array.Sort(palavra1Array);
            Array.Sort(palavra2Array);

            // Verificar se são iguais
            for (int i = 0; i < palavra1Array.Length; i++)
            {
                if (palavra1Array[i] != palavra2Array[i])
                    return false;
            }

            return true;
        }
    }
}

