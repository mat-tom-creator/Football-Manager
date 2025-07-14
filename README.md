# Football Manager

A C# desktop application for managing football-related data including teams, players, fixtures, live matches, and fan interactions.

## Project Structure

This solution consists of two main projects:

### FootballManager.Core
The core business logic layer containing services, models, and interfaces.

**Key Components:**
- **Services**: Business logic for managing teams, players, fixtures, leagues, live matches, news, videos, search, and fan interactions
- **Models**: Data models for football entities (Team, Player, Match, Fixture, etc.)
- **Interfaces**: Service contracts and abstractions
- **Decorators**: Cross-cutting concerns (caching, logging, performance monitoring, retry logic)
- **Factories**: Object creation and dependency injection

### FootballManager.UI
Windows Forms desktop application providing the user interface.

**Key Components:**
- **Adapters**: Bridge between UI and core services
- **Controls**: Custom UI controls and theme management
- **Forms**: Login and main application forms
- **Factories**: UI component creation

## Features

### Core Features
- **Team Management**: Create, update, and manage football teams
- **Player Management**: Handle player information and statistics
- **Fixture Management**: Schedule and manage upcoming matches
- **Live Match Tracking**: Real-time match updates and scoring
- **League Management**: Handle league tables and standings
- **News System**: Personalized and trending football news
- **Video Content**: Match highlights and full replay videos
- **Search Functionality**: Search across teams, players, and matches
- **User Authentication**: Secure user login and session management

### Fan Interaction Features
- **Polls**: Create and participate in fan polls
- **Trivia**: Football trivia games and questions

### Technical Features
- **Caching**: Improved performance through data caching
- **Logging**: Comprehensive application logging
- **Performance Monitoring**: Track service performance metrics
- **Retry Logic**: Automatic retry for failed operations
- **Decorator Pattern**: Clean separation of cross-cutting concerns

## Architecture

The application follows a layered architecture with clear separation of concerns:

1. **UI Layer** (FootballManager.UI): Windows Forms interface
2. **Adapter Layer**: Translates between UI and business logic
3. **Service Layer**: Core business logic and operations
4. **Model Layer**: Data entities and domain objects

### Design Patterns Used
- **Decorator Pattern**: For cross-cutting concerns (logging, caching, performance)
- **Factory Pattern**: For object creation and dependency management
- **Adapter Pattern**: For UI-to-service communication
- **Service Layer Pattern**: For business logic organization
