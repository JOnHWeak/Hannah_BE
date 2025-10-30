import uuid
from datetime import datetime
from typing import Optional, List, Dict, Any
from pydantic import BaseModel, Field

from src.application.dtos.message_dto import MessageDTO
from src.domain.entities.conversation import Conversation

class ConversationDTO(BaseModel):
    """Data Transfer Object for Conversation entities."""
    id: uuid.UUID
    user_id: str
    title: str
    created_at: datetime
    updated_at: datetime
    messages: List[MessageDTO] = Field(default_factory=list)
    metadata: Optional[Dict[str, Any]] = Field(default_factory=dict)

    class Config:
        from_attributes = True

    @classmethod
    def from_entity(cls, conversation: Conversation) -> "ConversationDTO":
        return cls.model_validate(conversation)

class CreateConversationDTO(BaseModel):
    """DTO for creating a new conversation."""
    user_id: str
    title: Optional[str] = None
    metadata: Optional[Dict[str, Any]] = None

class UpdateConversationDTO(BaseModel):
    """DTO for updating a conversation."""
    title: Optional[str] = None

