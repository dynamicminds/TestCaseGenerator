using Xunit;
namespace UnitTestGenerator
{
    public class TestMethods
    {
        [Fact]
        public void CreateEventTest()
        {
            // Arrange
            // Act
             result = CreateEvent([FromBody] CreateEventDto eventToCreate);
            // Assert
        }
    }
        [Fact]
        public void UpdateEventTest()
        {
            // Arrange
            // Act
             result = UpdateEvent([FromBody] CreateEventDto eventToUpdate);
            // Assert
        }
    }
        [Fact]
        public void GetAllActiveFutureEventsTest()
        {
            // Arrange
            // Act
             result = GetAllActiveFutureEvents();
            // Assert
        }
    }
        [Fact]
        public void GetEventTest()
        {
            // Arrange
            // Act
             result = GetEvent(string eventId);
            // Assert
        }
    }
        [Fact]
        public void GetEventRegistrantEmailsTest()
        {
            // Arrange
            // Act
             result = GetEventRegistrantEmails(string eventId);
            // Assert
        }
    }
        [Fact]
        public void GetEventRegistrantsTest()
        {
            // Arrange
            // Act
             result = GetEventRegistrants(string eventId);
            // Assert
        }
    }
        [Fact]
        public void CancelEventTest()
        {
            // Arrange
            // Act
             result = CancelEvent(string eventId);
            // Assert
        }
    }
}


