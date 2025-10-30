from src.application.dtos.conversation_dto import CreateConversationDTO, ConversationDTO
from src.domain.entities.conversation import Conversation
from src.domain.repositories.conversation_repository import IConversationRepository

class CreateConversationUseCase:
    """Use case for creating a new conversation."""

    def __init__(self, conversation_repository: IConversationRepository):
        self.conversation_repository = conversation_repository

    async def execute(self, dto: CreateConversationDTO) -> ConversationDTO:
        """Executes the use case.

        Args:
            dto: The data transfer object containing the conversation details.

        Returns:
            A DTO representing the newly created conversation.
        """
        # Create a new conversation entity
        conversation = Conversation.create(
            user_id=dto.user_id,
            title=dto.title,
            metadata=dto.metadata,
        )

        # Save the conversation using the repository
        await self.conversation_repository.save(conversation)

        # Return the conversation as a DTO
        return ConversationDTO.from_entity(conversation)

