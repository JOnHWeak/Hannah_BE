from typing import Optional, List, Dict, Any
from pydantic import BaseModel, Field

from src.domain.repositories.ai_provider_repository import AIProviderResponse

class AIResponseDTO(BaseModel):
    """Data Transfer Object for AI provider responses."""
    content: str
    model: str
    tokens_used: Optional[int] = None

    @classmethod
    def from_provider_response(cls, response: AIProviderResponse) -> "AIResponseDTO":
        return cls(
            content=response.content,
            model=response.model,
            tokens_used=response.tokens_used,
        )

