# 🧩 WebApplication6 - ASP.NET MVC Modular CRUD System

**WebApplication6** is a structured ASP.NET MVC 5 project built to demonstrate CRUD operations for multiple entities like `LOC_Country`, `LOC_State`, `LOC_City`, `MST_Branch`, and `MST_Student`. It follows a modular design with **Areas**, **DAL/BAL architecture**, and **RESTful API consumption**.

---

## 🚀 Features

- ✅ CRUD operations for:
  - LOC_Country 🌍
  - LOC_State 🏞️
  - LOC_City 🏙️
  - MST_Branch 🏢
  - MST_Student 🎓
- 🔗 RESTful API calls using `HttpClient`
- 🗂️ Separation of concerns with:
  - **DAL (Data Access Layer)**
  - **BAL (Business Access Layer)**
  - **Models**
  - **Controllers & Views**
- 🧱 Organized using **Areas** for better module separation
- 🖼️ Responsive Razor views for UI
- ⚙️ Built using Visual Studio

---

## 🛠️ Tech Stack

- 💻 ASP.NET MVC 5 / .NET Framework
- 🌐 RESTful APIs via `HttpClient`
- 🗃️ Entity Framework (Code First or DB First)
- 💾 SQL Server / LocalDB
- 🖼️ Razor Views
- ⚙️ Visual Studio IDE

---

## 📁 Folder Structure

WebApplication6/ │ ├── Areas/ │ ├── LOC/ │ │ ├── Controllers │ │ ├── Models │ │ └── Views │ └── MST/ │ ├── Controllers │ ├── Models │ └── Views │ ├── BAL/ ├── DAL/ ├── Controllers/ ├── Models/ ├── Views/ ├── App_Start/ └── Web.config

---

## 📦 Setup Instructions

1. Clone the repository  
   `git clone https://github.com/Arman-Gilani/WebApplication6.git`

2. Open the solution in **Visual Studio**.

3. Restore NuGet packages.

4. Set up your **SQL Server / LocalDB** connection string in `Web.config`.

5. Build and run the project.

---

## 🙌 Contributing

Feel free to fork the repository and submit pull requests for improvements or new features.

---

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).
