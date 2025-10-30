import uuid
from datetime import datetime
from typing import Optional, List, Dict, Any

from src.domain.entities.message import Message
from src.domain.exceptions.domain_exceptions import InvalidArgumentException

class Conversation:
    """Represents a conversation between a user and an assistant."""

    def __init__(
        self,
        id: uuid.UUID,
        user_id: str,
        title: str,
        created_at: datetime,
        updated_at: datetime,
        messages: Optional[List[Message]] = None,
        metadata: Optional[Dict[str, Any]] = None,
    ):
        if not id:
            raise InvalidArgumentException("Conversation ID cannot be empty.")
        if not user_id:
            raise InvalidArgumentException("User ID cannot be empty.")
        if not title:
            raise InvalidArgumentException("Title cannot be empty.")

        self.id = id
        self.user_id = user_id
        self.title = title
        self.created_at = created_at
        self.updated_at = updated_at
        self.messages = messages or []
        self.metadata = metadata or {}

    @staticmethod
    def create(
        user_id: str,
        title: Optional[str] = None,
        metadata: Optional[Dict[str, Any]] = None,
    ) -> "Conversation":
        """Factory method to create a new Conversation instance."""
        now = datetime.utcnow()
        return Conversation(
            id=uuid.uuid4(),
            user_id=user_id,
            title=title or "New Conversation",
            created_at=now,
            updated_at=now,
            metadata=metadata,
        )

    def add_message(self, message: Message):
        """Adds a message to the conversation and updates the timestamp."""
        if message.conversation_id != self.id:
            raise InvalidArgumentException(
                "Message does not belong to this conversation."
            )
        self.messages.append(message)
        self.touch()

    def change_title(self, new_title: str):
        """Changes the title of the conversation."""
        if not new_title:
            raise InvalidArgumentException("New title cannot be empty.")
        self.title = new_title
        self.touch()

    def touch(self):
        """Updates the 'updated_at' timestamp to the current time."""
        self.updated_at = datetime.utcnow()

    @property
    def last_message(self) -> Optional[Message]:
        """Returns the last message in the conversation, if any."""
        return self.messages[-1] if self.messages else None

