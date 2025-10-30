import uuid
from datetime import datetime
from typing import Optional, List
from pydantic import BaseModel, Field

from src.application.dtos.conversation_dto import ConversationDTO
from src.application.dtos.message_dto import MessageDTO

class CreateConversationRequest(BaseModel):
    """Request model for creating a new conversation."""
    user_id: str = Field(..., description="The ID of the user creating the conversation.")
    title: Optional[str] = Field(None, description="An optional title for the conversation.")

class UpdateConversationRequest(BaseModel):
    """Request model for updating a conversation's title."""
    title: str = Field(..., description="The new title for the conversation.")

class ConversationResponse(BaseModel):
    """Response model for a conversation."""
    id: uuid.UUID
    user_id: str
    title: str
    created_at: datetime
    updated_at: datetime
    messages: List[MessageDTO]

    @classmethod
    def from_dto(cls, dto: ConversationDTO) -> "ConversationResponse":
        return cls.model_validate(dto)

