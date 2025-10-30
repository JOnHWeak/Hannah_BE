from typing import List, Dict, Any, Optional
import google.generativeai as genai

from src.domain.repositories.ai_provider_repository import IAIProviderRepository, AIProviderResponse
from src.infrastructure.config.settings import Settings

class GeminiAIProvider(IAIProviderRepository):
    """Concrete implementation of the AI provider for Google Gemini."""

    def __init__(self, settings: Settings):
        self.settings = settings
        genai.configure(api_key=self.settings.GEMINI_API_KEY)
        self.model = genai.GenerativeModel(self.settings.GEMINI_MODEL)

    async def generate_response(
        self,
        prompt: str,
        conversation_history: List[Dict[str, str]],
        temperature: Optional[float] = 0.7,
        max_tokens: Optional[int] = 2048,
    ) -> AIProviderResponse:
        """Generates a response from the Gemini API."""
        try:
            generation_config = {
                "temperature": temperature,
                "max_output_tokens": max_tokens,
            }

            formatted_history = self._format_history(conversation_history)

            chat = self.model.start_chat(history=formatted_history)
            response = await chat.send_message_async(
                prompt, generation_config=generation_config
            )

            content = response.text
            tokens_used = self.model.count_tokens(response.text).total_tokens

            return AIProviderResponse(
                content=content,
                model=self.settings.GEMINI_MODEL,
                tokens_used=tokens_used,
            )
        except Exception as e:
            # Add proper logging here in a real application
            raise Exception(f"Gemini API error: {e}")

    def _format_history(self, history: List[Dict[str, str]]) -> List[Dict[str, Any]]:
        """Formats conversation history for the Gemini API."""
        formatted = []
        for msg in history:
            role = msg.get("role", "user")
            gemini_role = "model" if role == "assistant" else "user"
            formatted.append({"role": gemini_role, "parts": [msg.get("content", "")]})
        return formatted

