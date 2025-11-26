using System.Text.Json;

namespace ZeGotao.DAL
{
    public static class JsonDatabase
    {
        //Caminho da pasta onde os arquivos JSON serão armazenados
        private static readonly string DataFolder =
            Path.Combine(Environment.CurrentDirectory, "Data");

        //Construtor estático - executado uma
        //vez quando a classe é usada pela primeira vez
        static JsonDatabase()
        {
            if (!Directory.Exists(DataFolder))
            {
                Directory.CreateDirectory(DataFolder);
            }
        }

        //Lê uma lista de objetos do tipo T a partir de um arquivo JSON
        //Cria o arquivo vazio se ele não existir
        public static List<T> Ler<T>(string fileName) where T : class
        {
            string path = Path.Combine(DataFolder, fileName);

            // Cria o arquivo JSON vazio (Lista vazia) caso não exista
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "[]");
            }

            // Lê o conteúdo do arquivo JSON
            string json = File.ReadAllText(path);

            // Desserealiza para uma lista do tipo T,
            // retornando uma lista vazia se for null
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();

        }

        public static void Salvar<T>(string fileName, List<T> lista) where T : class
        {
            string path = Path.Combine(DataFolder, fileName);

            // Serializa a lista para JSON com indentação(legivel)
            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(path, json);
        }
    }
}