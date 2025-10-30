import uuid
import pytest
from unittest.mock import AsyncMock

from src.application.dtos.message_dto import CreateMessageDTO
from src.application.use_cases.message.send_message_with_ai import SendMessageWithAIUseCase
from src.domain.entities.conversation import Conversation
from src.domain.repositories.ai_provider_repository import AIProviderResponse
from src.domain.repositories.conversation_repository import IConversationRepository
from src.domain.repositories.message_repository import IMessageRepository
from src.domain.repositories.ai_provider_repository import IAIProviderRepository

@pytest.mark.asyncio
async def test_send_message_with_ai_use_case():
    """Tests that the SendMessageWithAIUseCase correctly orchestrates the message flow."""
    # Arrange
    mock_conv_repo = AsyncMock(spec=IConversationRepository)
    mock_msg_repo = AsyncMock(spec=IMessageRepository)
    mock_ai_repo = AsyncMock(spec=IAIProviderRepository)

    use_case = SendMessageWithAIUseCase(
        conversation_repository=mock_conv_repo,
        message_repository=mock_msg_repo,
        ai_provider_repository=mock_ai_repo,
    )

    conversation_id = uuid.uuid4()
    dto = CreateMessageDTO(
        conversation_id=conversation_id,
        content="Hello, AI!",
    )

    # Mock the repository responses
    mock_conv_repo.find_by_id.return_value = Conversation.create(
        id=conversation_id, user_id="test-user"
    )
    mock_msg_repo.find_by_conversation_id.return_value = []
    mock_ai_repo.generate_response.return_value = AIProviderResponse(
        content="Hello, human!", model="gemini-pro"
    )

    # Act
    user_msg_dto, ai_msg_dto = await use_case.execute(dto)

    # Assert
    mock_conv_repo.find_by_id.assert_called_once_with(conversation_id)
    assert mock_msg_repo.save.call_count == 2  # One for user, one for AI
    mock_ai_repo.generate_response.assert_called_once()
    mock_conv_repo.save.assert_called_once()

    assert user_msg_dto.content == "Hello, AI!"
    assert ai_msg_dto.content == "Hello, human!"

