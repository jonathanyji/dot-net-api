# dot-net-api

This is a simple CRUD api written in C# .Net with MySQL database

## Pre-requisite:
1. Build the project solution
2. Install MySQL
3. Create db name "notesdb"

```bash
CREATE DATABASE notesdb;
```

4. Create table name "notes" with the following columns and data type
    id              int
    title           varchar
    description     varchar

```bash
CREATE TABLE notes (
    id int,
    title varchar(255),
    description varchar(255)
);
```

5. Add data manually

```bash
INSERT INTO notes (id, title, description)
VALUES (1, 'Travel Journal', 'This is a test Journal notes'),
VALUES (2, 'Work Journal', 'This is a test work  Journal notes'),
VALUES (3, 'Cooking Journal', 'This is a test Cooking Journal notes');
```

6. Run the app and API can be used with Swagger
    

## API:

1. Create API (/create)
```bash
{
  "id": 0,
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
  "id": 0,
  "title": "string",
  "description": "string"
}
```

4. DeleteById (/delete)
```bash
{
  "id": 1
}
```

## Helpful link
```bash
https://auth0.com/blog/aspnet-web-api-authorization/

https://stackoverflow.com/a/75218950/13150631

https://stackoverflow.com/a/64673991

https://stackoverflow.com/a/54086161/13150631
```
