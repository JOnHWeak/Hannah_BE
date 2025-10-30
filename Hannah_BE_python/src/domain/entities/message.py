import uuid
from datetime import datetime
from typing import Optional, Dict, Any

from src.domain.enums.message_role import MessageRole
from src.domain.exceptions.domain_exceptions import InvalidArgumentException

class Message:
    """Represents a message in a conversation."""

    def __init__(
        self,
        id: uuid.UUID,
        conversation_id: uuid.UUID,
        content: str,
        role: MessageRole,
        created_at: datetime,
        metadata: Optional[Dict[str, Any]] = None,
    ):
        if not id:
            raise InvalidArgumentException("Message ID cannot be empty.")
        if not conversation_id:
            raise InvalidArgumentException("Conversation ID cannot be empty.")
        if not content:
            raise InvalidArgumentException("Message content cannot be empty.")
        if not role:
            raise InvalidArgumentException("Message role cannot be empty.")

        self.id = id
        self.conversation_id = conversation_id
        self.content = content
        self.role = role
        self.created_at = created_at
        self.metadata = metadata or {}

    @staticmethod
    def create(
        conversation_id: uuid.UUID,
        content: str,
        role: MessageRole,
        metadata: Optional[Dict[str, Any]] = None,
    ) -> "Message":
        """Factory method to create a new Message instance."""
        return Message(
            id=uuid.uuid4(),
            conversation_id=conversation_id,
            content=content,
            role=role,
            created_at=datetime.utcnow(),
            metadata=metadata,
        )

