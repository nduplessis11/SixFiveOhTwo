# SixFiveOhTwo

**SixFiveOhTwo** is a distributed microservice-based emulator for the MOS 6502 CPU, built using C# and .NET 8. This project leverages gRPC for inter-service communication and RabbitMQ for event-driven messaging, creating a scalable and modular architecture.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction

The SixFiveOhTwo project is a modern take on emulating the iconic 6502 CPU. By splitting the emulator's components into microservices, this project demonstrates how distributed systems can be used to emulate classic hardware in a scalable and maintainable way.

## Features

- **Distributed Architecture:** The emulator is broken down into multiple microservices, each responsible for a specific aspect of the 6502 CPU.
- **gRPC Communication:** Synchronous communication between microservices using gRPC, ensuring fast and efficient data transfer.
- **RabbitMQ Integration:** Asynchronous event-driven messaging for handling interrupts and other real-time events.
- **Modularity:** Easily extend or replace components without affecting the overall system.
- **Scalability:** The distributed nature allows for horizontal scaling of individual components as needed.

## Architecture

The SixFiveOhTwo project is composed of the following microservices:

- **CPU Service:** Emulates the 6502 CPU, handling instruction execution and register management.
- **Memory Service:** Manages memory read/write operations and emulates the 6502 address space.
- **I/O Service:** Handles input/output operations and peripheral emulation.
- **Control Service:** Coordinates and synchronizes the other services, managing the CPU clock and overall system state.

### Communication

- **gRPC:** Used for synchronous calls between services (e.g., CPU fetching instructions from Memory).
- **RabbitMQ:** Handles asynchronous events like interrupts and memory-mapped I/O operations.

## Getting Started

### Prerequisites

- .NET 8 SDK
- RabbitMQ server
- gRPC tools
