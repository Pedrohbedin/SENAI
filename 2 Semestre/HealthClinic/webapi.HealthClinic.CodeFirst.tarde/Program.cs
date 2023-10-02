using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddMvc()
    .AddNewtonsoftJson();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options => {

        options.TokenValidationParameters = new TokenValidationParameters
        {
            //Validade quem está solicitando 
            ValidateIssuer = true,

            //Valida quem está recebendo
            ValidateAudience = true,

            //Valida se o tempo de expiração do token será validado
            ValidateLifetime = true,

            // Forma de criptografia e ainda validação da chave de autenticação
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("HealthClinic-chave-autenticacao-webapi-dev")),

            //Valida o tempo de experição do token
            ClockSkew = TimeSpan.FromMinutes(5),

            //De onde está vindo (issuer)
            ValidIssuer = "webapi.HealthClinic.CodeFirst.tarde",

            //Para onde está indo (audience)
            ValidAudience = "webapi.HealthClinic.CodeFirst.tarde",
        };

    });

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API HealthClinic tarde",
        Description = "Health API - prática da sprint 2 - backend API",
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
