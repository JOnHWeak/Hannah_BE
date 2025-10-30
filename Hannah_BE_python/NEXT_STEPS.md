# Next Steps - Hướng Dẫn Tiếp Theo

## 🎉 Chúc mừng! Codebase đã được tạo thành công!

## 📋 Checklist Bắt Đầu

### 1. ✅ Cài Đặt Dependencies
```bash
# Tạo virtual environment
python -m venv venv

# Kích hoạt virtual environment
# Windows:
venv\Scripts\activate
# Linux/Mac:
source venv/bin/activate

# Cài đặt packages
pip install -r requirements.txt
```

### 2. ✅ Cấu Hình Environment
```bash
# Copy file .env.example
copy .env.example .env  # Windows
# cp .env.example .env  # Linux/Mac

# Mở file .env và cập nhật các giá trị:
# - GEMINI_API_KEY: API key từ Google AI Studio
# - SECRET_KEY: Tạo random string dài ít nhất 32 ký tự
# - JWT_SECRET_KEY: Tạo random string dài ít nhất 32 ký tự
```

**Lấy Gemini API Key:**
1. Truy cập: https://makersuite.google.com/app/apikey
2. Đăng nhập với Google account
3. Tạo API key mới
4. Copy và paste vào file .env

### 3. ✅ Chạy Ứng Dụng
```bash
# Cách 1: Sử dụng uvicorn trực tiếp
uvicorn src.api.main:app --reload --host 0.0.0.0 --port 8000

# Cách 2: Sử dụng script
python scripts/run_dev.py

# Cách 3: Sử dụng VSCode Debug (F5)
# Chọn "Python: FastAPI" trong launch configurations
```

### 4. ✅ Kiểm Tra API
Mở trình duyệt và truy cập:
- **API Documentation**: http://localhost:8000/docs
- **Alternative Docs**: http://localhost:8000/redoc
- **Health Check**: http://localhost:8000/api/v1/health

### 5. ✅ Test API

**Option 1: Sử dụng Python Script**
```bash
python docs/examples/test_api.py
```

**Option 2: Sử dụng PowerShell**
```powershell
.\docs\examples\test_api.ps1
```

**Option 3: Sử dụng Swagger UI**
1. Mở http://localhost:8000/docs
2. Test từng endpoint trực tiếp trên giao diện

**Option 4: Sử dụng Postman/Insomnia**
- Import API từ OpenAPI spec: http://localhost:8000/openapi.json

## 🧪 Chạy Tests

```bash
# Chạy tất cả tests
pytest

# Chạy với coverage
pytest --cov=src

# Chạy tests cụ thể
pytest tests/integration/test_api_health.py

# Chạy với verbose
pytest -v
```

## 🐳 Sử Dụng Docker (Optional)

```bash
# Build và chạy với Docker Compose
docker-compose up --build

# Chạy ở background
docker-compose up -d

# Xem logs
docker-compose logs -f api

# Dừng containers
docker-compose down
```

## 📚 Tài Liệu Tham Khảo

1. **QUICKSTART.md** - Hướng dẫn bắt đầu nhanh
2. **SUMMARY.md** - Tóm tắt dự án
3. **PROJECT_STRUCTURE.md** - Cấu trúc chi tiết
4. **docs/api_reference.md** - Tài liệu API
5. **docs/architecture.md** - Kiến trúc hệ thống

## 🔧 Development Workflow

### Format Code
```bash
# Format với Black
black src/

# Sort imports
isort src/

# Lint với Flake8
flake8 src/

# Type checking
mypy src/
```

### Git Workflow
```bash
# Initialize git (if not already)
git init

# Add files
git add .

# Commit
git commit -m "Initial commit: HannahAI Conversation codebase"

# Add remote (replace with your repo URL)
git remote add origin <your-repo-url>

# Push
git push -u origin main
```

## 🚀 Phát Triển Tiếp

### Phase 1: Test và Hoàn Thiện Core
- [ ] Test tất cả API endpoints
- [ ] Kiểm tra Gemini integration
- [ ] Xử lý edge cases
- [ ] Thêm validation rules

### Phase 2: Database Integration
- [ ] Setup MongoDB
- [ ] Tạo repositories
- [ ] Migration từ in-memory sang MongoDB
- [ ] Thêm indexes

### Phase 3: RAG Implementation
- [ ] Document processing
- [ ] Text chunking
- [ ] Embedding generation
- [ ] Vector search với Elasticsearch

### Phase 4: Studio Tools
- [ ] Quiz generator
- [ ] Mindmap generator
- [ ] Flashcard generator
- [ ] Report generator

### Phase 5: Production Ready
- [ ] Authentication & Authorization
- [ ] Rate limiting
- [ ] Caching
- [ ] Monitoring & Logging
- [ ] Performance optimization

## 💡 Tips

1. **Sử dụng VSCode Extensions:**
   - Python
   - Pylance
   - Black Formatter
   - Docker
   - REST Client

2. **Debug Hiệu Quả:**
   - Sử dụng VSCode debugger (F5)
   - Đặt breakpoints trong code
   - Xem logs trong terminal

3. **API Documentation:**
   - Swagger UI tự động cập nhật khi code thay đổi
   - Thêm docstrings cho functions để docs đầy đủ hơn

4. **Testing:**
   - Viết tests cho mỗi feature mới
   - Maintain test coverage > 80%

## ❓ Troubleshooting

### Lỗi: "ModuleNotFoundError"
```bash
# Đảm bảo đang ở trong virtual environment
# Cài lại dependencies
pip install -r requirements.txt
```

### Lỗi: "Gemini API Error"
```bash
# Kiểm tra GEMINI_API_KEY trong .env
# Kiểm tra API key còn valid
# Kiểm tra quota/limits
```

### Lỗi: "Port already in use"
```bash
# Thay đổi port trong .env hoặc
uvicorn src.api.main:app --reload --port 8001
```

## 📞 Support

Nếu gặp vấn đề:
1. Kiểm tra logs
2. Xem documentation
3. Search trong issues (nếu có repo)
4. Tạo issue mới với thông tin chi tiết

## ✅ Checklist Hoàn Thành

- [ ] Dependencies đã cài đặt
- [ ] File .env đã cấu hình
- [ ] API chạy thành công
- [ ] Health check trả về 200
- [ ] Test script chạy thành công
- [ ] Tạo conversation thành công
- [ ] Gửi message và nhận AI response
- [ ] Đọc hết documentation

---

**Chúc bạn code vui vẻ! 🚀**

