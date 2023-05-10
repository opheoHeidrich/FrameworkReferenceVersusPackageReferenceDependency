git clean -dfx --exclude=".vs/*" --exclude="*/.vs/*"
Start-Transcript "./SampleOutput/PowerShellOutput.txt"
"dotnet version"
dotnet --version
"dotnet msbuild version"
dotnet msbuild --version
"dotnet publish FrameworkReference"
dotnet publish "./BugSample/WebApplication.FrameworkReference/WebApplication.FrameworkReference.csproj" --output "./SampleOutput/FrameworkReference" --verbosity=detailed /fileLogger -fileLoggerParameters:logfile="./SampleOutput/FrameworkReference/Log.log" -binaryLogger:LogFile="./SampleOutput/FrameworkReference/Log.binlog"
"dotnet publish PackageReferenceDependency"
dotnet publish "./BugSample/WebApplication.PackageReferenceDependency/WebApplication.PackageReferenceDependency.csproj" --output "./SampleOutput/PackageReferenceDependency" --verbosity=detailed /fileLogger -fileLoggerParameters:logfile="./SampleOutput/PackageReferenceDependency/Log.log" -binaryLogger:LogFile="./SampleOutput/PackageReferenceDependency/Log.binlog"
Stop-Transcript
