@echo off

set TestsDir=tests
set TestProjects=Laraue.EfCoreTriggers.PostgreSqlTests, Laraue.EfCoreTriggers.SqlLiteTests, Laraue.EfCoreTriggers.SqlServerTests

echo Step 1: Preparing databases
call :UpdateDatabases
echo Step 2: Tests executing
call :RunTests
exit /b %errorlevel%

:UpdateDatabases
for /d %%i in (%TestProjects%) do (
	echo Dropping old migrations folder %TestsDir%/%%i/Migrations
	if exist "%TestsDir%/%%i/Migrations" rmdir "%TestsDir%/%%i/Migrations" /s /q
	dotnet ef database drop --project="%TestsDir%/%%i" -f
	dotnet ef migrations add Initial --project="%TestsDir%/%%i"
	dotnet ef database update --project="%TestsDir%/%%i"
)
exit /b %errorlevel%

:RunTests
for /d %%i in (%TestProjects%) do (
	dotnet test "%TestsDir%/%%i/%%i.csproj" --no-build
)
exit /b %errorlevel%