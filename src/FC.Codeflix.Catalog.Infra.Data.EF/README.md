$env:ASPNETCORE_ENVIRONMENT='Migrations'

dotnet ef migrations add CreateCategoryTable -s .\src\FC.Codeflix.Catalog.Api\ -p .\src\FC.Codeflix.Catalog.Infra.Data.EF\

dotnet ef database update -s .\src\FC.Codeflix.Catalog.Api\ -p .\src\FC.Codeflix.Catalog.Infra.Data.EF\ 