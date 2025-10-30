import uuid

from src.application.dtos.conversation_dto import ConversationDTO
from src.domain.exceptions.domain_exceptions import EntityNotFoundException
from src.domain.repositories.conversation_repository import IConversationRepository

class GetConversationUseCase:
    """Use case for retrieving a conversation by its ID."""

    def __init__(self, conversation_repository: IConversationRepository):
        self.conversation_repository = conversation_repository

    async def execute(self, conversation_id: uuid.UUID) -> ConversationDTO:
        """Executes the use case.

        Args:
            conversation_id: The ID of the conversation to retrieve.

        Returns:
            A DTO representing the conversation.

        Raises:
            EntityNotFoundException: If the conversation is not found.
        """
        conversation = await self.conversation_repository.find_by_id(conversation_id)

        if not conversation:
            raise EntityNotFoundException(f"Conversation with id {conversation_id} not found.")

        return ConversationDTO.from_entity(conversation)

