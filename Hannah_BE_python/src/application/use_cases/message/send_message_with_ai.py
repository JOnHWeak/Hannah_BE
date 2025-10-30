from typing import Tuple

from src.application.dtos.message_dto import CreateMessageDTO, MessageDTO
from src.domain.entities.message import Message
from src.domain.enums.message_role import MessageRole
from src.domain.exceptions.domain_exceptions import EntityNotFoundException
from src.domain.repositories.conversation_repository import IConversationRepository
from src.domain.repositories.message_repository import IMessageRepository
from src.domain.repositories.ai_provider_repository import IAIProviderRepository

class SendMessageWithAIUseCase:
    """Use case for sending a message and getting an AI response."""

    def __init__(
        self,
        conversation_repository: IConversationRepository,
        message_repository: IMessageRepository,
        ai_provider_repository: IAIProviderRepository,
    ):
        self.conversation_repository = conversation_repository
        self.message_repository = message_repository
        self.ai_provider_repository = ai_provider_repository

    async def execute(self, dto: CreateMessageDTO) -> Tuple[MessageDTO, MessageDTO]:
        """Executes the use case.

        Args:
            dto: The data transfer object containing the user's message.

        Returns:
            A tuple containing the user's message and the AI's response as DTOs.

        Raises:
            EntityNotFoundException: If the conversation is not found.
        """
        # 1. Find the conversation
        conversation = await self.conversation_repository.find_by_id(dto.conversation_id)
        if not conversation:
            raise EntityNotFoundException(
                f"Conversation with id {dto.conversation_id} not found."
            )

        # 2. Create and save the user's message
        user_message = Message.create(
            conversation_id=dto.conversation_id,
            content=dto.content,
            role=MessageRole.USER,
            metadata=dto.metadata,
        )
        await self.message_repository.save(user_message)
        conversation.add_message(user_message)

        # 3. Get conversation history for the AI provider
        history_messages = await self.message_repository.find_by_conversation_id(
            dto.conversation_id
        )
        conversation_history = [
            {"role": msg.role.value, "content": msg.content} for msg in history_messages
        ]

        # 4. Generate AI response
        ai_response = await self.ai_provider_repository.generate_response(
            prompt=dto.content,
            conversation_history=conversation_history,
        )

        # 5. Create and save the AI's message
        ai_message = Message.create(
            conversation_id=dto.conversation_id,
            content=ai_response.content,
            role=MessageRole.ASSISTANT,
            metadata={
                "model": ai_response.model,
                "tokens_used": ai_response.tokens_used,
            },
        )
        await self.message_repository.save(ai_message)
        conversation.add_message(ai_message)

        # 6. Save the updated conversation
        await self.conversation_repository.save(conversation)

        # 7. Return DTOs for both messages
        return (
            MessageDTO.from_entity(user_message),
            MessageDTO.from_entity(ai_message),
        )

