# Quick Start: Publishing to GitHub

This guide will help you quickly publish this project to GitHub.

## Automated Setup (Recommended)

Run the automated PowerShell script:

```powershell
.\publish-to-github.ps1
```

This script will:
- ? Initialize Git repository
- ? Configure Git user
- ? Check for sensitive data
- ? Create initial commit
- ? Add remote repository
- ? Push to GitHub

## Manual Setup (Step-by-Step)

If you prefer manual setup, follow these steps:

### 1. Initialize Git

```powershell
cd D:\Users\tbw_\source\repos\EFCoreLabs_LAB1
git init
git branch -M main
```

### 2. Configure Git

```powershell
git config user.name "TCBWZA"
git config user.email "your-email@example.com"
```

### 3. Create GitHub Repository

1. Go to: https://github.com/TCBWZA
2. Click **"New repository"**
3. Name: `Wave_EfCoreLab_LAB1`
4. Visibility: **Public**
5. **Do NOT** initialize with README
6. Click **"Create repository"**

### 4. Add and Commit Files

```powershell
git add .
git commit -m "Initial commit: Wave EF Core Lab"
```

### 5. Push to GitHub

```powershell
git remote add origin https://github.com/TCBWZA/Wave_EfCoreLab_LAB1.git
git push -u origin main
```

### 6. Verify

Visit: https://github.com/TCBWZA/Wave_EfCoreLab_LAB1

## What's Included

All necessary files are ready:

- ? `.gitignore` - Excludes build artifacts
- ? `LICENSE` - MIT License
- ? `README.md` - Main documentation
- ? `CONTRIBUTING.md` - Contribution guidelines
- ? `GITHUB_SETUP.md` - Detailed setup guide
- ? `PUBLICATION_CHECKLIST.md` - Pre/post-publication tasks
- ? `publish-to-github.ps1` - Automation script

## Security Verified

- ? No real passwords (using placeholders)
- ? Development settings in .gitignore
- ? No sensitive data exposed

## Repository URLs (After Publishing)

**HTTPS Clone:**
```
https://github.com/TCBWZA/Wave_EfCoreLab_LAB1.git
```

**SSH Clone:**
```
git@github.com:TCBWZA/Wave_EfCoreLab_LAB1.git
```

**Web URL:**
```
https://github.com/TCBWZA/Wave_EfCoreLab_LAB1
```

## Need Help?

- See `GITHUB_SETUP.md` for detailed instructions
- See `PUBLICATION_CHECKLIST.md` for verification steps
- See `TROUBLESHOOTING.md` for common issues

---

**Ready? Run the script or follow manual steps above!** ??
