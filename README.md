# Dashboard

## Build the required docker
To host the .NET Core application, we provided a docker compose file, but first some steps are necessary:
### Secrets setup
To work, Dashboard requires a handful of credentials used for many things, such as OAuth or REST APIs,
you will need to setup a user-secrets file that can be used by Dashboard, this file needs to be in a JSON format and can either be created manually or by entering the command

    dotnet user-secrets init
This will create the necessary JSON file to a path, usually `C:\Users\YOUR_USERNAME\AppData\Roaming\Microsoft\UserSecrets\`
Save this path and then copy it into the `docker-compose.yml` file under the volumes part so that your file looks like this:

    volumes:
      - YOUR_PATH_HERE/secrets.json:/root/.microsoft/usersecrets/c0f9c504-637f-4774-ac30-d88a5157d99e/secrets.json
You will now need to populate this file with different API tokens so that it looks like this:

    {
      "youtube-api-key": "YOUTUBE_API_KEY",
      "weather-api-key": "WEATHER_API_KEY",
      "spotify-app-secrets": "SPOTIFY_OAUTH2_SECRET",
      "nytimes-api-key": "NYTIMES_API_KEY",
      "ethgas-api-key": "ETH_GAS_STATION_API_KEY",
      "Authentication:Microsoft:secret": "MICROSOFT_OAUTH2_SECRET",
      "Authentication:Microsoft:id": "MICROSOFT_OAUTH2_ID",
      "Authentication:Google:secret": "GOOGLE_OAUTH2_SECRET",
      "Authentication:Google:id": "GOOGLE_OAUTH2_ID"
    }


### Build
Once done, open a terminal next to the docker compose file and type the command :

    docker-compose up --build
Docker will take care of setting up an EntityFramework Database and migrating the data, aswell as starting the app.
Wait for it to be over, the website will be served over http://localhost:8080

### Restart the app
If you ever need to restart the app, you will have to first "down" the container by using the command:

    docker-compose down
Then proceed as usual with 

    docker-compose up --build

