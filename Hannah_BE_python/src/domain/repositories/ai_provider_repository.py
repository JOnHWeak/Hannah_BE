from abc import ABC, abstractmethod
from typing import List, Dict, Any, Optional

class AIProviderResponse:
    """Data class for AI provider responses."""
    def __init__(self, content: str, model: str, tokens_used: Optional[int] = None):
        self.content = content
        self.model = model
        self.tokens_used = tokens_used

class IAIProviderRepository(ABC):
    """Interface for an AI service provider."""

    @abstractmethod
    async def generate_response(
        self,
        prompt: str,
        conversation_history: List[Dict[str, str]],
        temperature: Optional[float] = None,
        max_tokens: Optional[int] = None,
    ) -> AIProviderResponse:
        """Generates a response from the AI provider."""
        pass

