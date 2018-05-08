# Bug Tracker API

Bug Tracker project for TSD classes.

### Configure database

You need to have postgresql installed on your computer!
[Installation](https://www.postgresql.org/docs/9.3/static/tutorial-install.html) - Database used in the project

Create development database

```
createdb BugTracker.Dev
```

Navigate to the root of the project and restore packages

```
dotnet restore
```

Navigate to project directory

```
cd BugTracker/
```

Perform migrations

```
dotnet ef database update
```