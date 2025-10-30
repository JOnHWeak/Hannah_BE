from typing import TypeVar, Generic
from pydantic import BaseModel

T = TypeVar("T")

class BaseResponse(BaseModel, Generic[T]):
    """Generic base response model for API endpoints."""
    success: bool = True
    data: T

