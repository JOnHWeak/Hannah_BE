"""
Example script to test HannahAI Conversation API

Make sure the API is running before executing this script:
    uvicorn src.api.main:app --reload
"""

import requests
import json
from typing import Dict, Any


BASE_URL = "http://localhost:8000/api/v1"


def print_response(title: str, response: requests.Response):
    """Pretty print API response"""
    print(f"\n{'='*60}")
    print(f"📌 {title}")
    print(f"{'='*60}")
    print(f"Status Code: {response.status_code}")
    print(f"Response:")
    print(json.dumps(response.json(), indent=2, ensure_ascii=False))


def test_health_check():
    """Test health check endpoint"""
    response = requests.get(f"{BASE_URL}/health")
    print_response("Health Check", response)
    return response.status_code == 200


def test_create_conversation(user_id: str) -> str:
    """Test creating a conversation"""
    data = {
        "title": "Test Conversation with Hannah",
        "user_id": user_id,
        "metadata": {
            "source": "test_script",
            "language": "vi"
        }
    }
    
    response = requests.post(f"{BASE_URL}/conversations", json=data)
    print_response("Create Conversation", response)
    
    if response.status_code == 200:
        return response.json()["data"]["id"]
    return None


def test_send_message(conversation_id: str, content: str, use_rag: bool = False):
    """Test sending a message"""
    data = {
        "conversation_id": conversation_id,
        "content": content,
        "role": "user"
    }
    
    params = {"use_rag": use_rag}
    
    response = requests.post(
        f"{BASE_URL}/messages",
        json=data,
        params=params
    )
    print_response(f"Send Message: '{content[:50]}...'", response)
    
    return response.json() if response.status_code == 200 else None


def test_get_conversation(conversation_id: str):
    """Test getting a conversation"""
    response = requests.get(f"{BASE_URL}/conversations/{conversation_id}")
    print_response("Get Conversation", response)
    return response.json() if response.status_code == 200 else None


def test_list_messages(conversation_id: str):
    """Test listing messages"""
    params = {"conversation_id": conversation_id}
    response = requests.get(f"{BASE_URL}/messages", params=params)
    print_response("List Messages", response)
    return response.json() if response.status_code == 200 else None


def test_list_conversations(user_id: str):
    """Test listing conversations"""
    params = {"user_id": user_id, "page": 1, "page_size": 10}
    response = requests.get(f"{BASE_URL}/conversations", params=params)
    print_response("List Conversations", response)
    return response.json() if response.status_code == 200 else None


def main():
    """Main test flow"""
    print("\n" + "="*60)
    print("🚀 Testing HannahAI Conversation API")
    print("="*60)
    
    # Test user ID
    user_id = "test-user-123"
    
    try:
        # 1. Health check
        print("\n📍 Step 1: Health Check")
        if not test_health_check():
            print("❌ Health check failed!")
            return
        print("✅ Health check passed!")
        
        # 2.[object Object]")
        conversation_id = test_create_conversation(user_id)
        if not conversation_id:
            print("❌ Failed to create conversation!")
            return
        print(f"✅ Conversation created: {conversation_id}")
        
        # 3. Send first message
        print("\n📍 Step 3: Send First Message")
        result = test_send_message(
            conversation_id,
            "Xin chào! Bạn có thể giới thiệu về bản thân không?"
        )
        if result:
            print("✅ Message sent successfully!")
            print(f"\n💬 User: {result['data']['user_message']['content']}")
            print(f"🤖 AI: {result['data']['ai_response']['content']}")
        
        # 4. Send second message
        print("\n📍 Step 4: Send Second Message")
        result = test_send_message(
            conversation_id,
            "Bạn có thể giúp tôi học Python không?"
        )
        if result:
            print("✅ Message sent successfully!")
            print(f"\n💬 User: {result['data']['user_message']['content']}")
            print(f"🤖 AI: {result['data']['ai_response']['content']}")
        
        # 5. Get conversation details
        print("\n📍 Step 5: Get Conversation Details")
        test_get_conversation(conversation_id)
        
        # 6. List all[object Object] Step 6: List All Messages")
        test_list_messages(conversation_id)
        
        # 7. List user conversations
        print("\n📍 Step 7: List User Conversations")
        test_list_conversations(user_id)
        
        print("\n" + "="*60)
        print("✅ All tests completed successfully!")
        print("="*60)
        
    except requests.exceptions.ConnectionError:
        print("\n❌ Error: Cannot connect to API!")
        print("Make sure the API is running:")
        print("    uvicorn src.api.main:app --reload")
    except Exception as e:
        print(f"\n❌ Error: {str(e)}")


if __name__ == "__main__":
    main()

