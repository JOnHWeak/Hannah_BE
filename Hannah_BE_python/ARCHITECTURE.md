# Clean Architecture & Modular Monolithic Design

## 🏛️ Kiến Trúc Tổng Quan

Dự án HannahAI.Conversation được thiết kế theo **Clean Architecture** và **Modular Monolithic Pattern**.

## 📐 Clean Architecture Layers

```
┌─────────────────────────────────────────────────────────┐
│                   Presentation Layer                     │
│              (API, Controllers, DTOs)                    │
│                    src/api/                              │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│                  Application Layer                       │
│         (Use Cases, Application Services)                │
│              src/application/                            │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│                    Domain Layer                          │
│    (Entities, Value Objects, Domain Services)            │
│                  src/domain/                             │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│                 Infrastructure Layer                     │
│    (Database, External APIs, Implementations)            │
│              src/infrastructure/                         │
└─────────────────────────────────────────────────────────┘
```

## 🧩 Modular Monolithic Structure

Dự án được chia thành các **modules độc lập**:

### 1. **Conversation Module**
- Domain: Conversation entity, value objects
- Application: Conversation use cases
- Infrastructure: Conversation repository

### 2. **Message Module**
- Domain: Message entity, value objects
- Application: Message use cases
- Infrastructure: Message repository

### 3. **AI Engine Module**
- Domain: AI request/response models
- Application: AI orchestration use cases
- Infrastructure: Gemini client, OpenAI client

### 4. **Studio Module** (Future)
- Domain: Quiz, Mindmap, Flashcard entities
- Application: Content generation use cases
- Infrastructure: Generation services

## 📁 Cấu Trúc Thư Mục Clean Architecture

```
src/
├── domain/                          # 🔵 Domain Layer (Core Business Logic)
│   ├── entities/                    # Business entities
│   │   ├── conversation.py
│   │   ├── message.py
│   │   └── user.py
│   ├── value_objects/               # Value objects
│   │   ├── conversation_id.py
│   │   ├── message_id.py
│   │   └── user_id.py
│   ├── repositories/                # Repository interfaces (abstractions)
│   │   ├── conversation_repository.py
│   │   ├── message_repository.py
│   │   └── ai_provider_repository.py
│   ├── services/                    # Domain services
│   │   └── conversation_domain_service.py
│   └── exceptions/                  # Domain exceptions
│       └── domain_exceptions.py
│
├── application/                     # 🟢 Application Layer (Use Cases)
│   ├── use_cases/                   # Use case implementations
│   │   ├── conversation/
│   │   │   ├── create_conversation.py
│   │   │   ├── get_conversation.py
│   │   │   ├── update_conversation.py
│   │   │   └── delete_conversation.py
│   │   ├── message/
│   │   │   ├── send_message.py
│   │   │   ├── get_messages.py
│   │   │   └── send_message_with_ai.py
│   │   └── ai/
│   │       ├── generate_response.py
│   │       └── analyze_query.py
│   ├── dtos/                        # Data Transfer Objects
│   │   ├── conversation_dto.py
│   │   ├── message_dto.py
│   │   └── ai_dto.py
│   └── interfaces/                  # Application interfaces
│       └── ai_service_interface.py
│
├── infrastructure/                  # 🟡 Infrastructure Layer
│   ├── persistence/                 # Database implementations
│   │   ├── in_memory/
│   │   │   ├── conversation_repository_impl.py
│   │   │   └── message_repository_impl.py
│   │   └── mongodb/  (future)
│   │       ├── conversation_repository_impl.py
│   │       └── message_repository_impl.py
│   ├── ai_providers/                # External AI services
│   │   ├── gemini/
│   │   │   ├── gemini_client.py
│   │   │   └── gemini_adapter.py
│   │   └── openai/
│   │       └── openai_adapter.py
│   ├── config/                      # Configuration
│   │   ├── settings.py
│   │   └── dependency_injection.py
│   └── logging/                     # Logging infrastructure
│       └── logger.py
│
└── api/                             # 🔴 Presentation Layer
    ├── controllers/                 # API controllers
    │   ├── conversation_controller.py
    │   ├── message_controller.py
    │   └── health_controller.py
    ├── middleware/                  # HTTP middleware
    │   ├── error_handler.py
    │   └── cors_middleware.py
    ├── schemas/                     # API request/response schemas
    │   ├── conversation_schema.py
    │   ├── message_schema.py
    │   └── common_schema.py
    └── main.py                      # Application entry point
```

## 🎯 Nguyên Tắc Clean Architecture

### 1. **Dependency Rule**
- Dependencies chỉ đi từ ngoài vào trong
- Domain layer không phụ thuộc vào bất kỳ layer nào
- Application layer chỉ phụ thuộc vào Domain
- Infrastructure và API phụ thuộc vào Application và Domain

### 2. **Separation of Concerns**
- **Domain**: Business logic thuần túy, không biết về database hay API
- **Application**: Orchestrate use cases, không biết về implementation details
- **Infrastructure**: Implementation cụ thể (database, external APIs)
- **API**: HTTP handling, request/response transformation

### 3. **Dependency Inversion**
- Domain định nghĩa interfaces (repositories, services)
- Infrastructure implement các interfaces này
- Sử dụng Dependency Injection để inject implementations

### 4. **Single Responsibility**
- Mỗi class/module có một trách nhiệm duy nhất
- Use cases là small, focused, và reusable

## 🔄 Data Flow

```
HTTP Request
    ↓
[API Controller] ← Receives request, validates schema
    ↓
[Use Case] ← Orchestrates business logic
    ↓
[Domain Service] ← Pure business logic
    ↓
[Repository Interface] ← Abstract data access
    ↓
[Repository Implementation] ← Concrete data access
    ↓
[Database/External Service]
```

## 🧩 Module Independence

Mỗi module (Conversation, Message, AI Engine) có:

1. **Domain Layer riêng**: Entities, Value Objects, Interfaces
2. **Application Layer riêng**: Use Cases, DTOs
3. **Infrastructure Layer riêng**: Implementations
4. **API Layer riêng**: Controllers, Schemas

Modules giao tiếp qua:
- **Interfaces** (không phụ thuộc trực tiếp vào implementation)
- **Events** (future: domain events)
- **DTOs** (data transfer objects)

## 📋 Benefits

### Clean Architecture
✅ **Testability**: Dễ dàng test từng layer độc lập
✅ **Maintainability**: Code rõ ràng, dễ maintain
✅ **Flexibility**: Dễ thay đổi database, framework
✅ **Independence**: Business logic không phụ thuộc vào framework

### Modular Monolithic
✅ **Scalability**: Dễ dàng tách thành microservices sau này
✅ **Organization**: Code được tổ chức rõ ràng theo modules
✅ **Team Work**: Nhiều team có thể làm việc trên các modules khác nhau
✅ **Deployment**: Đơn giản hơn microservices, phức tạp hơn monolith truyền thống

## 🔧 Implementation Guidelines

### 1. Entities (Domain Layer)
```python
# src/domain/entities/conversation.py
class Conversation:
    """Domain entity - pure business logic"""
    def __init__(self, id: ConversationId, title: str, user_id: UserId):
        self._id = id
        self._title = title
        self._user_id = user_id
        self._messages: List[Message] = []
    
    def add_message(self, message: Message) -> None:
        """Business rule: validate before adding"""
        if not message.content:
            raise DomainException("Message content cannot be empty")
        self._messages.append(message)
```

### 2. Repository Interface (Domain Layer)
```python
# src/domain/repositories/conversation_repository.py
from abc import ABC, abstractmethod

class IConversationRepository(ABC):
    """Repository interface - defined in domain"""
    
    @abstractmethod
    async def save(self, conversation: Conversation) -> None:
        pass
    
    @abstractmethod
    async def find_by_id(self, id: ConversationId) -> Optional[Conversation]:
        pass
```

### 3. Use Case (Application Layer)
```python
# src/application/use_cases/conversation/create_conversation.py
class CreateConversationUseCase:
    """Use case - orchestrates business logic"""
    
    def __init__(self, repository: IConversationRepository):
        self._repository = repository
    
    async def execute(self, dto: CreateConversationDTO) -> ConversationDTO:
        # 1. Create domain entity
        conversation = Conversation(
            id=ConversationId.generate(),
            title=dto.title,
            user_id=UserId(dto.user_id)
        )
        
        # 2. Save using repository
        await self._repository.save(conversation)
        
        # 3. Return DTO
        return ConversationDTO.from_entity(conversation)
```

### 4. Repository Implementation (Infrastructure Layer)
```python
# src/infrastructure/persistence/in_memory/conversation_repository_impl.py
class InMemoryConversationRepository(IConversationRepository):
    """Concrete implementation"""
    
    def __init__(self):
        self._storage: Dict[str, Conversation] = {}
    
    async def save(self, conversation: Conversation) -> None:
        self._storage[conversation.id.value] = conversation
    
    async def find_by_id(self, id: ConversationId) -> Optional[Conversation]:
        return self._storage.get(id.value)
```

### 5. Controller (API Layer)
```python
# src/api/controllers/conversation_controller.py
@router.post("/conversations")
async def create_conversation(
    request: CreateConversationRequest,
    use_case: CreateConversationUseCase = Depends()
):
    """Controller - handles HTTP"""
    dto = CreateConversationDTO(
        title=request.title,
        user_id=request.user_id
    )
    
    result = await use_case.execute(dto)
    
    return CreateConversationResponse.from_dto(result)
```

## 🎓 Key Takeaways

1. **Domain is King**: Business logic nằm ở domain, không phụ thuộc vào gì
2. **Use Cases are Focused**: Mỗi use case làm một việc cụ thể
3. **Interfaces over Implementations**: Code phụ thuộc vào abstractions
4. **DTOs for Data Transfer**: Không expose entities ra ngoài
5. **Modules are Independent**: Mỗi module có thể tách ra thành service riêng

