<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>InspiraDesk Quote Manager</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            line-height: 1.6;
            color: #333;
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
        }
        h1 {
            color: #2c5aa0;
        }
        h2 {
            color: #4682B4;
            margin-top: 30px;
        }
        ul {
            padding-left: 20px;
        }
        li {
            margin-bottom: 5px;
        }
        strong {
            color: #2c5aa0;
        }
        code {
            background: #f4f4f4;
            padding: 2px 5px;
            border-radius: 3px;
        }
        .team-member {
            font-style: italic;
        }
        .footer {
            margin-top: 40px;
            padding-top: 10px;
            border-top: 1px solid #eee;
            font-style: italic;
            text-align: center;
        }
    </style>
</head>
<body>
    <h1>InspiraDesk Quote Manager</h1>
    
    <p>A modern, user-friendly desktop application for managing inspirational quotes with secure multi-user access.</p>
    
    <h2>Overview</h2>
    <p>InspiraDesk is a lightweight yet powerful Windows application built to store, organize, and manage your favorite inspirational quotes. The application features a clean, intuitive interface with a calming light blue theme, multiple user accounts, and simple quote management.</p>
    
    <h2>Features</h2>
    <ul>
        <li><strong>User Authentication System</strong>
            <ul>
                <li>Secure login and registration</li>
                <li>Personalized user experience</li>
                <li>Password protection for user accounts</li>
            </ul>
        </li>
        <li><strong>Quote Management</strong>
            <ul>
                <li>Add, edit, and delete inspirational quotes</li>
                <li>Categorize quotes by topic (Motivation, Life, Love, Humor)</li>
                <li>Add author information to your quotes</li>
                <li>View all quotes in an organized data grid</li>
            </ul>
        </li>
        <li><strong>Permissions System</strong>
            <ul>
                <li>Only edit or delete quotes that you've created</li>
                <li>Visual indicators show which quotes belong to you</li>
                <li>Read-only access to quotes from other users</li>
            </ul>
        </li>
        <li><strong>Modern UI</strong>
            <ul>
                <li>Clean, light blue aesthetic</li>
                <li>Responsive and intuitive controls</li>
                <li>Professional dialog messages</li>
                <li>Keyboard shortcuts for improved workflow</li>
            </ul>
        </li>
    </ul>
    
    <h2>Getting Started</h2>
    <ol>
        <li><strong>Installation</strong>
            <ul>
                <li>Extract the InspiraDesk files to your preferred location</li>
                <li>Double-click InspiraDeskManager.exe to launch the application</li>
            </ul>
        </li>
        <li><strong>First-time Use</strong>
            <ul>
                <li>Register a new account from the login screen</li>
                <li>Enter your desired username and password</li>
                <li>Click "Register" to create your account</li>
            </ul>
        </li>
        <li><strong>Adding Quotes</strong>
            <ul>
                <li>Enter quote text, author, and select a category</li>
                <li>Click "Add" to save your quote</li>
                <li>Your quotes will be highlighted in green for easy identification</li>
            </ul>
        </li>
        <li><strong>Managing Quotes</strong>
            <ul>
                <li>Click on any quote in the list to select it</li>
                <li>Edit the details and click "Update" to save changes</li>
                <li>Use "Delete" to remove unwanted quotes</li>
                <li>Click "Clear" to reset the input fields</li>
            </ul>
        </li>
    </ol>
    
    <h2>Technical Details</h2>
    <ul>
        <li>Built with .NET Framework 4.7.2</li>
        <li>Uses SQLite for lightweight, portable database storage</li>
        <li>C# 7.3 Windows Forms application</li>
        <li>No external dependencies required</li>
    </ul>
    
    <h2>Database Information</h2>
    <p>The application uses a local SQLite database (InspiraQuotes.db) which is created in the application directory on first run. It contains two main tables:</p>
    <ul>
        <li>Users: Stores user credentials</li>
        <li>Quotes: Stores quote data with creator information</li>
    </ul>
    
    <h2>Development Team</h2>
    <ul>
        <li class="team-member"><strong>Lorraine Jade D. Barral</strong></li>
        <li class="team-member"><strong>Cathleen Mae C. Cuevas</strong></li>
        <li class="team-member"><strong>Mikyla Denise J. Dela Rosa</strong></li>
    </ul>
    
    <h2>License</h2>
    <p>© 2025 InspiraDesk Team. All rights reserved.</p>
    
    <div class="footer">
        <p>InspiraDesk: Find your daily inspiration.</p>
    </div>
</body>
</html>
