from fastapi import APIRouter, Depends

from src.api.schemas.common_schema import BaseResponse
from src.api.schemas.message_schema import SendMessageRequest, SendMessageResponse
from src.application.dtos.message_dto import CreateMessageDTO
from src.application.use_cases.message.send_message_with_ai import SendMessageWithAIUseCase
from src.infrastructure.config.dependency_injection import container

router = APIRouter(prefix="/messages", tags=["Messages"])

@router.post("", response_model=BaseResponse[SendMessageResponse])
async def send_message(
    request: SendMessageRequest,
    use_case: SendMessageWithAIUseCase = Depends(container.send_message_with_ai_use_case),
):
    """Sends a message and receives a response from the AI."""
    dto = CreateMessageDTO(
        conversation_id=request.conversation_id,
        content=request.content,
    )
    user_message, ai_response = await use_case.execute(dto)

    return BaseResponse(
        data=SendMessageResponse(
            user_message=user_message,
            ai_response=ai_response,
        )
    )

