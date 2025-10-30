import uuid
from pydantic import BaseModel, Field

from src.application.dtos.message_dto import MessageDTO

class SendMessageRequest(BaseModel):
    """Request model for sending a new message."""
    conversation_id: uuid.UUID = Field(..., description="The ID of the conversation.")
    content: str = Field(..., description="The content of the message.")

class SendMessageResponse(BaseModel):
    """Response model for the user's and AI's messages."""
    user_message: MessageDTO
    ai_response: MessageDTO

