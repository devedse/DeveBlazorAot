@echo off
echo Applying database migrations...
dotnet ef database update --project DeveBlazorAot\DeveBlazorAot
if %errorlevel% neq 0 (
    echo.
    echo Migration failed! Make sure you have created a migration first.
    echo To create a migration, run: dotnet ef migrations add InitialCreate --project DeveBlazorAot\DeveBlazorAot
    pause
    exit /b %errorlevel%
)
echo.
echo Migrations applied successfully!
pause
