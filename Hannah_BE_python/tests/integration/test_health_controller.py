from fastapi.testclient import TestClient

def test_health_check(test_client: TestClient):
    """Tests that the health check endpoint returns a 200 OK status."""
    response = test_client.get("/api/health")
    assert response.status_code == 200
    assert response.json() == {"status": "ok"}

