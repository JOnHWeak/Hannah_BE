from fastapi.middleware.cors import CORSMiddleware

def add_cors_middleware(app):
    """Adds CORS middleware to the FastAPI application."""
    app.add_middleware(
        CORSMiddleware,
        allow_origins=["*"],  # In production, restrict this to your frontend's domain
        allow_credentials=True,
        allow_methods=["*"],
        allow_headers=["*"],
    )

