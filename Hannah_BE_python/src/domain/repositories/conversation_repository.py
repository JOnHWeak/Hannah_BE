from abc import ABC, abstractmethod
import uuid
from typing import List, Optional

from src.domain.entities.conversation import Conversation

class IConversationRepository(ABC):
    """Interface for a repository that handles conversation persistence."""

    @abstractmethod
    async def save(self, conversation: Conversation) -> None:
        """Saves a conversation."""
        pass

    @abstractmethod
    async def find_by_id(self, conversation_id: uuid.UUID) -> Optional[Conversation]:
        """Finds a conversation by its ID."""
        pass

    @abstractmethod
    async def find_by_user_id(self, user_id: str) -> List[Conversation]:
        """Finds all conversations for a given user."""
        pass

    @abstractmethod
    async def delete(self, conversation_id: uuid.UUID) -> None:
        """Deletes a conversation by its ID."""
        pass

