from enum import Enum

class MessageRole(str, Enum):
    """Enumeration for the role of a message's author."""
    USER = "user"
    ASSISTANT = "assistant"
    SYSTEM = "system"

