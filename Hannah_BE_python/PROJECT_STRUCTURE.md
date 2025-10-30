# Project Structure (v2.0 - Clean Architecture)

This document outlines the new project structure, which is based on the principles of **Clean Architecture**.

## Directory Tree

```
.
├── src
│   ├── api
│   │   ├── controllers
│   │   │   ├── conversation_controller.py
│   │   │   ├── health_controller.py
│   │   │   └── message_controller.py
│   │   ├── middleware
│   │   │   ├── cors_middleware.py
│   │   │   └── error_handler.py
│   │   ├── schemas
│   │   │   ├── common_schema.py
│   │   │   ├── conversation_schema.py
│   │   │   └── message_schema.py
│   │   └── main.py
│   ├── application
│   │   ├── dtos
│   │   │   ├── ai_dto.py
│   │   │   ├── conversation_dto.py
│   │   │   └── message_dto.py
│   │   ├── interfaces
│   │   └── use_cases
│   │       ├── conversation
│   │       │   ├── create_conversation.py
│   │       │   ├── get_conversation.py
│   │       │   └── update_conversation.py
│   │       └── message
│   │           └── send_message_with_ai.py
│   ├── domain
│   │   ├── entities
│   │   │   ├── conversation.py
│   │   │   └── message.py
│   │   ├── enums
│   │   │   └── message_role.py
│   │   ├── exceptions
│   │   │   └── domain_exceptions.py
│   │   ├── repositories
│   │   │   ├── ai_provider_repository.py
│   │   │   ├── conversation_repository.py
│   │   │   └── message_repository.py
│   │   └── services
│   └── infrastructure
│       ├── ai_providers
│       │   └── gemini
│       │       └── gemini_ai_provider.py
│       ├── config
│       │   ├── dependency_injection.py
│       │   └── settings.py
│       ├── logging
│       └── persistence
│           └── in_memory
│               ├── conversation_repository_impl.py
│               └── message_repository_impl.py
├── tests
│   ├── conftest.py
│   ├── integration
│   │   ├── test_conversation_flow.py
│   │   └── test_health_controller.py
│   └── unit
│       └── application
│           └── use_cases
│               ├── conversation
│               │   └── test_create_conversation.py
│               └── message
│                   └── test_send_message_with_ai.py
├── .env.example
├── .gitignore
├── ARCHITECTURE.md
├── Dockerfile
├── NEXT_STEPS.md
├── PROJECT_STRUCTURE.md
├── pyproject.toml
├── pytest.ini
├── QUICKSTART.md
├── README.md
├── requirements-dev.txt
├── requirements.txt
└── SUMMARY.md
```

## Layer Descriptions

- **`src/domain`**: Contains the core business logic, entities, and interfaces. This layer is completely independent of any frameworks or external dependencies.
- **`src/application`**: Orchestrates the domain layer to perform specific application tasks (use cases). It is decoupled from the UI and database.
- **`src/infrastructure`**: Provides concrete implementations for the interfaces defined in the domain and application layers (e.g., database repositories, external API clients).
- **`src/api`**: Exposes the application's functionality via a RESTful API. It handles HTTP requests, validation, and serialization.

## Key Files

- **`src/domain/entities`**: The core business objects (e.g., `Conversation`, `Message`).
- **`src/domain/repositories`**: The interfaces for data persistence (e.g., `IConversationRepository`).
- **`src/application/use_cases`**: The application's features (e.g., `CreateConversationUseCase`).
- **`src/infrastructure/persistence`**: The concrete implementations of the repositories (e.g., `InMemoryConversationRepository`).
- **`src/infrastructure/config/dependency_injection.py`**: The dependency injection container that wires everything together.
- **`src/api/controllers`**: The API endpoints that handle HTTP requests.
- **`src/api/main.py`**: The main application entry point.
