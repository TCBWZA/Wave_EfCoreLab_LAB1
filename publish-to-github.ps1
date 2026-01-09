# Quick Publish Script for Wave_EfCoreLab_LAB1
# This script will help you publish your project to GitHub

# Color functions for output
function Write-Success { Write-Host $args -ForegroundColor Green }
function Write-Info { Write-Host $args -ForegroundColor Cyan }
function Write-Warning { Write-Host $args -ForegroundColor Yellow }
function Write-Error { Write-Host $args -ForegroundColor Red }

Write-Info "=================================================="
Write-Info "  Wave EF Core Lab - GitHub Publication Script"
Write-Info "=================================================="
Write-Host ""

# Check if we're in the right directory
if (-not (Test-Path "EfCoreLab_LAB1.csproj")) {
    Write-Error "Error: Not in the project root directory!"
    Write-Warning "Please navigate to: D:\Users\tbw_\source\repos\EFCoreLabs_LAB1\"
    exit 1
}

Write-Success "? In correct directory"

# Check if Git is installed
try {
    $gitVersion = git --version
    Write-Success "? Git is installed: $gitVersion"
} catch {
    Write-Error "? Git is not installed!"
    Write-Warning "Please install Git from: https://git-scm.com/"
    exit 1
}

# Check if already a git repository
if (Test-Path ".git") {
    Write-Info "? Already a Git repository"
    $reinit = Read-Host "Do you want to reinitialize? (yes/no)"
    if ($reinit -eq "yes") {
        Remove-Item -Recurse -Force .git
        Write-Warning "Removed existing .git directory"
    }
}

# Initialize Git if needed
if (-not (Test-Path ".git")) {
    Write-Info "Initializing Git repository..."
    git init
    git branch -M main
    Write-Success "? Git repository initialized"
}

# Configure Git user (if not configured)
$userName = git config user.name
$userEmail = git config user.email

if (-not $userName) {
    Write-Info ""
    $userName = Read-Host "Enter your GitHub username"
    git config user.name $userName
    Write-Success "? Git username configured: $userName"
}

if (-not $userEmail) {
    $userEmail = Read-Host "Enter your email address"
    git config user.email $userEmail
    Write-Success "? Git email configured: $userEmail"
}

Write-Info ""
Write-Info "Git Configuration:"
Write-Host "  Username: $userName" -ForegroundColor White
Write-Host "  Email: $userEmail" -ForegroundColor White

# Check for sensitive data
Write-Info ""
Write-Info "Checking for sensitive data..."

$sensitivePatterns = @(
    @{Pattern="Password=(?!MySecurePassword|YOUR_PASSWORD)"; File="appsettings*.json"; Warning="Real password detected"}
    @{Pattern="ConnectionString.*sa.*Password=(?!MySecurePassword)"; File="*.json"; Warning="SQL password detected"}
)

$sensitiveFound = $false
foreach ($check in $sensitivePatterns) {
    $files = Get-ChildItem -Filter $check.File -Recurse | Where-Object { $_.FullName -notlike "*\bin\*" -and $_.FullName -notlike "*\obj\*" }
    foreach ($file in $files) {
        $content = Get-Content $file.FullName -Raw
        if ($content -match $check.Pattern) {
            Write-Warning "? $($check.Warning) in $($file.Name)"
            $sensitiveFound = $true
        }
    }
}

if ($sensitiveFound) {
    Write-Error ""
    Write-Error "Please remove sensitive data before publishing!"
    $continue = Read-Host "Continue anyway? (yes/no)"
    if ($continue -ne "yes") {
        exit 1
    }
}

Write-Success "? No sensitive data detected (or you chose to continue)"

# Stage files
Write-Info ""
Write-Info "Staging files for commit..."
git add .

# Show what will be committed
Write-Info ""
Write-Info "Files to be committed:"
git status --short

Write-Info ""
$proceed = Read-Host "Proceed with commit? (yes/no)"

if ($proceed -ne "yes") {
    Write-Warning "Aborted by user"
    exit 0
}

# Create initial commit
Write-Info ""
Write-Info "Creating initial commit..."

$commitMessage = @"
Initial commit: Wave EF Core Lab - Comprehensive learning project

- Entity Framework Core 8.0 learning lab
- Code First approach with migrations
- Repository pattern implementation
- 10+ practical EF Core examples
- Comprehensive documentation and guides
- Corporate environment support
- Interactive Swagger UI
"@

git commit -m $commitMessage

Write-Success "? Initial commit created"

# Check for remote
$remoteUrl = git remote get-url origin 2>$null

if ($remoteUrl) {
    Write-Info ""
    Write-Info "Remote repository already configured:"
    Write-Host "  $remoteUrl" -ForegroundColor White
} else {
    Write-Info ""
    Write-Warning "No remote repository configured"
    Write-Info ""
    Write-Info "Next steps:"
    Write-Info "1. Create repository on GitHub:"
    Write-Info "   https://github.com/TCBWZA?tab=repositories"
    Write-Info "2. Repository name: Wave_EfCoreLab_LAB1"
    Write-Info "3. Make it Public"
    Write-Info "4. Do NOT initialize with README, .gitignore, or license"
    Write-Info ""
    
    $createRemote = Read-Host "Have you created the GitHub repository? (yes/no)"
    
    if ($createRemote -eq "yes") {
        $repoUrl = Read-Host "Enter the repository URL (default: https://github.com/TCBWZA/Wave_EfCoreLab_LAB1.git)"
        
        if ([string]::IsNullOrWhiteSpace($repoUrl)) {
            $repoUrl = "https://github.com/TCBWZA/Wave_EfCoreLab_LAB1.git"
        }
        
        Write-Info "Adding remote repository..."
        git remote add origin $repoUrl
        Write-Success "? Remote repository added"
        
        Write-Info ""
        Write-Info "Pushing to GitHub..."
        Write-Warning "You may be prompted for authentication"
        
        try {
            git push -u origin main
            Write-Success "? Successfully pushed to GitHub!"
            Write-Success ""
            Write-Success "=================================================="
            Write-Success "  Repository published successfully!"
            Write-Success "=================================================="
            Write-Success ""
            Write-Success "View your repository at:"
            Write-Host "  https://github.com/TCBWZA/Wave_EfCoreLab_LAB1" -ForegroundColor White
            Write-Success ""
            Write-Success "Clone URL (HTTPS):"
            Write-Host "  https://github.com/TCBWZA/Wave_EfCoreLab_LAB1.git" -ForegroundColor White
            Write-Success ""
            Write-Success "Clone URL (SSH):"
            Write-Host "  git@github.com:TCBWZA/Wave_EfCoreLab_LAB1.git" -ForegroundColor White
            
        } catch {
            Write-Error "? Failed to push to GitHub"
            Write-Warning "Error: $_"
            Write-Info ""
            Write-Info "You can manually push later with:"
            Write-Host "  git push -u origin main" -ForegroundColor White
        }
    } else {
        Write-Info ""
        Write-Info "To complete setup later, run:"
        Write-Host "  git remote add origin https://github.com/TCBWZA/Wave_EfCoreLab_LAB1.git" -ForegroundColor White
        Write-Host "  git push -u origin main" -ForegroundColor White
    }
}

Write-Info ""
Write-Info "See PUBLICATION_CHECKLIST.md for post-publication steps"
Write-Info ""

# Summary
Write-Info "=================================================="
Write-Info "  Setup Summary"
Write-Info "=================================================="
Write-Info "? Git repository initialized"
Write-Info "? Git user configured"
Write-Info "? Files staged and committed"

if ($remoteUrl -or $createRemote -eq "yes") {
    Write-Info "? Remote repository configured"
    Write-Info "? Code pushed to GitHub"
} else {
    Write-Warning "? Remote repository not configured yet"
}

Write-Info ""
Write-Success "Done! ??"
