# Quick Start Guide (v2.0)

This guide will help you get the HannahAI Conversation service up and running.

## Prerequisites

- Python 3.11 or higher
- pip
- Google Gemini API Key

## Installation

1.  **Clone the repository** (if you haven't already).

2.  **Create and activate a virtual environment:**

    ```bash
    # Create the environment
    python -m venv venv

    # Activate on Windows
    .\venv\Scripts\activate

    # Activate on macOS/Linux
    source venv/bin/activate
    ```

3.  **Install dependencies:**

    ```bash
    pip install -r requirements.txt
    ```

4.  **Configure environment variables:**

    ```bash
    # Copy the example file
    cp .env.example .env

    # Edit the .env file and add your Google Gemini API key
    GEMINI_API_KEY=your-api-key-here
    ```

## Running the Application

Run the application with `uvicorn`:

```bash
uvicorn src.api.main:app --reload
```

The API will be available at `http://localhost:8000`.

## Accessing the API

- **API Documentation (Swagger)**: `http://localhost:8000/docs`
- **Health Check**: `http://localhost:8000/api/health`

## Quick Test with Python

```python
import requests

BASE_URL = "http://localhost:8000/api"

def main():
    # 1. Create a conversation
    print("Creating conversation...")
    response = requests.post(
        f"{BASE_URL}/conversations",
        json={"user_id": "test-user-123", "title": "My Test"}
    )
    conversation_data = response.json()["data"]
    conversation_id = conversation_data["id"]
    print(f"Conversation created with ID: {conversation_id}")

    # 2. Send a message
    print("Sending message...")
    response = requests.post(
        f"{BASE_URL}/messages",
        json={"conversation_id": conversation_id, "content": "Hello, AI!"}
    )
    message_data = response.json()["data"]
    print(f"User: {message_data['user_message']['content']}")
    print(f"AI: {message_data['ai_response']['content']}")

if __name__ == "__main__":
    main()
```

## Running Tests

To run the full test suite (unit and integration), use `pytest`:

```bash
pytest -v
```

## Troubleshooting

- **ModuleNotFoundError**: Ensure your virtual environment is activated and you have run `pip install -r requirements.txt`.
- **Gemini API Error**: Double-check that your `GEMINI_API_KEY` is correctly set in the `.env` file.
- **Port already in use**: Stop the process using the port or run on a different one with `uvicorn src.api.main:app --reload --port 8001`.
