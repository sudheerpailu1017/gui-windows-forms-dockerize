FROM ubuntu:22.04

# Install necessary packages
RUN apt update && \
    apt install -y wget lsb-release gpg software-properties-common xvfb && \
    dpkg --add-architecture i386 && \
    wget -qO- https://dl.winehq.org/wine-builds/winehq.key | gpg --dearmor -o /etc/apt/trusted.gpg.d/winehq.key.gpg && \
    echo "deb https://dl.winehq.org/wine-builds/ubuntu/ $(lsb_release -cs) main" > /etc/apt/sources.list.d/winehq.list && \
    apt update && \
    DEBIAN_FRONTEND=noninteractive apt install -y winehq-staging winetricks

# Set the working directory
WORKDIR /app

# Copy your .exe file into the container
COPY /bin/Debug/net8.0-windows/ .

# Clear any existing cache for Winetricks and install necessary packages
RUN apt-get update \
    && DEBIAN_FRONTEND=noninteractive apt-get install -y --no-install-recommends \
        ca-certificates \
        curl \
    && rm -rf /var/lib/apt/lists/*

# Install .NET 8
ENV DOTNET_VERSION=8.0.0

RUN curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin -Channel 8.0 -Runtime dotnet -InstallDir /usr/share/dotnet \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

# Start Xvfb and run your .exe with Wine
CMD ["sh", "-c", "Xvfb :0 -screen 0 1024x768x16 & sleep 5 && DISPLAY=10.47.0.57:0.0 wine HelloWorldWinApp.exe"]
