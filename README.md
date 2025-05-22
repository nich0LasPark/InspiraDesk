# InspiraDesk Quote Manager
A modern, user-friendly desktop application for managing inspirational quotes with secure multi-user access.

## Overview

InspiraDesk is a lightweight yet powerful Windows application built to store, organize, and manage your favorite inspirational quotes. The application features a clean, intuitive interface with a calming light blue theme, multiple user accounts, and simple quote management.

## Features

### User Authentication System
- Secure login and registration
- Personalized user experience
- Password protection for user accounts

### Quote Management
- Add, edit, and delete inspirational quotes
- Categorize quotes by topic (Motivation, Life, Love, Humor)
- Add author information to your quotes
- View all quotes in an organized data grid

### Permissions System
- Only edit or delete quotes that you've created
- Visual indicators show which quotes belong to you
- Read-only access to quotes from other users

### Modern UI
- Clean, light blue aesthetic
- Responsive and intuitive controls
- Professional dialog messages
- Keyboard shortcuts for improved workflow

## Getting Started

### Installation
1. Extract the InspiraDesk files to your preferred location
2. Double-click InspiraDeskManager.exe to launch the application

### First-time Use
1. Register a new account from the login screen
2. Enter your desired username and password
3. Click "Register" to create your account

### Adding Quotes
1. Enter quote text, author, and select a category
2. Click "Add" to save your quote
3. Your quotes will be highlighted in green for easy identification

### Managing Quotes
1. Click on any quote in the list to select it
2. Edit the details and click "Update" to save changes
3. Use "Delete" to remove unwanted quotes
4. Click "Clear" to reset the input fields

## Technical Details

- Built with .NET Framework 4.7.2
- Uses SQLite for lightweight, portable database storage
- C# 7.3 Windows Forms application
- No external dependencies required

## Database Information

The application uses a local SQLite database (InspiraQuotes.db) which is created in the application directory on first run. It contains two main tables:

- Users: Stores user credentials
- Quotes: Stores quote data with creator information

## Development Team

- **Lorraine Jade D. Barral**
- **Cathleen Mae C. Cuevas**
- **Mikyla Denise J. Dela Rosa**

## License

© 2025 InspiraDesk Team. All rights reserved.

---

*InspiraDesk: Find your daily inspiration.*
