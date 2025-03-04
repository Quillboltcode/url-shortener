# --- Build the frontend (React/Vue) ---
FROM node:20 AS frontend-build
WORKDIR /app
COPY Frontend/ ./
RUN npm install
RUN npm run build

# --- Build the ShortUrlService (.NET Core) ---
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS backend-build
WORKDIR /app
COPY ShortUrlService/*.csproj ./
RUN dotnet restore
COPY ShortUrlService/. ./
RUN dotnet publish -c Release -o /out

# --- Create final runtime image ---
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=backend-build /out .

# Copy frontend build output to the backend's static files directory
COPY --from=frontend-build /app/dist ./wwwroot

# Expose necessary ports
EXPOSE 5000
EXPOSE 5001

# Run the application
CMD ["dotnet", "UrlShortener.dll"]

