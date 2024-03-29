using CSProjeDemo1.Abstract;
using CSProjeDemo1.Concrete;
using CSProjeDemo1.EntityFramework;
using CSProjeDemo1.Entitys;
using CSProjeDemo1.Services.Abstract;
using CSProjeDemo1.Services.Concrete;
using Microsoft.AspNetCore.Identity;
using ProjeDemo1.EntityLayer.Entitys;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<Member, AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddScoped<IBookHistoryService, BookHistoryService>();
builder.Services.AddScoped<IBookHistoryDal, EfBookHistoryDal>();

builder.Services.AddScoped<IBookNovelService, BookNovelService>();
builder.Services.AddScoped<IBookNovelDal, EfBookNovelDal>();

builder.Services.AddScoped<IBookScienceService, BookScienceService>();
builder.Services.AddScoped<IBookScienceDal, EfBookScienceDal>();

builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddScoped<ILibraryDal, EfLibraryDal>();

builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IMemberDal, EfMemberDal>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("LibraryApiCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
