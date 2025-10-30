import uuid
from typing import Dict, List, Optional

from src.domain.entities.conversation import Conversation
from src.domain.repositories.conversation_repository import IConversationRepository

class InMemoryConversationRepository(IConversationRepository):
    """In-memory implementation of the conversation repository."""

    def __init__(self):
        self._storage: Dict[uuid.UUID, Conversation] = {}

    async def save(self, conversation: Conversation) -> None:
        """Saves a conversation to the in-memory store."""
        self._storage[conversation.id] = conversation

    async def find_by_id(self, conversation_id: uuid.UUID) -> Optional[Conversation]:
        """Finds a conversation by its ID from the in-memory store."""
        return self._storage.get(conversation_id)

    async def find_by_user_id(self, user_id: str) -> List[Conversation]:
        """Finds all conversations for a given user from the in-memory store."""
        return [
            conv
            for conv in self._storage.values()
            if conv.user_id == user_id
        ]

    async def delete(self, conversation_id: uuid.UUID) -> None:
        """Deletes a conversation from the in-memory store."""
        if conversation_id in self._storage:
            del self._storage[conversation_id]

