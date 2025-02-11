
---

# URL Shortener Service 🚀

A **URL Shortener** tool that converts long URLs into more manageable, shorter versions. This service is built using **.NET Core** for the backend and a **Vue/React** frontend for interaction.

## Features ✨
- **Generate Short URLs**: Create unique codes for given URLs.
- **Redirection**: Redirect users from the short URL to the original long URL.
- **Validation**: Validate input URLs and handle errors gracefully.
- **Database Storage**: Store shortened URLs and their metadata securely in a database.
- **RESTful API**: Expose endpoints for creating and retrieving shortened URLs.
- **Web Interface**: User-friendly frontend for interacting with the service.
- **Unit & Integration Testing**: Ensuring code reliability.
- **Caching with Redis**: Improve read performance by storing frequently accessed URLs.
- **Microservices Architecture**: Separate user service and URL shortening service.
- **RabbitMQ for Messaging**: Enable communication between microservices.
- **Docker Support**: Containerized deployment with a `Dockerfile` and `.dockerignore`.

---

## Table of Contents 📚
1. [Project Structure](#project-structure)
2. [Technologies Used](#technologies-used)
3. [Getting Started](#getting-started)
4. [API Endpoints](#api-endpoints)
5. [Frontend Functionality](#frontend-functionality)
6. [Microservices Architecture](#microservices-architecture)
7. [Caching Mechanism](#caching-mechanism)
8. [Message Queue with RabbitMQ](#message-queue-with-rabbitmq)
9. [Docker Deployment](#docker-deployment)
10. [Contributing](#contributing)
11. [License](#license)

---

## Project Structure 🏗️

```
.
├── Backend/                     # .NET Core backend
│   ├── Controllers/             # API endpoints
│   ├── Models/                  # Data models
│   ├── Services/                # Core logic for URL shortening
│   ├── Repositories/            # Database interactions
│   ├── Caching/                 # Redis caching logic
│   ├── Messaging/               # RabbitMQ integration
│   ├── Startup.cs               # App configuration
│   └── Program.cs               # Entry point
├── Frontend/                    # Web interface (Vue/React)
│   ├── public/                  # Static files
│   ├── src/                     # Frontend code
│   ├── App.js                   # Main frontend logic
│   └── index.html               # Entry point
├── Database/                    # Database initialization scripts
├── Tests/                       # Unit & integration tests
├── Dockerfile                   # Docker container setup
├── .dockerignore                 # Ignoring unnecessary files for Docker builds
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
- **Redis**: Caching frequently accessed URLs.
- **RabbitMQ**: Message broker for microservices communication.

### Frontend
- **Vue.js / React**: For building a user-friendly interface.
- **CSS/Bootstrap**: For responsive design.

### Additional Tools
- **Docker**: For containerized deployment.
- **Postman**: For API testing.
- **xUnit**: For Unit & Integration testing.

---

## Getting Started ⚡

### Prerequisites
- .NET Core SDK
- Node.js (for frontend)
- Redis (for caching)
- RabbitMQ (for messaging)
- Docker (for containerization)

### Steps
1. **Clone the repository**:
    ```bash
    git clone https://github.com/Quillboltcode/url-shortener.git
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

4. **Start Redis & RabbitMQ** (if not using Docker):
    ```bash
    redis-server &
    rabbitmq-server &
    ```

5. **Database Setup**:
   Ensure the database is initialized using the provided scripts in the `Database/` folder.

---

## Frontend Functionality 🎨

The frontend provides an intuitive interface for users to interact with the URL shortener service. Key functionalities include:

URL Input Field: Users can enter a long URL to be shortened.

Shortened URL Display: Generated short URLs are displayed with a copy button for convenience.

Redirection Handling: Clicking the shortened URL redirects the user to the original URL.

History & Statistics (Optional): Users can view previously shortened URLs and their metadata.

Responsive Design: Ensures usability across different devices.

---

## Microservices Architecture 🏗️

The application is designed with a microservices architecture, separating the User Service and the URL Shortening Service. Key aspects include:

Independent Services: The User Service manages authentication and user-related operations, while the URL Shortening Service handles URL generation and redirection.

Communication via RabbitMQ: Services communicate asynchronously using RabbitMQ as a message broker.

Scalability: Enables independent scaling of services based on demand.

Fault Isolation: Failures in one service do not affect the entire system.

Caching Mechanism ⚡

To enhance performance and reduce database load, caching is implemented using Redis. The caching strategy includes:

Frequent Access Storage: Popular URLs are cached to minimize database queries.

TTL (Time-to-Live): Cached entries expire after a set duration to ensure up-to-date data.

Cache Invalidation: Updates in the database trigger cache updates to prevent stale data.

Improved Read Performance: Significantly reduces response time for frequently accessed URLs.

---

## Message Queue with RabbitMQ 📩

RabbitMQ is used for asynchronous communication between microservices. This enables:

Decoupled Services: The URL Shortening Service and User Service operate independently.

Event-Driven Processing: Events such as URL creation or user sign-up trigger messages that other services can process.

Scalability & Reliability: Message queues help balance load and prevent request overloads.

Guaranteed Delivery: Messages persist until processed, ensuring no data loss.

## Docker Deployment 🐳

1. **Build the Docker Image**:
   ```bash
   docker build -t url-shortener .
   ```

2. **Run the Docker Container**:
   ```bash
   docker run -p 5000:5000 url-shortener
   ```

3. **Docker Compose (For Multi-Container Setup)**:
   If using Redis and RabbitMQ, a `docker-compose.yml` file can be created to manage services.

   ```bash
   docker-compose up -d
   ```

---

## License 📜

This project is licensed under the [MIT License](LICENSE).

---

Feel free to customize the README to fit your specific implementation details!

