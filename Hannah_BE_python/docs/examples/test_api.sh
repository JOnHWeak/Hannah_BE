#!/bin/bash

# Test script for HannahAI Conversation API using curl
# Make sure the API is running: uvicorn src.api.main:app --reload

BASE_URL="http://localhost:8000/api/v1"
USER_ID="test-user-123"

echo "======================================"
echo "🚀 Testing HannahAI Conversation API"
echo "======================================"

# 1. Health Check
echo -e "\n📍 Step 1: Health Check"
curl -X GET "$BASE_URL/health" | json_pp

# 2. Create Conversation
echo -e "\n📍 Step 2: Create Conversation"
CONVERSATION_RESPONSE=$(curl -s -X POST "$BASE_URL/conversations" \
  -H "Content-Type: application/json" \
  -d "{
    \"title\": \"Test Conversation\",
    \"user_id\": \"$USER_ID\",
    \"metadata\": {\"source\": \"test_script\"}
  }")

echo $CONVERSATION_RESPONSE | json_pp

# Extract conversation ID (requires jq)
CONVERSATION_ID=$(echo $CONVERSATION_RESPONSE | jq -r '.data.id')
echo "✅ Conversation ID: $CONVERSATION_ID"

# 3. Send First Message
echo -e "\n📍 Step 3: Send First Message"
curl -X POST "$BASE_URL/messages" \
  -H "Content-Type: application/json" \
  -d "{
    \"conversation_id\": \"$CONVERSATION_ID\",
    \"content\": \"Xin chào! Bạn có thể giới thiệu về bản thân không?\",
    \"role\": \"user\"
  }" | json_pp

# 4. Send Second Message
echo -e "\n📍 Step 4: Send Second Message"
curl -X POST "$BASE_URL/messages" \
  -H "Content-Type: application/json" \
  -d "{
    \"conversation_id\": \"$CONVERSATION_ID\",
    \"content\": \"Bạn có thể giúp tôi học Python không?\",
    \"role\": \"user\"
  }" | json_pp

# 5. Get Conversation
echo -e "\n📍 Step 5: Get Conversation Details"
curl -X GET "$BASE_URL/conversations/$CONVERSATION_ID" | json_pp

# 6. List Messages
echo -e "\n📍 Step 6: List Messages"
curl -X GET "$BASE_URL/messages?conversation_id=$CONVERSATION_ID" | json_pp

# 7. List Conversations
echo -e "\n📍 Step 7: List User Conversations"
curl -X GET "$BASE_URL/conversations?user_id=$USER_ID&page=1&page_size=10" | json_pp

echo -e "\n======================================"
echo "✅ All tests completed!"
echo "======================================"

