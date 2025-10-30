import uuid
from fastapi.testclient import TestClient

def test_conversation_flow(test_client: TestClient):
    """Tests the full end-to-end flow of creating a conversation and sending a message."""
    # 1. Create a conversation
    user_id = "test-user-123"
    response = test_client.post(
        "/api/conversations",
        json={"user_id": user_id, "title": "My Test Conversation"},
    )
    assert response.status_code == 200
    conversation_data = response.json()["data"]
    conversation_id = conversation_data["id"]
    assert conversation_data["title"] == "My Test Conversation"

    # 2. Get the conversation to verify it was created
    response = test_client.get(f"/api/conversations/{conversation_id}")
    assert response.status_code == 200
    assert response.json()["data"]["id"] == conversation_id

    # 3. Send a message
    response = test_client.post(
        "/api/messages",
        json={"conversation_id": conversation_id, "content": "Hello, world!"},
    )
    assert response.status_code == 200
    message_data = response.json()["data"]
    assert message_data["user_message"]["content"] == "Hello, world!"
    assert message_data["ai_response"]["content"] is not None

    # 4. Get the conversation again to verify the messages were added
    response = test_client.get(f"/api/conversations/{conversation_id}")
    assert response.status_code == 200
    updated_conversation_data = response.json()["data"]
    assert len(updated_conversation_data["messages"]) == 2

