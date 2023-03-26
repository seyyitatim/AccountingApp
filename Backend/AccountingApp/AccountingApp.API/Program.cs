﻿using AccountingApp.API.Configurations;
using AccountingApp.Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);

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

using (var scoped = app.Services.CreateScope())
{
    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    if (!userManager.Users.Any())
    {
        userManager.CreateAsync(new AppUser
        {
            UserName = "seyyit",
            Email = "seyyit@gmail.com",
            Id = Guid.NewGuid().ToString(),
            FullName = "Seyyit Atım",
            FirstName = "Seyyit",
            LastName = "Atım"
        }, "Seyyit52*").Wait();
    }
}

app.Run();
