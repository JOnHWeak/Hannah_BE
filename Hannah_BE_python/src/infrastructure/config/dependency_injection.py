from punctuator import Container, dependency

from src.application.use_cases.conversation.create_conversation import CreateConversationUseCase
from src.application.use_cases.conversation.get_conversation import GetConversationUseCase
from src.application.use_cases.conversation.update_conversation import UpdateConversationUseCase
from src.application.use_cases.message.send_message_with_ai import SendMessageWithAIUseCase
from src.domain.repositories.ai_provider_repository import IAIProviderRepository
from src.domain.repositories.conversation_repository import IConversationRepository
from src.domain.repositories.message_repository import IMessageRepository
from src.infrastructure.ai_providers.gemini.gemini_ai_provider import GeminiAIProvider
from src.infrastructure.config.settings import Settings, settings
from src.infrastructure.persistence.in_memory.conversation_repository_impl import (
    InMemoryConversationRepository,
)
from src.infrastructure.persistence.in_memory.message_repository_impl import (
    InMemoryMessageRepository,
)

class AppContainer(Container):
    """Dependency injection container for the application."""

    @dependency
    def settings(self) -> Settings:
        """Provides the application settings."""
        return settings

    @dependency(singleton=True)
    def conversation_repository(self) -> IConversationRepository:
        """Provides the in-memory conversation repository."""
        return InMemoryConversationRepository()

    @dependency(singleton=True)
    def message_repository(self) -> IMessageRepository:
        """Provides the in-memory message repository."""
        return InMemoryMessageRepository()

    @dependency
    def ai_provider_repository(self, settings: Settings) -> IAIProviderRepository:
        """Provides the Gemini AI provider."""
        return GeminiAIProvider(settings)

    @dependency
    def create_conversation_use_case(
        self, conversation_repository: IConversationRepository
    ) -> CreateConversationUseCase:
        """Provides the use case for creating conversations."""
        return CreateConversationUseCase(conversation_repository)

    @dependency
    def get_conversation_use_case(
        self, conversation_repository: IConversationRepository
    ) -> GetConversationUseCase:
        """Provides the use case for retrieving conversations."""
        return GetConversationUseCase(conversation_repository)

    @dependency
    def update_conversation_use_case(
        self, conversation_repository: IConversationRepository
    ) -> UpdateConversationUseCase:
        """Provides the use case for updating conversations."""
        return UpdateConversationUseCase(conversation_repository)

    @dependency
    def send_message_with_ai_use_case(
        self, 
        conversation_repository: IConversationRepository, 
        message_repository: IMessageRepository, 
        ai_provider_repository: IAIProviderRepository
    ) -> SendMessageWithAIUseCase:
        """Provides the use case for sending messages and getting AI responses."""
        return SendMessageWithAIUseCase(
            conversation_repository,
            message_repository,
            ai_provider_repository,
        )

# Global container instance
container = AppContainer()

