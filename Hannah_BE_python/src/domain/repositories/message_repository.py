from abc import ABC, abstractmethod
import uuid
from typing import List, Optional

from src.domain.entities.message import Message

class IMessageRepository(ABC):
    """Interface for a repository that handles message persistence."""

    @abstractmethod
    async def save(self, message: Message) -> None:
        """Saves a message."""
        pass

    @abstractmethod
    async def find_by_id(self, message_id: uuid.UUID) -> Optional[Message]:
        """Finds a message by its ID."""
        pass

    @abstractmethod
    async def find_by_conversation_id(
        self, conversation_id: uuid.UUID
    ) -> List[Message]:
        """Finds all messages for a given conversation."""
        pass

