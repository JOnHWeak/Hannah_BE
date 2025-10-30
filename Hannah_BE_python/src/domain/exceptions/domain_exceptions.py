class DomainException(Exception):
    """Base exception for domain errors."""
    pass

class EntityNotFoundException(DomainException):
    """Raised when an entity is not found."""
    pass

class InvalidArgumentException(DomainException):
    """Raised when an argument is invalid."""
    pass

