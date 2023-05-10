# FrameworkReference versus PackageReference-dependency
This repository shows, that NuGet packages, with dependencies to packages of framework DLLs, will copy them to the output. This is inconsistent with direct references to the framework DLLs.

# How to reproduce the bug:
Run the '**ReproduceBug.ps1**' and compare the outputs for the sample projects.

# Unexpected behavior
In the logs the task 'PackageReferenceDependency' seems to be unable to properly resolve the conflicts between the NuGet- and Framework-References. For example the reference to 'Microsoft.AspNetCore.Http.Connections.Common'. The output for the 'Reference' task ends up with the version 6.0.16 from the framework, but the ReferenceCopyLocalPaths contains Version 6.0.13 from NuGet. At the end of the build the *.deps.json and DLL in the output folder are both 6.0.13 from NuGet.