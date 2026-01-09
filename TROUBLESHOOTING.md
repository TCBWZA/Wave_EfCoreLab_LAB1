# Troubleshooting Guide

## Common Issues and Solutions

### 1. FileNotFoundException When Running EF Migrations

**Error:**
```
Unhandled exception. System.IO.FileNotFoundException: Could not load file or assembly 'System.Runtime, Version=10.0.0.0'
```

**Cause:** 
Version mismatch between EF Core tools (dotnet-ef) and EF Core packages in your project.

**Solution:**
Ensure the `dotnet-ef` tools version matches your project's EF Core package version.

This project uses **EF Core 8.0.0**, so you need **dotnet-ef 8.0.0**:

```powershell
# Check current version
dotnet ef --version

# If it shows version 10.x or any version other than 8.0.0:
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --version 8.0.0

# Verify installation
dotnet ef --version
# Should show: Entity Framework Core .NET Command-line Tools 8.0.0
```

After fixing the version, retry your migration:
```powershell
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

### 1a. Installing EF Core Tools Locally (Corporate Profile Restrictions)

**Issue:** Cannot install global tools due to corporate profile or permissions restrictions.

**Error:**
```
Access to the path 'C:\Program Files\dotnet\tools' is denied.
```
OR
```
Tool 'dotnet-ef' failed to install. This failure may have been caused by:
* You are attempting to install a preview release and did not use the --version option to specify the version.
* A package by this name was found, but it was not a .NET tool.
* The required NuGet feed cannot be accessed, perhaps because of an Internet connection problem.
* You mistyped the name of the tool.
```
**Solution - Install EF Core Tools Locally:**
Instead of installing globally (which requires admin rights), install the tools locally to your project or user profile:

**Option 1: Local Tool Manifest (Recommended for Teams)**

This approach keeps the tool version tracked in source control, ensuring everyone uses the same version.

```powershell
# Navigate to your project directory
cd D:\Users\tbw_\source\repos\EFCoreLabs_LAB1

# Create a local tool manifest if it doesn't exist
dotnet new tool-manifest

# Install EF Core tools locally to the project
dotnet tool install --local dotnet-ef --version 8.0.0

# Verify installation
dotnet tool list

# Run EF Core commands using 'dotnet' prefix
dotnet dotnet-ef --version
dotenv
