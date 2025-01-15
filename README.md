---

# URL Shortener Service 🚀

A **URL Shortener** tool that converts long URLs into more manageable, shorter versions. This service is built using **.NET Core** for the backend and a simple **frontend web application** to demonstrate its functionality.

## Features ✨
- **Generate Short URLs**: Create unique codes for given URLs.
- **Redirection**: Redirect users from the short URL to the original long URL.
- **Validation**: Validate input URLs and handle errors gracefully.
- **Database Storage**: Store shortened URLs and their metadata securely in a database.
- **RESTful API**: Expose endpoints for creating and retrieving shortened URLs.
- **Web Interface**: User-friendly frontend for interacting with the service.

---

## Table of Contents 📚
1. [Project Structure](#project-structure)
2. [Technologies Used](#technologies-used)
3. [Getting Started](#getting-started)
4. [API Endpoints](#api-endpoints)
5. [Frontend Functionality](#frontend-functionality)
6. [Contributing](#contributing)
7. [License](#license)

---

## Project Structure 🏗️

```
.
├── Backend/                     # .NET Core backend
│   ├── Controllers/             # API endpoints
│   ├── Models/                  # Data models
│   ├── Services/                # Core logic for URL shortening
│   ├── Repositories/            # Database interactions
│   ├── Startup.cs               # App configuration
│   └── Program.cs               # Entry point
├── Frontend/                    # Web interface
│   ├── public/                  # Static files
│   ├── src/                     # React or any frontend framework code
│   ├── App.js                   # Main frontend logic
│   └── index.html               # Entry point
├── Database/                    # Database initialization scripts
├── README.md                    # Project documentation
└── .gitignore                   # Git ignore rules
```

---

## Technologies Used 🛠️

### Backend
- **.NET Core**: High-performance backend framework.
- **Entity Framework Core**: ORM for database operations.
- **SQLite / PostgreSQL**: Database for storing URLs and metadata.
- **ASP.NET Core MVC**: For building RESTful APIs.

### Frontend
- **React** (or any chosen framework): For building a user-friendly interface.
- **CSS/Bootstrap**: For responsive design.

### Additional Tools
- **Docker**: For containerized deployment.
- **Postman**: For API testing.

---

## Getting Started ⚡

### Prerequisites
- .NET Core SDK
- Node.js (for frontend)
- Docker (optional for deployment)

### Steps
1. **Clone the repository**:
    ```bash
    git clone https://github.com/yourusername/url-shortener.git
    cd url-shortener
    ```

2. **Setup the Backend**:
    ```bash
    cd Backend
    dotnet restore
    dotnet run
    ```
    The backend server will start at `http://localhost:5000`.

3. **Setup the Frontend**:
    ```bash
    cd Frontend
    npm install
    npm start
    ```
    The frontend will start at `http://localhost:3000`.

4. **Database Setup**:
   Ensure the database is initialized using the provided scripts in the `Database/` folder.

---

## API Endpoints 🧩

### 1. **Create a Shortened URL**
   **POST** `/api/shorten`
   - **Request Body**:
     ```json
     {
       "url": "https://example.com"
     }
     ```
   - **Response**:
     ```json
     {
       "shortUrl": "http://short.ly/abc123"
     }
     ```

### 2. **Redirect to Original URL**
   **GET** `/{shortCode}`
   - Redirects to the original URL.

### 3. **Get URL Metadata**
   **GET** `/api/shorten/{shortCode}`
   - **Response**:
     ```json
     {
       "originalUrl": "https://example.com",
       "shortUrl": "http://short.ly/abc123",
       "createdAt": "2025-01-12T10:00:00Z"
     }
     ```

---

## Frontend Functionality 🎨

1. **Input Field**: Users can input a long URL to shorten.
2. **Shortened URL Display**: Display the generated short URL with a copy button.
3. **History**: Show a list of previously shortened URLs with metadata (optional).


---

## License 📜

This project is licensed under the [MIT License](LICENSE).

---

Feel free to customize the README to fit your specific implementation details!
