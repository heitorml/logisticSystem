using Logistic.Delivery.Application;
using Logistic.Delivery.Application.UseCases.Delivery.Create;
using Logistic.Delivery.Dto.Requests.Delivery;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


//app.MapPost("/create",
//    ([FromServices] IDeliveryCreateUseCase useCase,
//     [FromBody] DeliveryRequest request) =>
//{
//    try
//    {
//        useCase.Execute(request);
//        Results.Created();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.ToString());
//        Results.Problem(ex.ToString());
//    }
//})
//.WithName("create")
//.WithOpenApi();


//app.MapPost("/cancel",
//    ([FromServices] IDeliveryCanceledUseCase useCase,
//     [FromBody] DeliveryRequest request) =>
//    {
//        try
//        {
//            useCase.Execute(request);
//            Results.Created();
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.ToString());
//            Results.Problem(ex.ToString());
//        }
//    })
//.WithName("cancel")
//.WithOpenApi();

//app.MapPut("/update",
//    ([FromServices] ISetDeliveryStatusUseCase useCase,
//     [FromBody] DeliveryRequest request) =>
//    {
//        try
//        {
//            useCase.Execute(request);
//            Results.Created();
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.ToString());
//            Results.Problem(ex.ToString());
//        }
//    })
//.WithName("update")
//.WithOpenApi();

app.Run();
