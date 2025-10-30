import uuid

from src.application.dtos.conversation_dto import UpdateConversationDTO, ConversationDTO
from src.domain.exceptions.domain_exceptions import EntityNotFoundException
from src.domain.repositories.conversation_repository import IConversationRepository

class UpdateConversationUseCase:
    """Use case for updating a conversation's title."""

    def __init__(self, conversation_repository: IConversationRepository):
        self.conversation_repository = conversation_repository

    async def execute(self, conversation_id: uuid.UUID, dto: UpdateConversationDTO) -> ConversationDTO:
        """Executes the use case.

        Args:
            conversation_id: The ID of the conversation to update.
            dto: The data transfer object containing the new title.

        Returns:
            A DTO representing the updated conversation.

        Raises:
            EntityNotFoundException: If the conversation is not found.
        """
        conversation = await self.conversation_repository.find_by_id(conversation_id)

        if not conversation:
            raise EntityNotFoundException(f"Conversation with id {conversation_id} not found.")

        if dto.title:
            conversation.change_title(dto.title)

        await self.conversation_repository.save(conversation)

        return ConversationDTO.from_entity(conversation)

