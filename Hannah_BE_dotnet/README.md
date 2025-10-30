# Hannah AI - Management & Analytics System

Đây là hệ thống quản lý và phân tích dữ liệu có cấu trúc cho Trợ lý Học tập Hannah AI. Dự án được xây dựng bằng ASP.NET Core 8.0 theo kiến trúc Modular Monolithic và các nguyên tắc của Clean Architecture.

## Kiến trúc (Architecture)

Dự án tuân theo Clean Architecture, chia thành các lớp (layers) với các trách nhiệm rõ ràng:

- **Domain**: Lớp trung tâm, chứa các business logic cốt lõi, entities, và không phụ thuộc vào bất kỳ lớp nào khác.
- **Application**: Chứa logic nghiệp vụ của ứng dụng (use cases), điều phối dữ liệu giữa Domain và Infrastructure. Lớp này phụ thuộc vào Domain.
- **Infrastructure**: Cung cấp các triển khai cụ thể cho các interface được định nghĩa ở lớp Application (ví dụ: truy cập database, dịch vụ bên ngoài). Lớp này phụ thuộc vào Application.
- **Api**: Lớp ngoài cùng, là điểm vào của ứng dụng (entry point), xử lý các request HTTP và trả về response. Lớp này phụ thuộc vào Application và Infrastructure.

Sự phụ thuộc luôn hướng vào trong: `Api` -> `Infrastructure` -> `Application` -> `Domain`.

## Vai trò của từng Module (Project)

- **`HannahAI.Domain`**: 
  - **Vai trò**: Trái tim của ứng dụng. Chứa các quy tắc nghiệp vụ quan trọng nhất.
  - **Thành phần**: 
    - `Entities`: Các đối tượng nghiệp vụ (ví dụ: `User`, `Subject`, `Quiz`).
    - `Enums`: Các kiểu liệt kê dùng chung trong toàn bộ domain.
    - `Exceptions`: Các exception nghiệp vụ tùy chỉnh.

- **`HannahAI.Application`**: 
  - **Vai trò**: Điều phối luồng dữ liệu và thực thi các yêu cầu nghiệp vụ. Lớp này định nghĩa các *use case* của hệ thống.
  - **Thành phần**: 
    - `Features`: Tổ chức code theo chức năng (ví dụ: `Auth`, `Users`, `Subjects`). Mỗi feature chứa các `Commands` (thay đổi dữ liệu), `Queries` (truy vấn dữ liệu), và `DTOs` (Data Transfer Objects).
    - `Common/Interfaces`: Các hợp đồng (interfaces) mà lớp Infrastructure sẽ triển khai (ví dụ: `IRepository`, `IUnitOfWork`).
    - `Common/Behaviors`: Các pipeline behavior cho MediatR (ví dụ: logging, validation).

- **`HannahAI.Infrastructure`**: 
  - **Vai trò**: Cung cấp các chi tiết kỹ thuật "làm thế nào" để thực hiện các yêu cầu từ lớp Application.
  - **Thành phần**: 
    - `Data`: Chứa `DbContext`, `Repositories` (triển khai `IRepository`), `Configurations` (cấu hình Entity Framework Core), và `Migrations`.
    - `Identity`: Chứa các dịch vụ liên quan đến xác thực và ủy quyền như tạo token JWT, hash mật khẩu.
    - `Services`: Các dịch vụ kỹ thuật khác như `FileStorageService`, `DateTimeService`.

- **`HannahAI.Api`**: 
  - **Vai trò**: Giao tiếp với thế giới bên ngoài qua HTTP. Đây là lớp trình bày (Presentation Layer).
  - **Thành phần**: 
    - `Controllers`: Các API endpoints, nhận request, gọi vào MediatR (lớp Application) và trả về response.
    - `Middleware`: Các thành phần xử lý trung gian cho pipeline request (ví dụ: xử lý lỗi, logging).
    - `Extensions`: Các extension method để đăng ký dịch vụ (Dependency Injection).
    - `Program.cs`: Điểm khởi tạo và cấu hình của ứng dụng.

- **`HannahAI.Shared`**: 
  - **Vai trò**: Chứa các code tiện ích, hằng số, hoặc extension method có thể được sử dụng bởi nhiều project khác nhau mà không tạo ra sự phụ thuộc không mong muốn.

- **`tests/`**: 
  - **Vai trò**: Chứa các project để kiểm thử đơn vị (`UnitTests`) và kiểm thử tích hợp (`IntegrationTests`).

## Luồng hoạt động của một Request (Request Flow)

Ví dụ luồng tạo một người dùng mới (`POST /api/users`):

1.  **`Api (Controller)`**: `UsersController` nhận một HTTP POST request với dữ liệu người dùng.
2.  **`Api -> Application`**: Controller tạo một `CreateUserCommand` (từ MediatR) và gửi nó đi.
3.  **`Application (Handler)`**: `CreateUserCommandHandler` nhận command này.
4.  **`Application -> Domain`**: Handler có thể thực thi các logic trên các domain entities (ví dụ: kiểm tra tính hợp lệ).
5.  **`Application -> Infrastructure`**: Handler gọi `IRepository<User>` và `IPasswordHasher` (do Infrastructure triển khai) để hash mật khẩu và lưu `User` entity vào database.
6.  **`Infrastructure (Repository)`**: `UserRepository` sử dụng `DbContext` để thực sự ghi dữ liệu xuống SQL Server.
7.  **`Infrastructure -> Database`**: Entity Framework Core chuyển đổi entity thành câu lệnh SQL và thực thi.
8.  **Quay trở lại**: Dữ liệu (dưới dạng `UserDto`) được trả ngược lại qua các lớp và `UsersController` trả về một HTTP 201 Created response.

## Cách chạy dự án

1.  **Cấu hình Database**: 
    - Mở file `src/HannahAI.Api/appsettings.Development.json`.
    - Cập nhật chuỗi kết nối `DefaultConnection` để trỏ tới SQL Server của bạn.

2.  **Tạo Database (Migrations)**:
    - Mở terminal tại thư mục gốc của project.
    - Chạy lệnh sau để tạo migration:
      ```sh
      dotnet ef migrations add InitialCreate --startup-project src/HannahAI.Api --project src/HannahAI.Infrastructure
      ```
    - Chạy lệnh sau để áp dụng migration vào database:
      ```sh
      dotnet ef database update --startup-project src/HannahAI.Api --project src/HannahAI.Infrastructure
      ```

3.  **Chạy API**:
    - Chạy project `HannahAI.Api` từ IDE của bạn hoặc bằng lệnh:
      ```sh
      dotnet run --project src/HannahAI.Api
      ```

4.  **Truy cập Swagger UI**:
    - Mở trình duyệt và truy cập vào `https://localhost:<port>/swagger` (port sẽ được hiển thị trong terminal khi bạn chạy dự án).
