import pytest
from unittest.mock import AsyncMock

from src.application.dtos.conversation_dto import CreateConversationDTO
from src.application.use_cases.conversation.create_conversation import CreateConversationUseCase
from src.domain.repositories.conversation_repository import IConversationRepository

@pytest.mark.asyncio
async def test_create_conversation_use_case():
    """Tests that the CreateConversationUseCase correctly creates and saves a conversation."""
    # Arrange
    mock_repo = AsyncMock(spec=IConversationRepository)
    use_case = CreateConversationUseCase(conversation_repository=mock_repo)
    dto = CreateConversationDTO(
        user_id="test-user-123",
        title="My Test Conversation",
    )

    # Act
    result = await use_case.execute(dto)

    # Assert
    mock_repo.save.assert_called_once()
    assert result.user_id == dto.user_id
    assert result.title == dto.title

