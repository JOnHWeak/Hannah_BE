from fastapi import Request, status
from fastapi.responses import JSONResponse

from src.domain.exceptions.domain_exceptions import DomainException

async def domain_exception_handler(request: Request, exc: DomainException):
    """Handles domain exceptions and formats them as a JSON response."""
    return JSONResponse(
        status_code=status.HTTP_400_BAD_REQUEST,
        content={"success": False, "error": str(exc)},
    )

async def generic_exception_handler(request: Request, exc: Exception):
    """Handles generic exceptions and formats them as a JSON response."""
    # In a real application, you would log the exception here
    return JSONResponse(
        status_code=status.HTTP_500_INTERNAL_SERVER_ERROR,
        content={"success": False, "error": "An unexpected error occurred."},
    )

