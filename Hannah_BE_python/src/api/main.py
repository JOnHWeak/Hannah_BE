from fastapi import FastAPI

from src.api.controllers import conversation_controller, health_controller, message_controller
from src.api.middleware.cors_middleware import add_cors_middleware
from src.api.middleware.error_handler import domain_exception_handler, generic_exception_handler
from src.domain.exceptions.domain_exceptions import DomainException
from src.infrastructure.config.settings import settings

def create_app() -> FastAPI:
    """Creates and configures the FastAPI application."""
    app = FastAPI(
        title="HannahAI Conversation Service",
        version="2.0.0",
        description="A conversation service built with Clean Architecture.",
    )

    # Add middleware
    add_cors_middleware(app)

    # Register exception handlers
    app.add_exception_handler(DomainException, domain_exception_handler)
    app.add_exception_handler(Exception, generic_exception_handler)

    # Include routers
    app.include_router(health_controller.router, prefix=settings.API_PREFIX)
    app.include_router(conversation_controller.router, prefix=settings.API_PREFIX)
    app.include_router(message_controller.router, prefix=settings.API_PREFIX)

    return app

app = create_app()

if __name__ == "__main__":
    import uvicorn
    uvicorn.run(
        app,
        host=settings.API_HOST,
        port=settings.API_PORT,
    )

