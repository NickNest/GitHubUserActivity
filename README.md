# GitHub User Activity

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Tests](https://img.shields.io/badge/tests-NUnit-25A162)](#run-tests)
[![Project](https://img.shields.io/badge/roadmap.sh-GitHub%20User%20Activity-000000)](https://roadmap.sh/projects/github-user-activity)

## Table of Contents

- [English](#english)
  - [Features](#features)
  - [Tech Stack](#tech-stack)
  - [Requirements](#requirements)
  - [Run](#run)
  - [Example Output](#example-output)
  - [Run Tests](#run-tests)
  - [Notes](#notes)
- [Русский](#русский)
  - [Возможности](#возможности)
  - [Технологии](#технологии)
  - [Требования](#требования)
  - [Запуск](#запуск)
  - [Пример вывода](#пример-вывода)
  - [Запуск тестов](#запуск-тестов)
  - [Примечания](#примечания)

## English

Console application that fetches and displays recent public GitHub activity for a user.

This project is based on the roadmap.sh backend task:
https://roadmap.sh/projects/github-user-activity

### Features

- Fetches public events from `https://api.github.com/users/<username>/events`
- Groups similar events and shows them in a readable summary
- Handles multiple common GitHub event types (pushes, pull requests, issues, stars, forks, etc.)
- Includes automated tests

### Tech Stack

- C#
- .NET 9
- `System.CommandLine`
- `Microsoft.Extensions.Http`
- `Newtonsoft.Json`
- NUnit (tests)

### Requirements

- .NET SDK 9.0 or newer

### Run

From repository root:

```bash
dotnet run --project GitHubUserActivity -- <github-username>
```

Example:

```bash
dotnet run --project GitHubUserActivity -- torvalds
```

### Example Output

```text
- pushed 3 commit(s) to owner/repo
- opened a pull request 1 times in owner/repo
- commented on an issue 2 times in owner/repo
```

If username is missing, the app prints:

```text
Usage: GitHubUserActivity <github-username>
```

### Run Tests

```bash
dotnet test
```

### Notes

- The app uses GitHub public events API, so only public activity is shown.
- GitHub API rate limits may apply for unauthenticated requests.

---

## Русский

Консольное приложение, которое получает и показывает недавнюю публичную активность пользователя GitHub.

Проект выполнен по заданию roadmap.sh:
https://roadmap.sh/projects/github-user-activity

### Возможности

- Получает публичные события из `https://api.github.com/users/<username>/events`
- Группирует похожие события и выводит их в удобном виде
- Поддерживает основные типы GitHub-событий (push, pull request, issue, star, fork и другие)
- Содержит автоматические тесты

### Технологии

- C#
- .NET 9
- `System.CommandLine`
- `Microsoft.Extensions.Http`
- `Newtonsoft.Json`
- NUnit (тесты)

### Требования

- .NET SDK 9.0 или новее

### Запуск

Из корня репозитория:

```bash
dotnet run --project GitHubUserActivity -- <github-username>
```

Пример:

```bash
dotnet run --project GitHubUserActivity -- torvalds
```

### Пример вывода

```text
- pushed 3 commit(s) to owner/repo
- opened a pull request 1 times in owner/repo
- commented on an issue 2 times in owner/repo
```

Если имя пользователя не передано, приложение выводит:

```text
Usage: GitHubUserActivity <github-username>
```

### Запуск тестов

```bash
dotnet test
```

### Примечания

- Приложение использует публичный GitHub API, поэтому отображается только публичная активность.
- Для неаутентифицированных запросов действуют ограничения GitHub API (rate limit).
