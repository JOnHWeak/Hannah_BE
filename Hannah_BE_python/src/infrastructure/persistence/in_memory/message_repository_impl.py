import uuid
from typing import Dict, List, Optional

from src.domain.entities.message import Message
from src.domain.repositories.message_repository import IMessageRepository

class InMemoryMessageRepository(IMessageRepository):
    """In-memory implementation of the message repository."""

    def __init__(self):
        self._storage: Dict[uuid.UUID, Message] = {}

    async def save(self, message: Message) -> None:
        """Saves a message to the in-memory store."""
        self._storage[message.id] = message

    async def find_by_id(self, message_id: uuid.UUID) -> Optional[Message]:
        """Finds a message by its ID from the in-memory store."""
        return self._storage.get(message_id)

    async def find_by_conversation_id(
        self, conversation_id: uuid.UUID
    ) -> List[Message]:
        """Finds all messages for a given conversation from the in-memory store."""
        return [
            msg
            for msg in self._storage.values()
            if msg.conversation_id == conversation_id
        ]

