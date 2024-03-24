using CSProjeDemo1.Abstract;
using CSProjeDemo1.Concrete;
using CSProjeDemo1.EntityFramework;
using CSProjeDemo1.Services.Abstract;
using CSProjeDemo1.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();


builder.Services.AddScoped<IBookHistoryService, BookHistoryService>();
builder.Services.AddScoped<IBookHistoryDal, EfBookHistoryDal>();

builder.Services.AddScoped<IBookNovelService, BookNovelService>();
builder.Services.AddScoped<IBookNovelDal, EfBookNovelDal>();

builder.Services.AddScoped<IBookScienceService, BookScienceService>();
builder.Services.AddScoped<IBookScienceDal, EfBookScienceDal>();

builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IMemberDal, EfMemberDal>();

builder.Services.AddAutoMapper(typeof(Program));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
