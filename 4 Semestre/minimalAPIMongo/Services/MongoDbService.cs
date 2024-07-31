using MongoDB.Driver;

namespace minimalAPIMongo.Services
{
    public class MongoDbService
    {
        /// <summary>
        /// Armazenar a configuração de aplicação
        /// </summary>
        private readonly IConfiguration _configuration;
        /// <summary>
        /// armazena uma referência ao MongoDb
        /// </summary>
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Contém a configuração necessário para acesso ao MongoDb
        ///
        /// </summary>
        /// <param name="configuration">Objeto contendo toda a configuração da aplicação</param>
        public MongoDbService(IConfiguration configuration)
        {
            //Atribui a config recebida em _configuration
            _configuration = configuration;
            
            //Acessa a string de conexão
            var connectionString = _configuration.GetConnectionString("DbConnection");
            
            //Transforma a string obtida em MongoUrl
            var mongoUrl = MongoUrl.Create(connectionString);

            //Cria um client
            var mongoClient = new MongoClient(mongoUrl);

            //obtém a referencia ao MongoDb
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        /// <summary>
        /// Propriedade para acessar o db => retorna os dados em _database
        /// </summary>
        public IMongoDatabase GetDatabaseBase => _database;
    }
}
