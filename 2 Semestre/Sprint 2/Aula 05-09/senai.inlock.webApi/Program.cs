using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options => {

    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Validade quem est� solicitando 
        ValidateIssuer = true,

        //Valida quem est� recebendo
        ValidateAudience = true,

        //Valida se o tempo de expira��o do token ser� validado
        ValidateLifetime = true,

        // Forma de criptografia e ainda valida��o da chave de autentica��o
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlocker-chave-autenticacao-webapi-dev")),

        //Valida o tempo de experi��o do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //De onde est� vindo (issuer)
        ValidIssuer = "senai.inlock.webApi.",

        //Para onde est� indo (audience)
        ValidAudience = "senai.inlock.webApi.",
    };

});


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API inlock tarde",
        Description = "API para gerenciamento de jogos - pr�tica da sprint 2 - backend API",
        Contact = new OpenApiContact
        {
            Name = "Pedro Henrique",
            Url = new Uri("https://github.com/Pedrohbedin/Pedrohbedin")
        }
    });

    // Configurar o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    /* Issue */

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JTM",
        In = ParameterLocation.Header,
        Description = "Value: Bearer Toker.JMT"
    });

    options.AddSecurityRequirement
    (new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[]{ }
            }
        }
    );
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Para atender � interface do usu�rio do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseAuthentication();

app.UseAuthorization();

//Mapeia os controllers 
app.MapControllers();

app.Run();
