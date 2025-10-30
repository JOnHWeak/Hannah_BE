import uuid
from datetime import datetime
from typing import Optional, Dict, Any
from pydantic import BaseModel, Field

from src.domain.entities.message import Message
from src.domain.enums.message_role import MessageRole

class MessageDTO(BaseModel):
    """Data Transfer Object for Message entities."""
    id: uuid.UUID
    conversation_id: uuid.UUID
    content: str
    role: MessageRole
    created_at: datetime
    metadata: Optional[Dict[str, Any]] = Field(default_factory=dict)

    class Config:
        from_attributes = True

    @classmethod
    def from_entity(cls, message: Message) -> "MessageDTO":
        return cls.model_validate(message)

class CreateMessageDTO(BaseModel):
    """DTO for creating a new message."""
    conversation_id: uuid.UUID
    content: str
    role: MessageRole = MessageRole.USER
    metadata: Optional[Dict[str, Any]] = None

