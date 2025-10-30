# API Reference

## Base URL
```
http://localhost:8000/api/v1
```

## Authentication
Currently, authentication is not implemented. It will be added in future versions.

## Endpoints

### Health Check

#### GET /health
Check if the API is running.

**Response:**
```json
{
  "status": "healthy",
  "app_name": "HannahAI.Conversation",
  "version": "1.0.0",
  "environment": "development",
  "timestamp": "2024-01-01T00:00:00"
}
```

### Conversations

#### POST /conversations
Create a new conversation.

**Request Body:**
```json
{
  "title": "My Conversation",
  "user_id": "user-123",
  "metadata": {}
}
```

**Response:**
```json
{
  "success": true,
  "message": "Conversation created successfully",
  "data": {
    "id": "conv-uuid",
    "title": "My Conversation",
    "user_id": "user-123",
    "created_at": "2024-01-01T00:00:00",
    "updated_at": "2024-01-01T00:00:00",
    "message_count": 0,
    "last_message": null,
    "metadata": {}
  }
}
```

#### GET /conversations/{conversation_id}
Get a conversation by ID.

#### GET /conversations?user_id={user_id}&page=1&page_size=20
List conversations for a user.

#### PUT /conversations/{conversation_id}
Update a conversation.

#### DELETE /conversations/{conversation_id}
Delete a conversation.

### Messages

#### POST /messages
Send a message and get AI response.

**Request Body:**
```json
{
  "conversation_id": "conv-uuid",
  "content": "Hello, how are you?",
  "role": "user",
  "metadata": {}
}
```

**Query Parameters:**
- `use_rag` (boolean): Use RAG for response (default: false)
- `temperature` (float): AI temperature 0.0-2.0 (default: 0.7)

**Response:**
```json
{
  "success": true,
  "message": "Message sent and response generated",
  "data": {
    "user_message": {
      "id": "msg-uuid-1",
      "conversation_id": "conv-uuid",
      "content": "Hello, how are you?",
      "role": "user",
      "created_at": "2024-01-01T00:00:00",
      "metadata": {}
    },
    "ai_response": {
      "id": "msg-uuid-2",
      "conversation_id": "conv-uuid",
      "content": "I'm doing well, thank you!",
      "role": "assistant",
      "response_type": "text",
      "created_at": "2024-01-01T00:00:01",
      "metadata": {
        "model": "gemini-pro",
        "tokens_used": 50
      }
    }
  }
}
```

#### GET /messages?conversation_id={conversation_id}&page=1&page_size=50
List messages in a conversation.

#### GET /messages/{message_id}
Get a message by ID.

## Error Responses

All error responses follow this format:

```json
{
  "success": false,
  "message": "Error message",
  "error_code": "ERROR_CODE",
  "details": {}
}
```

### Common Error Codes
- `404`: Resource not found
- `422`: Validation error
- `500`: Internal server error

