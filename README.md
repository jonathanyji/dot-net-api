# dot-net-api

This is a simple CRUD api written in C# .Net with MySQL database

## Pre-requisite:
1. Build the project solution
2. Install MySQL

3. Run the mysql script file name: notes_db_script.sql located in the NotesApp/ directory
   This will create users table and notes table with initial values

```bash
source [path_to_script/NotesApp/notes_db_script.sql]
```

4. Run the app and API can be used with Swagger
    

## API:

1. Create API (/create)
```bash
{
  "id": '0',
  "title": "string",
  "description": "string"
}
```

2. List API (/list)
```bash
Gets all the list of notes in the notes db
```

3. GetNotesById API (/get-note)
```bash
{
  "id": 1
}
```

3. UpdateNotesById (/update)
```bash
{
  "id": '0',
  "title": "string",
  "description": "string"
}
```

4. DeleteById (/delete)
```bash
{
  "id": '1'
}
```

## Helpful link
```bash
https://auth0.com/blog/aspnet-web-api-authorization/

https://stackoverflow.com/a/75218950/13150631

https://stackoverflow.com/a/64673991

https://stackoverflow.com/a/54086161/13150631
```
