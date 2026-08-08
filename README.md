# Conference Attendee Check-In Monitoring System

An enterprise-grade, modern web application built with **ASP.NET Core MVC** and **Bootstrap 5** designed to streamline event check-ins, track live visitor attendance status, and manage security staff portals seamlessly.

## 🚀 Features

* **Real-Time Attendance Monitoring**: Track total arrivals, active participants currently inside the venue, and departures at a glance with live dashboard statistics.
* **Credential & Ticket Management**: Easily register attendee arrivals, update organization profiles, issue ticket identifiers, and log special notes.
* **Secure Staff Portal**: Role-based architecture allowing authorized event personnel to log in securely.
* **Modern Immersive UI**: Fully responsive, clean card-based layout featuring rich typography, dynamic status badges, and smooth interactive design elements.

---

## 🛠️ Tech Stack

* **Backend**: ASP.NET Core MVC (.NET 8 / .NET Core)
* **Frontend**: Bootstrap 5, Bootstrap Icons, HTML5, CSS3, JavaScript
* **Architecture**: Repository Pattern, MVC Design Pattern

---

## 📂 Project Structure

```text
ConferenceSystem/
│
├── Controllers/         # Handles HTTP requests (AccountController, AttendeeController)
├── Models/              # Data entities and view models (AttendeeVisit, User, ErrorViewModel)
├── Repositories/        # Data access logic layers
├── Views/               # Razor views (Account, Attendee, Shared Layouts & Error pages)
├── wwwroot/             # Static web assets (CSS, JS, Libraries)
└── Program.cs           # Application entry point and service configurations
