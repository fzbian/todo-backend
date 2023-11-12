# todo-backend

TodoList API backend built in .NET and PostgreSQL

## Table of Contents

- [Getting Started](#getting-started)
- [Usage](#usage)
- [Endpoints](#endpoints)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

### Prerequisites

 - PostgreSQL
 - .NET 7.0
 - dotnet-ef

### Installing

Clone the repository
```bash 
$ git clone https://github.com/fzbian/todo-backend
```

Download the packages
```bash
$ dotnet restore
```

Config `appsettings.json` for database connection

```json
"ConnectionStrings": {
    "WebApiDatabase": "Host=host; Database=db; Username=postgres; Password=pass"
}
```

Migrate the database
```bash 
$ dotnet ef migrations add "init"
$ dotnet ef database update
```

Run program
```bash
$ dotnet run
```

## Usage

Use HTTP methods (GET, POST, PUT, DELETE) to interact with the API endpoints.

## Endpoints

### Get all tasks
- **Method:** `GET`
- **Endpoint:** `/api/Todo`
- **Description:** Get all tasks.
- **Response:** `200 OK`

### Get tasks
- **Method:** `GET`
- **Endpoint:** `/api/Todo/GetTasks`
- **Description:** Get tasks.
- **Response:** `200 OK`

### Get task by ID
- **Method:** `GET`
- **Endpoint:** `/api/Todo/GetTasksById/{id}`
- **Description:** Get a task by ID.
- **Parameters:**
  - `id` (Guid): Task ID.
- **Response:** `200 OK`

### Create task
- **Method:** `POST`
- **Endpoint:** `/api/Todo/CreateTask`
- **Description:** Create a new task.
- **Request Body:** Task object in the request body.
- **Response:** `200 OK`

### Update task
- **Method:** `PUT`
- **Endpoint:** `/api/Todo/UpdateTask/{id}`
- **Description:** Update a task by ID.
- **Parameters:**
  - `id` (Guid): Task ID.
- **Request Body:** Updated task object.
- **Response:** `200 OK`

### Check task
- **Method:** `PUT`
- **Endpoint:** `/api/Todo/CheckTask/{id}/{completed}`
- **Description:** Check or uncheck a task.
- **Parameters:**
  - `id` (Guid): Task ID.
  - `completed` (bool): Completion status.
- **Response:** `200 OK` or `500 Internal Server Error` (in case of an exception)

### Delete task
- **Method:** `DELETE`
- **Endpoint:** `/api/Todo/DeleteTask/{id}`
- **Description:** Delete a task by ID.
- **Parameters:**
  - `id` (Guid): Task ID.
- **Response:** `200 OK`


## Contributing

Feel free to contribute to this project.

## License

This project is licensed under the [MIT license] - see the [LICENSE FILE](LICENSE.md) file for details.
