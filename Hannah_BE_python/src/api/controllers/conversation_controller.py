import uuid
from fastapi import APIRouter, Depends

from src.api.schemas.common_schema import BaseResponse
from src.api.schemas.conversation_schema import (
    CreateConversationRequest,
    ConversationResponse,
    UpdateConversationRequest,
)
from src.application.dtos.conversation_dto import CreateConversationDTO, UpdateConversationDTO
from src.application.use_cases.conversation.create_conversation import CreateConversationUseCase
from src.application.use_cases.conversation.get_conversation import GetConversationUseCase
from src.application.use_cases.conversation.update_conversation import UpdateConversationUseCase
from src.infrastructure.config.dependency_injection import container

router = APIRouter(prefix="/conversations", tags=["Conversations"])

@router.post("", response_model=BaseResponse[ConversationResponse])
async def create_conversation(
    request: CreateConversationRequest,
    use_case: CreateConversationUseCase = Depends(container.create_conversation_use_case),
):
    """Creates a new conversation."""
    dto = CreateConversationDTO(user_id=request.user_id, title=request.title)
    result = await use_case.execute(dto)
    return BaseResponse(data=ConversationResponse.from_dto(result))

@router.get("/{conversation_id}", response_model=BaseResponse[ConversationResponse])
async def get_conversation(
    conversation_id: uuid.UUID,
    use_case: GetConversationUseCase = Depends(container.get_conversation_use_case),
):
    """Retrieves a conversation by its ID."""
    result = await use_case.execute(conversation_id)
    return BaseResponse(data=ConversationResponse.from_dto(result))

@router.put("/{conversation_id}", response_model=BaseResponse[ConversationResponse])
async def update_conversation(
    conversation_id: uuid.UUID,
    request: UpdateConversationRequest,
    use_case: UpdateConversationUseCase = Depends(container.update_conversation_use_case),
):
    """Updates a conversation's title."""
    dto = UpdateConversationDTO(title=request.title)
    result = await use_case.execute(conversation_id, dto)
    return BaseResponse(data=ConversationResponse.from_dto(result))

