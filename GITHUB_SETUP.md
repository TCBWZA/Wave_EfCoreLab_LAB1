# GitHub Repository Setup Guide

This guide will help you push this project to GitHub as a public repository under the TCBWZA account.

## Prerequisites

- Git installed on your system
- GitHub account (TCBWZA)
- Project directory: `D:\Users\tbw_\source\repos\EFCoreLabs_LAB1\`

## Step-by-Step Setup

### Step 1: Create Repository on GitHub

1. Go to [GitHub](https://github.com/TCBWZA)
2. Click the **"+"** icon in the top right, select **"New repository"**
3. Fill in the details:
   - **Repository name**: `Wave_EfCoreLab_LAB1`
   - **Description**: `Entity Framework Core 8.0 learning lab with comprehensive examples and patterns`
   - **Visibility**: Select **Public**
   - **Do NOT initialize** with README, .gitignore, or license (we already have these)
4. Click **"Create repository"**

### Step 2: Initialize Git (If Not Already Done)

Open PowerShell in your project directory:

```powershell
cd D:\Users\tbw_\source\repos\EFCoreLabs_LAB1
```

Check if Git is already initialized:

```powershell
git status
```

If you see `fatal: not a git repository`, initialize Git:

```powershell
git init
```

### Step 3: Configure Git (If Not Already Done)

Set your Git username and email:

```powershell
git config user.name "TCBWZA"
git config user.email "your-email@example.com"
```

Or set globally:

```powershell
git config --global user.name "TCBWZA"
git config --global user.email "your-email@example.com"
```

### Step 4: Add All Files

Add all project files to Git:

```powershell
git add .
```

Verify what will be committed:

```powershell
git status
```

### Step 5: Create Initial Commit

```powershell
git commit -m "Initial commit: EF Core Lab with comprehensive learning examples"
```

### Step 6: Rename Default Branch (Optional but Recommended)

GitHub uses `main` as the default branch name:

```powershell
git branch -M main
```

### Step 7: Add Remote Repository

Replace `TCBWZA` with your actual GitHub username if different:

```powershell
git remote add origin https://github.com/TCBWZA/Wave_EfCoreLab_LAB1.git
```

Verify the remote was added:

```powershell
git remote -v
```

### Step 8: Push to GitHub

Push your code to GitHub:

```powershell
git push -u origin main
```

You may be prompted to authenticate:
- **Username**: Your GitHub username
- **Password**: Your GitHub Personal Access Token (not your account password)

### Step 9: Verify on GitHub

Visit: `https://github.com/TCBWZA/Wave_EfCoreLab_LAB1`

Your repository should now be live!

## Quick Copy-Paste Commands

Here's the complete sequence (run from project directory):

```powershell
# Navigate to project
cd D:\Users\tbw_\source\repos\EFCoreLabs_LAB1

# Initialize Git (if needed)
git init

# Configure Git
git config user.name "TCBWZA"
git config user.email "your-email@example.com"

# Add all files
git add .

# Commit
git commit -m "Initial commit: EF Core Lab with comprehensive learning examples"

# Rename branch to main
git branch -M main

# Add remote
git remote add origin https://github.com/TCBWZA/Wave_EfCoreLab_LAB1.git

# Push to GitHub
git push -u origin main
```

## Creating a Personal Access Token (PAT)

If you don't have a Personal Access Token:

1. Go to GitHub Settings: `https://github.com/settings/tokens`
2. Click **"Generate new token"** > **"Generate new token (classic)"**
3. Give it a name: `Wave_EfCoreLab_LAB1`
4. Set expiration as needed
5. Select scopes:
   - ? `repo` (full control of private repositories)
6. Click **"Generate token"**
7. **COPY THE TOKEN IMMEDIATELY** (you won't see it again)
8. Use this token as your password when pushing to GitHub

## Alternative: Using GitHub CLI

If you prefer using GitHub CLI:

```powershell
# Install GitHub CLI (if not installed)
winget install --id GitHub.cli

# Login to GitHub
gh auth login

# Create repository
gh repo create Wave_EfCoreLab_LAB1 --public --source=. --remote=origin

# Push code
git push -u origin main
```

## Repository Settings (After Creation)

### Add Topics

1. Go to your repository page
2. Click the gear icon next to "About"
3. Add topics:
   - `efcore`
   - `entity-framework`
   - `dotnet`
   - `csharp`
   - `aspnet-core`
   - `web-api`
   - `learning`
   - `tutorial`
   - `repository-pattern`
   - `code-first`

### Configure Repository Options

1. Go to **Settings** > **General**
2. Features:
   - ? Issues
   - ? Projects (if you want to track progress)
   - ? Discussions (for Q&A)
   - ? Wikis (optional)
3. **Pull Requests**:
   - ? Allow merge commits
   - ? Allow squash merging
   - ? Allow rebase merging

## Subsequent Updates

After the initial push, to update the repository:

```powershell
# Check status
git status

# Add changes
git add .

# Commit with message
git commit -m "Description of changes"

# Push to GitHub
git push
```

## Troubleshooting

### Authentication Failed

If you get authentication errors:

```powershell
# Use credential helper
git config --global credential.helper wincred
```

Or use SSH instead of HTTPS:

```powershell
# Generate SSH key (if you don't have one)
ssh-keygen -t ed25519 -C "your-email@example.com"

# Add SSH key to GitHub
# Copy the public key
Get-Content ~\.ssh\id_ed25519.pub | clip

# Add at: https://github.com/settings/keys

# Change remote to SSH
git remote set-url origin git@github.com:TCBWZA/Wave_EfCoreLab_LAB1.git
```

### Large File Warning

If you get warnings about large files:

```powershell
# Add to .gitignore
echo "bin/" >> .gitignore
echo "obj/" >> .gitignore

# Remove from tracking
git rm -r --cached bin/
git rm -r --cached obj/

# Commit
git add .gitignore
git commit -m "Update .gitignore"
git push
```

### Forgot to Add .gitignore

If you already committed files that should be ignored:

```powershell
# Remove from tracking but keep locally
git rm -r --cached bin/ obj/

# Commit the removal
git commit -m "Remove build artifacts from tracking"

# Push
git push
```

## Next Steps

After publishing:

1. **Add Description**: Edit the repository description on GitHub
2. **Add Topics**: Tag your repository for discoverability
3. **Enable Discussions**: For community Q&A
4. **Create Issues**: Add "good first issue" labels for contributors
5. **Add to Profile**: Pin this repository to your GitHub profile
6. **Share**: Share the repository link with learners

## Repository URLs

- **HTTPS Clone**: `https://github.com/TCBWZA/Wave_EfCoreLab_LAB1.git`
- **SSH Clone**: `git@github.com:TCBWZA/Wave_EfCoreLab_LAB1.git`
- **Web URL**: `https://github.com/TCBWZA/Wave_EfCoreLab_LAB1`

---

**Success!** Your repository is now public and ready for the community!
