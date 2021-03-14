# StockHubApp

This project represents the frontend for the .NET application <a href="https://github.com/samuelschnurr/stock-hub/tree/main/StockHubApi">StockHubApi</a>. 

- Single Page Application based on Angular 11
- Completely responsive
- Dashboard with chart
- Listview
- Formeditor
- Modal dialog
- Notifications 
- Routing
- Internationalization (i18n)
- Code documentation

## Before you start
- Install the <a href="https://nodejs.org/en/">Node.js 14</a>
- Install the <a href="https://angular.io/cli">Angular CLI</a> with the command `npm install -g @angular/cli`
- Setup and run the <a href="https://github.com/samuelschnurr/stock-hub/tree/main/StockHubApi">StockHubApi</a> to communicate with the backend
- Notice that this application is hostet unter `https://localhost:4200/`

## Build and run using an CLI

Open the terminal and navigate to the folder where the project `StockHubApp` is located.

Run the following command to install `node modules`:

```
npm install
```

Now start a development server and open the application in the browser with the command:

```
ng serve --o
```

If you want to run the server with a different language configuration run:

```
ng serve --o --configuration=de
```

## Run ESLint

For linting the project run:

```
ng lint
```

## License

Get more information about the licensing of this repository at the <a href="https://github.com/samuelschnurr/stock-hub#license">root level</a>.
