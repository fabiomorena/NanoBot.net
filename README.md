# nanobot.NET

**nanobot.NET** is a .NET 10 port of the [nanobot](https://github.com/HKUDS/nanobot) project. It's an ultra-lightweight personal AI assistant provided as a DLL with core functionality and a full-featured CLI tool.

## 🚀 Features

*   **Ultra-lightweight**: Maintains the streamlined architecture of the original project
*   **Multi-model support**: Perfect support for OpenAI, OpenRouter, and compatible APIs via OpenAI SDK
*   **Powerful tool system**: Built-in tools for filesystem, shell execution, web search (Brave), web scraping, weather forecasts, and more
*   **Memory system**: File-based persistent memory
*   **Multi-channel support**: Interact via Telegram bot
*   **Automation**: Support for Cron scheduled tasks and Heartbeat proactive wake-up

## 🛠️ Installation & Usage

### 1. Initialize
```bash
dotnet run --project Nanobot.CLI onboard
```

This creates configuration files and workspace in the `~/.nanobot` directory.

### 2. Configuration

Edit `~/.nanobot/config.json` and add your API keys:
```json
{
  "providers": {
    "openai": {
      "apiKey": "YOUR_OPENAI_KEY"
    },
    "webSearch": {
      "apiKey": "YOUR_BRAVE_SEARCH_KEY"
    }
  }
}
```

### 3. Usage

*   **Chat**:
```bash
    dotnet run --project Nanobot.CLI agent -m "Hello"
```
*   **Start Gateway (Telegram)**:
```bash
    dotnet run --project Nanobot.CLI gateway
```
*   **Manage Scheduled Tasks**:
```bash
    dotnet run --project Nanobot.CLI cron list
```

## 🏗️ Project Structure

*   `Nanobot.Core`: Core logic library containing LLM providers, tool registry, memory system, etc.
*   `Nanobot.CLI`: Command-line interface tool
*   `Nanobot.Tests`: Unit test project

## 📄 License

This project is licensed under the MIT License.
