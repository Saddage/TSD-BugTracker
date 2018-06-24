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

### Configure production enviroment

You need to have postgresql installed on your server!
[Installation](https://www.postgresql.org/docs/9.3/static/tutorial-install.html) - Database used in the project
You need to have nginx working as a reverse proxy on your server!
[Guide](https://docs.nginx.com/nginx/admin-guide/web-server/reverse-proxy/) - Guide to reverse proxy in nginx


Nginx settings
```
server {
    listen        80;
    server_name   _;
    root /var/www/html;
    index index.html;

    location / {
        try_files $uri $uri/ =404;
    }

    location /api {
        proxy_pass         http://localhost:5001/api;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }
}
```
After applying settings, nginx service must be reloaded.

Create production database

```
createdb BugTracker
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

Publish application

```
dotnet publish -c Release
```

Launch published applicaiton

```
dotnet BugTracker.dll
```