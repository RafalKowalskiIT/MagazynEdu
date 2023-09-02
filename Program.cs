using FluentValidation.AspNetCore;
using MagazynEdu.DataAccess;
using MagazynEdu.DataAccess.CQRS;
using MagazynEduApplicationServices.API.Domain;
using MagazynEduApplicationServices.API.Validators;
using MagazynEduApplicationServices.Mappings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<WarehouseStorageContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("WarehouseDataBaseConnection")));
builder.Services.AddMediatR(typeof(ResponseBase<>));
builder.Services.AddAutoMapper(typeof(BooksProfile).Assembly);
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddMvcCore()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddBookCaseRequestValidator>());
builder.Services.Configure<ApiBehaviorOptions>(option =>
{
    option.SuppressModelStateInvalidFilter = true;
});

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
