# HannahAI.Conversation - Project Summary

## 📋 Tổng Quan Dự Án

**HannahAI.Conversation** là một dịch vụ AI-powered conversation service được xây dựng bằng Python và FastAPI, tích hợp Google Gemini API để tạo các cuộc hội thoại thông minh.

## 🎯 Tính Năng Chính

### ✅ Đã Hoàn Thành
1. **Quản lý Hội thoại (Conversations)**
   - Tạo, xem, cập nhật, xóa hội thoại
   - Lưu trữ in-memory (sẵn sàng chuyển sang MongoDB)

2. **Xử lý Tin nhắn (Messages)**
   - Gửi tin nhắn và nhận phản hồi AI tự động
   - Lưu trữ lịch sử hội thoại
   - Hỗ trợ context từ các tin nhắn trước

3. **Tích hợp AI (Google Gemini)**
   - Google Gemini API client
   - AI Orchestrator để điều phối các tác vụ AI
   - Hỗ trợ conversation history
   - Tùy chỉnh temperature và max_tokens

4. **RESTful API**
   - FastAPI framework
   - Auto-generated API documentation (Swagger/ReDoc)
   - Error handling middleware
   - CORS support

5. **Infrastructure**
   - Docker & Docker Compose
   - Structured logging
   - Configuration management
   - Testing framework (Pytest)

### 🚧 Sẽ Phát Triển
- MongoDB integration
- Elasticsearch cho document search
- RAG (Retrieval-Augmented Generation)
- Studio tools (Quiz, Mindmap, Flashcard, Report)
- Document processing
- Authentication & Authorization

## 🛠️ Tech Stack

- **Language**: Python 3.11+
- **Framework**: FastAPI
- **AI Provider**: Google Gemini API
- **Validation**: Pydantic
- **Logging**: Structlog
- **Testing**: Pytest
- **Container**: Docker

## 📁 Cấu Trúc Chính

```
src/
├── api/              # API routes và middleware
├── core/             # Configuration, logging, security
├── models/           # Data models và schemas
├── services/         # Business logic
│   ├── ai_engine/    # AI orchestrator và Gemini client
│   └── studio/       # Studio tools (future)
├── database/         # Database layer (future)
└── utils/            # Utilities
```

## 🚀 Cách Chạy

### 1. Cài đặt
```bash
# Tạo virtual environment
python -m venv venv
venv\Scripts\activate  # Windows

# Cài đặt dependencies
pip install -r requirements.txt
```

### 2. Cấu hình
```bash
# Copy file .env
copy .env.example .env

# Chỉnh sửa .env và thêm GEMINI_API_KEY
GEMINI_API_KEY=your-api-key-here
```

### 3. Chạy ứng dụng
```bash
uvicorn src.api.main:app --reload
```

### 4. Truy cập
- API Docs: http://localhost:8000/docs
- Health Check: http://localhost:8000/api/v1/health

## 📝 API Endpoints

### Health
- `GET /api/v1/health` - Health check

### Conversations
- `POST /api/v1/conversations` - Tạo hội thoại
- `GET /api/v1/conversations/{id}` - Xem hội thoại
- `GET /api/v1/conversations?user_id=xxx` - Danh sách hội thoại
- `PUT /api/v1/conversations/{id}` - Cập nhật hội thoại
- `DELETE /api/v1/conversations/{id}` - Xóa hội thoại

### Messages
- `POST /api/v1/messages` - Gửi tin nhắn và nhận AI response
- `GET /api/v1/messages/{id}` - Xem tin nhắn
- `GET /api/v1/messages?conversation_id=xxx` - Danh sách tin nhắn

## 💡 Ví dụ Sử dụng

### Tạo hội thoại và gửi tin nhắn

```python
import requests

base_url = "http://localhost:8000/api/v1"

# 1. Tạo conversation
response = requests.post(
    f"{base_url}/conversations",
    json={"title": "Chat với Hannah", "user_id": "user-123"}
)
conversation_id = response.json()["data"]["id"]

# 2. Gửi tin nhắn
response = requests.post(
    f"{base_url}/messages",
    json={
        "conversation_id": conversation_id,
        "content": "Xin chào! Bạn có thể giúp tôi học Python không?",
        "role": "user"
    }
)

result = response.json()["data"]
print("User:", result["user_message"]["content"])
print("AI:", result["ai_response"]["content"])
```

## 📚 Tài Liệu

- **README.md**: Tổng quan dự án
- **QUICKSTART.md**: Hướng dẫn bắt đầu nhanh
- **PROJECT_STRUCTURE.md**: Cấu trúc chi tiết dự án
- **docs/api_reference.md**: Tài liệu API
- **docs/architecture.md**: Kiến trúc hệ thống

## 🔑 Điểm Nổi Bật

1. **Sẵn sàng Production**: Cấu trúc rõ ràng, dễ mở rộng
2. **AI-Powered**: Tích hợp Google Gemini API
3. **Flexible Storage**: Hiện tại in-memory, dễ dàng chuyển sang MongoDB
4. **Well-Documented**: API docs tự động, tài liệu đầy đủ
5. **Docker Ready**: Dễ dàng deploy với Docker
6. **Extensible**: Cấu trúc module hóa, dễ thêm tính năng

##[object Object]
### Phase 1 (Completed) ✅
- [x] Project setup
- [x] Core API endpoints
- [x] Gemini integration
- [x] Basic conversation management

### Phase 2 (Next)
- [ ] MongoDB integration
- [ ] Document processing
- [ ] RAG implementation
- [ ] Authentication

### Phase 3 (Future)
- [ ] Studio tools
- [ ] Advanced AI agents
- [ ] Elasticsearch integration
- [ ] Performance optimization

## 👥 Development Team

HannahAI Development Team

## 📄 License

Proprietary - HannahAI Team

---

**Status**: ✅ Core features completed and ready for testing
**Version**: 1.0.0
**Last Updated**: 2024

