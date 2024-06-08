// tutorial: https://dev.to/ayush_k_mandal/api-versioning-in-minimal-api-1omi
// vai dar erro na url, então colar este link: http://localhost:5200/?api-version=2
using Asp.Versioning.Conventions;
using demo01.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersionService();

var app = builder.Build();

var apiVersionSet = app.NewApiVersionSet()
.HasApiVersion(2.0)
.HasDeprecatedApiVersion(1.0)
.ReportApiVersions()
.Build();

app.MapGet("/", () => "Hello World!")
.WithApiVersionSet(apiVersionSet)
.MapToApiVersion(2.0);

app.MapGet("/ayush", () => "Hello Ayush.")
.WithApiVersionSet(apiVersionSet)
.MapToApiVersion(1.0);

app.Run();
