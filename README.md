<div align="center">

# 🌟 InspiraDesk Quote Manager

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4)](https://dotnet.microsoft.com/)
[![Windows](https://img.shields.io/badge/Platform-Windows-0078D6?logo=windows)](https://www.microsoft.com/windows)
[![SQLite](https://img.shields.io/badge/Database-SQLite-003B57?logo=sqlite)](https://www.sqlite.org/)

> *Find your daily inspiration with InspiraDesk - Your Personal Quote Management System*

[Features](#-features) • [Installation](#-installation) • [Usage](#-usage) • [Technical Details](#-technical-details) • [Team](#-team)

</div>
## 📋 Overview

InspiraDesk is a powerful Windows desktop application designed to help you collect, organize, and manage your favorite inspirational quotes. With its intuitive interface and secure multi-user system, keeping track of your personal collection of wisdom has never been easier.

## ✨ Features

<details>
<summary><b>🔐 User Authentication System</b></summary>

- Secure login and registration
- Personalized user experience
- Password protection for user accounts
</details>

<details>
<summary><b>📝 Quote Management</b></summary>

- Add, edit, and delete inspirational quotes
- Categorize quotes by topic:
  - 💪 Motivation
  - 🌱 Life
  - ❤️ Love
  - 😊 Humor
- Add author information to your quotes
- View all quotes in an organized data grid
</details>

<details>
<summary><b>🔒 Permissions System</b></summary>

- Only edit or delete quotes that you've created
- Visual indicators show which quotes belong to you
- Read-only access to quotes from other users
</details>

<details>
<summary><b>🎨 Modern UI</b></summary>

- Clean, light blue aesthetic
- Responsive and intuitive controls
- Professional dialog messages
- Keyboard shortcuts for improved workflow
</details>

## 🚀 Installation

1. Download the latest release from our [releases page](#)
2. Extract the InspiraDesk files to your preferred location
3. Double-click `InspiraDeskManager.exe` to launch the application

## 📖 Usage

1. Launch InspiraDeskManager.exe
2. Click "Register" on the login screen
3. Create your account:
   - Choose a username
   - Set a secure password
4. Login with your new credentials

### Managing Quotes

| Action | Description | Shortcut |
|--------|-------------|----------|
| Add Quote | Enter quote details and click "Add" | Ctrl+N |
| Edit Quote | Select quote and modify details | Ctrl+E |
| Delete Quote | Select quote and click "Delete" | Del |
| Reset Fields | Click "Clear" to reset input fields | Ctrl+R |

## 🛠️ Technical Details

### System Requirements

- **OS:** Windows 7 or later
- **Runtime:** .NET Framework 4.7.2
- **Memory:** 2GB RAM minimum
- **Storage:** 100MB free space

### Database Schema

#### Users Table
```sql
CREATE TABLE Users (
    UserID INTEGER PRIMARY KEY,
    Username TEXT UNIQUE,
    PasswordHash TEXT
);
```

#### Quotes Table
```sql
CREATE TABLE Quotes (
    QuoteID INTEGER PRIMARY KEY,
    Text TEXT,
    Author TEXT,
    Category TEXT,
    CreatorID INTEGER,
    FOREIGN KEY (CreatorID) REFERENCES Users(UserID)
);
```

## 👥 Team

<div align="center">

| Member |
|--------|
| **Lorraine Jade D. Barral** |
| **Cathleen Mae C. Cuevas** |
| **Mikyla Denise J. Dela Rosa** |

</div>

## 📄 License

© 2025 InspiraDesk Team. Power Puffs. All rights reserved.

---

<div align="center">
</div>
