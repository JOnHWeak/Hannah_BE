# Architecture Overview

## System Architecture

HannahAI.Conversation is built using a layered architecture pattern:

```
┌─────────────────────────────────────────┐
│         API Layer (FastAPI)             │
│  - Routes                               │
│  - Middleware                           │
│  - Request/Response handling            │
└─────────────────────────────────────────┘
                  ↓
┌─────────────────────────────────────────┐
│       Service Layer (Business Logic)    │
│  - ConversationService                  │
│  - MessageService                       │
│  - AIOrchestrator                       │
│  - Studio Services                      │
└─────────────────────────────────────────┘
                  ↓
┌─────────────────────────────────────────┐
│         AI Engine                       │
│  - Gemini Client                        │
│  - Agents (Query, Retrieval, etc)      │
│  - Prompt Management                    │
└─────────────────────────────────────────┘
                  ↓
┌─────────────────────────────────────────┐
│      Data Layer (Future)                │
│  - MongoDB (Conversations, Messages)    │
│  - Elasticsearch (Document Search)      │
│  - SQL Server (Metadata Sync)           │
└─────────────────────────────────────────┘
```

## Core Components

### 1. API Layer
- **FastAPI**: Modern, fast web framework
- **Middleware**: Error handling, CORS, logging
- **Routes**: RESTful endpoints for all operations

### 2. Service Layer
- **ConversationService**: Manages conversation lifecycle
- **MessageService**: Handles message creation and AI responses
- **AIOrchestrator**: Coordinates AI operations
- **Studio Services**: Generate educational content

### 3. AI Engine
- **GeminiClient**: Google Gemini API integration
- **Agents**: Specialized AI agents for different tasks
- **Prompts**: Centralized prompt management

### 4. Data Models
- **Domain Models**: Business entities
- **Schemas**: Pydantic models for validation
- **Enums**: Type-safe enumerations

## Data Flow

### Message Processing Flow

```
User Request
    ↓
API Endpoint (POST /messages)
    ↓
MessageService.send_message_with_ai_response()
    ↓
1. Create user message
2. Get conversation history
3. Call AIOrchestrator
    ↓
AIOrchestrator.process_query()
    ↓
1. Analyze query (future)
2. Check custom responses (future)
3. Retrieve context (RAG - future)
4. Generate response (Gemini)
    ↓
GeminiClient.generate_response()
    ↓
Return AI response
    ↓
Create assistant message
    ↓
Return both messages to user
```

## Technology Stack

- **Language**: Python 3.11+
- **Framework**: FastAPI
- **AI Provider**: Google Gemini API
- **Validation**: Pydantic
- **Logging**: Structlog
- **Testing**: Pytest
- **Container**: Docker

## Future Enhancements

1. **Database Integration**
   - MongoDB for conversations and messages
   - Elasticsearch for document search
   - SQL Server for metadata sync

2. **RAG Implementation**
   - Document processing and chunking
   - Vector embeddings
   - Semantic search

3. **Studio Tools**
   - Quiz generation
   - Mindmap creation
   - Flashcard generation
   - Report generation

4. **Authentication & Authorization**
   - JWT-based authentication
   - Role-based access control
   - API key management

5. **Monitoring & Observability**
   - Metrics collection
   - Distributed tracing
   - Performance monitoring

