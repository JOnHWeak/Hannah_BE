import pytest
from fastapi.testclient import TestClient

from src.api.main import create_app

@pytest.fixture(scope="module")
def test_client():
    """Provides a test client for the FastAPI application."""
    app = create_app()
    with TestClient(app) as client:
        yield client

