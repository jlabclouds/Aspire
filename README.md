# Aspire ASP.NET Core

Aspire is a full-stack web application framework featuring an ASP.NET Core backend and a Blazor frontend. It is designed to streamline the development of modern, scalable, and maintainable web applications using the .NET ecosystem.

## Features

- **ASP.NET Core Backend**: Delivers robust, high-performance RESTful APIs with built-in support for dependency injection, middleware, and secure authentication/authorization mechanisms.
- **Blazor Frontend**: Enables the creation of rich, interactive client-side web UIs using C#, allowing for code sharing and reuse between client and server.
- **Full-Stack Solution**: Facilitates seamless integration between frontend and backend through shared models, reducing duplication and improving maintainability.
- **Modern Architecture**: Implements best practices such as layered architecture, modular design, and support for cloud-native deployments, ensuring scalability, security, and ease of testing.
- **Extensibility**: Easily integrate third-party libraries, add custom middleware, or extend functionality to suit specific business needs.
- **Developer Productivity**: Leverages .NET tooling, hot reload, and comprehensive debugging support to accelerate development cycles.

## Best Use Cases

- **Enterprise Web Applications**: Ideal for building large-scale, maintainable business applications that require strong type safety, modularity, and long-term support.
- **Unified C# Development**: Perfect for teams that want to use C# across both frontend and backend, streamlining hiring, training, and code sharing.
- **Real-Time Applications**: Suitable for apps needing real-time features such as chat, notifications, or live dashboards, leveraging SignalR and WebSockets.
- **Secure and Compliant Solutions**: Well-suited for applications requiring robust authentication, authorization, and compliance with industry standards.
- **API-Driven Integrations**: Great for projects that need to integrate with external services, REST APIs, or microservices architectures.
- **Rapid Prototyping and Iteration**: Enables fast development and iteration, making it a strong choice for startups and teams looking to quickly validate ideas within the .NET ecosystem.

## Getting Started

### Prerequisites

- [.NET SDK 7.0 or later](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (if using additional frontend tooling)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Running the Application

1. **Clone the repository:**
    ```bash
    git clone https://github.com/your-org/aspire.git
    cd aspire
    ```

2. **Restore dependencies:**
    ```bash
    dotnet restore
    ```

3. **Build the solution:**
    ```bash
    dotnet build
    ```

4. **Run the application:**
    ```bash
    dotnet run --project src/YourProjectName
    ```

5. **Access the app:**
    Open your browser and navigate to `https://localhost:5001` (or the URL shown in the console).

    ## When to Choose Aspire Over React + ASP.NET Core (TypeScript)

    Choose Aspire's ASP.NET Core + Blazor structure instead of a React + ASP.NET Core (TypeScript) stack when:

    - **Unified C# Development**: Your team is more comfortable with C# than JavaScript/TypeScript, allowing for faster onboarding and productivity.
    - **Code Sharing**: You want to share models, validation, and business logic directly between client and server, reducing duplication and inconsistencies.
    - **Single Language Stack**: Maintaining C# across both frontend and backend simplifies development, testing, and deployment processes.
    - **Deep Integration**: You require tight integration between frontend and backend, such as shared authentication, real-time features, or common data contracts.
    - **.NET Ecosystem**: You want to leverage .NET libraries, tooling, and features throughout your application.
    - **Long-Term Maintainability**: You prioritize maintainability, consistency, and strong typing, especially for enterprise or regulated environments.
    - **Minimal JavaScript**: You prefer to minimize or avoid JavaScript dependencies in your frontend.

    A React + ASP.NET Core (TypeScript) stack may be preferable if you need access to the broader JavaScript ecosystem, require advanced client-side interactivity, or have a team with strong React/TypeScript expertise.

## License

This project is licensed under the MIT License.