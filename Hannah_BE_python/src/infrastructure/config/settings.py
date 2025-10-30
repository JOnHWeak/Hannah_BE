from pydantic_settings import BaseSettings
from pydantic import Field

class Settings(BaseSettings):
    """Application settings loaded from environment variables."""

    # API Settings
    API_HOST: str = "0.0.0.0"
    API_PORT: int = 8000
    API_PREFIX: str = "/api"

    # Google Gemini API
    GEMINI_API_KEY: str = Field(..., min_length=1)
    GEMINI_MODEL: str = "gemini-pro"

    class Config:
        env_file = ".env"
        case_sensitive = True

# Global settings instance
settings = Settings()

