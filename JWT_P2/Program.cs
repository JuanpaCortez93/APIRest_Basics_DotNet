using FluentValidation;
using JWT_P2.DTOs.Messages;
using JWT_P2.DTOs.ParentDetails;
using JWT_P2.DTOs.Parents;
using JWT_P2.DTOs.Schools;
using JWT_P2.DTOs.Students;
using JWT_P2.FormatValidators.Messages;
using JWT_P2.FormatValidators.Parents;
using JWT_P2.FormatValidators.Schools;
using JWT_P2.FormatValidators.Students;
using JWT_P2.MappingProfiles;
using JWT_P2.Models;
using JWT_P2.Repositories;
using JWT_P2.Repositories.MessageRepo;
using JWT_P2.Repositories.ParentDetailsRepo;
using JWT_P2.Repositories.Parents;
using JWT_P2.Repositories.SchoolsRepo;
using JWT_P2.Repositories.Students;
using JWT_P2.SchoolDatabaseContext;
using JWT_P2.Services.Common;
using JWT_P2.Services.MessageServ;
using JWT_P2.Services.ParentDetailsServ;
using JWT_P2.Services.Parents;
using JWT_P2.Services.SchoolServ;
using JWT_P2.Services.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection
builder.Services.AddDbContext<SchoolMessageDatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

// Repositories
builder.Services.AddKeyedScoped<IStudentsRepo<Students>, StudentsRepository>("studentsRepository");
builder.Services.AddKeyedScoped<IParentsRepo, ParentsRepository>("parentsRepository");
builder.Services.AddKeyedScoped<ISchoolsRepository, SchoolsRepository>("schoolsRepository");
builder.Services.AddKeyedScoped<IMessagesRepository, MessagesRepository>("messageRepository");
builder.Services.AddKeyedScoped<IParentDetailsRepository, ParentDetailsRepository>("parentDetailsRepository");

// Services
builder.Services.AddKeyedScoped<ICommonService<StudentsGetDTO, StudentsPostDTO, StudentsPutDTO>, StudentsService>("studentsService");
builder.Services.AddKeyedScoped<ICommonService<ParentsGetDTO, ParentsPostDTO, ParentsPutDTO>, ParentsService>("parentsService");
builder.Services.AddKeyedScoped<ICommonService<SchoolsGetDTO, SchoolsPostDTO, SchoolsPutDTO>, SchoolsService>("schoolsService");
builder.Services.AddKeyedScoped<IMessageService<MessagesGetDTO, MessagesPostDTO, MessagesPutDTO>, MessagesService>("messageService");
builder.Services.AddKeyedScoped<IParentDetailsService<ParentDetailsGetDTO, ParentDetailsPostDTO, ParentDetailsPutDTO>, ParentDetailsService>("parentDetailsService");

// Validators
builder.Services.AddScoped<IValidator<StudentsPostDTO>, StudentsPostFormatValidator>();
builder.Services.AddScoped<IValidator<StudentsPutDTO>, StudentsPutFormatValidator>();

builder.Services.AddScoped<IValidator<ParentsPostDTO>, ParentsPostFormatValidators>();
builder.Services.AddScoped<IValidator<ParentsPutDTO>, ParentsPutFormatValidator>();

builder.Services.AddScoped<IValidator<SchoolsPostDTO>, SchoolsPostFormatValidator>();
builder.Services.AddScoped<IValidator<SchoolsPutDTO>, SchoolsPutFormatValidator>();

builder.Services.AddScoped<IValidator<MessagesPostDTO>, MessagesPostFormatValidator>();
builder.Services.AddScoped<IValidator<MessagesPutDTO>, MessagesPutFormatValidator>();

// Mapping
builder.Services.AddAutoMapper(typeof(StudentsMappingProfile));
builder.Services.AddAutoMapper(typeof(ParentsMappingProfile));
builder.Services.AddAutoMapper(typeof(SchoolsMappingProfile));
builder.Services.AddAutoMapper(typeof(MessagesMappingProfile));
builder.Services.AddAutoMapper(typeof(ParentDetailsMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
