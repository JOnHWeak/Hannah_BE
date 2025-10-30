# HannahAI.Conversation (v2.0)

This is an AI-powered conversation service built with Python and FastAPI, following the principles of **Clean Architecture** and **Modular Monolithic Design**.

## 🏛️ Architecture

The project is structured into four distinct layers:

1.  **Domain**: Core business logic and entities.
2.  **Application**: Use cases that orchestrate the domain logic.
3.  **Infrastructure**: External concerns like databases, APIs, and frameworks.
4.  **API (Presentation)**: Exposes the application via a RESTful API.

For a detailed explanation, please see the [Architecture Documentation](ARCHITECTURE.md).

## 🚀 Getting Started

To get the application up and running, please follow the [Quick Start Guide](QUICKSTART.md).

## 📁 Project Structure

For a detailed view of the project's file structure, see the [Project Structure Document](PROJECT_STRUCTURE.md).

## 📝 API Reference

The API is documented using OpenAPI (Swagger). Once the application is running, you can access the interactive documentation at:

- **Swagger UI**: [http://localhost:8000/docs](http://localhost:8000/docs)
- **ReDoc**: [http://localhost[object Object] Testing

To run the test suite, use the following command:

```bash
pytest -v
```

This will run both unit and integration tests.
