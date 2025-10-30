# PowerShell script to test HannahAI Conversation API
# Make sure the API is running: uvicorn src.api.main:app --reload

$BASE_URL = "http://localhost:8000/api/v1"
$USER_ID = "test-user-123"

Write-Host "======================================" -ForegroundColor Cyan
Write-Host "🚀 Testing HannahAI Conversation API" -ForegroundColor Cyan
Write-Host "======================================" -ForegroundColor Cyan

# 1. Health Check
Write-Host "`n📍 Step 1: Health Check" -ForegroundColor Yellow
$response = Invoke-RestMethod -Uri "$BASE_URL/health" -Method Get
$response | ConvertTo-Json -Depth 10
Write-Host "✅ Health check passed!" -ForegroundColor Green

# 2. Create Conversation
Write-Host "`n📍 Step 2: Create Conversation" -ForegroundColor Yellow
$conversationData = @{
    title = "Test Conversation"
    user_id = $USER_ID
    metadata = @{
        source = "test_script"
        language = "vi"
    }
} | ConvertTo-Json

$conversation = Invoke-RestMethod -Uri "$BASE_URL/conversations" `
    -Method Post `
    -ContentType "application/json" `
    -Body $conversationData

$conversation | ConvertTo-Json -Depth 10
$CONVERSATION_ID = $conversation.data.id
Write-Host "✅ Conversation created: $CONVERSATION_ID" -ForegroundColor Green

# 3. Send First Message
Write-Host "`n📍 Step 3: Send First Message" -ForegroundColor Yellow
$messageData1 = @{
    conversation_id = $CONVERSATION_ID
    content = "Xin chào! Bạn có thể giới thiệu về bản thân không?"
    role = "user"
} | ConvertTo-Json

$result1 = Invoke-RestMethod -Uri "$BASE_URL/messages" `
    -Method Post `
    -ContentType "application/json" `
    -Body $messageData1

Write-Host "`n💬 User: $($result1.data.user_message.content)" -ForegroundColor Cyan
Write[object Object]: $($result1.data.ai_response.content)" -ForegroundColor Green

# 4. Send Second Message
Write-Host "`n📍 Step 4: Send Second Message" -ForegroundColor Yellow
$messageData2 = @{
    conversation_id = $CONVERSATION_ID
    content = "Bạn có thể giúp tôi học Python không?"
    role = "user"
} | ConvertTo-Json

$result2 = Invoke-RestMethod -Uri "$BASE_URL/messages" `
    -Method Post `
    -ContentType "application/json" `
    -Body $messageData2

Write-Host "`n💬 User: $($result2.data.user_message.content)" -ForegroundColor Cyan
Write-Host "🤖 AI: $($result2.data.ai_response.content)" -ForegroundColor Green

# 5. Get Conversation Details
Write-Host "`n📍 Step 5: Get Conversation Details" -ForegroundColor Yellow
$conversationDetails = Invoke-RestMethod -Uri "$BASE_URL/conversations/$CONVERSATION_ID" -Method Get
$conversationDetails | ConvertTo-Json -Depth 10

# 6. List Messages
Write-Host "`n📍 Step 6: List Messages" -ForegroundColor Yellow
$messages = Invoke-RestMethod -Uri "$BASE_URL/messages?conversation_id=$CONVERSATION_ID" -Method Get
Write-Host "Total messages: $($messages.data.Count)" -ForegroundColor Cyan
$messages | ConvertTo-Json -Depth 10

# 7. List Conversations
Write-Host "`n📍 Step 7: List User Conversations" -ForegroundColor Yellow
$conversations = Invoke-RestMethod -Uri "$BASE_URL/conversations?user_id=$USER_ID&page=1&page_size=10" -Method Get
Write-Host "Total conversations: $($conversations.data.Count)" -ForegroundColor Cyan
$conversations | ConvertTo-Json -Depth 10

Write-Host "`n======================================" -ForegroundColor Cyan
Write-Host "✅ All tests completed successfully!" -ForegroundColor Green
Write-Host "======================================" -ForegroundColor Cyan

