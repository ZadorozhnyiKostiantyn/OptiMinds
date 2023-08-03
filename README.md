
# OptiMinds

### MySQL

You can read the MySql installation guides at this links -

**Windows** - https://www.freecodecamp.org/news/how-to-install-mysql-workbench-on-windows/

**Linux** - https://dev.mysql.com/doc/workbench/en/wb-linux.html

**Mac** - https://dev.mysql.com/doc/workbench/en/wb-mac.html

### Run Locally

Clone the project

```bash
git clone https://github.com/ZadorozhnyiKostiantyn/OptiMinds.git
```

Go to the project directory

```bash
cd OptiMinds
```

Install dependencies

```bash
dotnet restore
```

Change the settings according to your appsettings.json server settings

*HOSTNAME* - Name or IP address of the server host.

*DATABASE_NAME* - The name of your database that you need to connect or deploy.

*YOUR_USERNAME* - Your username, which you entered when registering in MySql Workbench(Usually "root").

*YOUR_PASSWORD* - Your password, which you entered when registering in MySql Workbench.

```json
"ConnectionStrings": {
    "MySqlConnection": "Server=HOSTNAME;Database=DATABASE_NAME;User=YOUR_USERNAME;Password=YOUR_PASSWORD;"
  },
```

Start the server

```bash
dotnet build
dotnet watch run --project .\OptiMinds.Api\
```
## API Reference

### API Endpoints
| HTTP Verbs | Endpoints | Action |
| --- | --- | --- |
| POST | /create-project | To create a new project |
| POST | /create-project-task | To create a new task for a project |
| POST | /add-employee | To add a new employee to a project  |
| POST | /create-project-log | To create a new project log |
| GET | /get-project/{id} | To get the project |
| GET | /get-tasks/{projectId} | To get all tasks to a project|
| GET | /get-project-logs/{projectId} | To get all project logs to a project |
| DELETE | /delete-task/{id} | To delete a single task |
| DELETE | /delete-project-log/{id} | To delete a single project log |
| PUT | /update-task | To update the task |

### Creates a new project

```http
  POST /create-project
```

#### Request

```json
{
  "projectName": "ProjectName",
  "startDate": "14.06.2019",
  "endDate": "15.12.2022",
  "overallStatus": "Opened",
  "totalBudget": 87000,
  "spendBudget": 5000
}
```

#### Response

```json
{
  "Id": 1,
}
```


### Creates a new task

```http
  POST /create-project-task
```

#### Request

Example 1:

```json
{
  "title": "Task",
  "status": "InProgress",
  "type": "Development",
  "description": "Description to the task",
  "deadline": "11.07.2019",
  "estimateInHour": 12,
  "employeeId": 1,
  "projectId": 1
}
```

Example 2:

```json
{
  "title": "Task",
  "status": "Opened",
  "type": "Development",
  "description": "Description to the task",
  "deadline": "11.09.2019",
  "estimateInHour": 12,
  "employeeId": null,
  "projectId": 1
}
```

#### Response

```json
{
  "Id": 1,
}
```

### Add a new employee to project

```http
  POST /add-employee
```

#### Request

```json
{
  "firstName": "Malachy",
  "lastName": "Parsons",
  "employeeType": "Developer",
  "projectId": 1
}
```

#### Response

```json
{
  "Id": 1,
}
```


### Create a new project log

```http
  POST /create-project-log
```

#### Request

```json
{
  "type": "TaskFinised",
  "creationDate": "11.09.2019",
  "employeeId": 1,
  "projectTaskId": 1
}
```

#### Response

```json
{
  "Id": 1,
}
```

### Get project

```http
  GET /get-project/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of project to fetch |

#### Response

```json
{
  "id": 1,
  "name": "ProjectName",
  "startDate": "14.06.2019 00:00:00",
  "endDate": "15.12.2022 00:00:00",
  "overallStatus": "Opened",
  "totalBudget": 87000,
  "spendBudget": 5000
}
```

### Get all tasks for the project

```http
  GET /get-tasks/{projectId}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `projectId`      | `int` | **Required**. Id of project to fetch all tasks |

#### Response

```json
[
  {
    "id": 1,
    "title": "Planning 1",
    "status": "Closed",
    "type": "Planning",
    "description": "Description 1",
    "deadline": "01.08.2023 15:48:38",
    "estimateInHour": 10,
    "employee": {
      "id": 6,
      "firstName": "Richard",
      "lastName": "Patrick",
      "employeeType": "Developer"
    }
  },
  {
    "id": 2,
    "title": "Planning 2",
    "status": "Closed",
    "type": "Planning",
    "description": "Description 2",
    "deadline": "01.08.2023 15:48:38",
    "estimateInHour": 10,
    "employee": {
      "id": 6,
      "firstName": "Richard",
      "lastName": "Patrick",
      "employeeType": "Developer"
    }
  },
]
```

### Get all project logs for the project

```http
  GET /get-project-logs/{projectId}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `projectId`      | `int` | **Required**. Id of project to fetch all project logs |

#### Response

```json
[
  {
    "id": 2,
    "type": "NewComment",
    "creationDate": "15.08.2017 00:00:00",
    "description": null,
    "employee": {
      "id": 1,
      "firstName": "Georg",
      "lastName": "Danwill",
      "employeeType": "ProjectLeader"
    },
    "projectTask": {
      "id": 22,
      "title": "Optimize Drill-Down Filter",
      "status": "InProgress",
      "type": "Development",
      "description": "Descripation About Finalize Testing Plan",
      "deadline": "15.08.2017 00:00:00",
      "estimateInHour": 5,
      "employee": {
        "id": 1,
        "firstName": "Georg",
        "lastName": "Danwill",
        "employeeType": "ProjectLeader"
      }
    }
  },
  {
    "id": 4,
    "type": "TaskFinised",
    "creationDate": "11.09.2019 00:00:00",
    "description": null,
    "employee": {
      "id": 1,
      "firstName": "Georg",
      "lastName": "Danwill",
      "employeeType": "ProjectLeader"
    },
    "projectTask": {
      "id": 1,
      "title": "Planning 1",
      "status": "Closed",
      "type": "Planning",
      "description": "Description 1",
      "deadline": "01.08.2023 15:48:38",
      "estimateInHour": 10,
      "employee": null
    }
  }
]
```

### Delete task

```http
  DELETE /delete-task/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of task to delete |

#### Response

```json
{
  "id": 23
}
```

### Delete project log

```http
  DELETE /delete-project-log/{id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of project log to delete |

#### Response

```json
{
  "id": 4
}
```

### Update task

```http
  PUT /update-task
```

#### Request

```json
{
  "id": 24,
  "title": "Task",
  "status": "Closed",
  "type": "Development",
  "description": "Description to the task",
  "deadline": "11.09.2019",
  "estimateInHour": 12,
  "employeeId": 5,
  "projectId": 1
}
```

#### Response

```json
{
  "id": 24
}
```


