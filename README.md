# XMLValidationApp

Validate any XML file against its XSD schema in a clean ASP.NET Core MVC app.

> Built as part of a Web Programming Languages II lab to practice XML Schema design and XML validation in .NET.

---

## ✨ Features

- Upload an **XML** file and its corresponding **XSD** schema
- Server-side validation using `XmlReaderSettings` with `Schemas.Add(...)`
- Clear success/error messages with line/position details for invalid XML
- Simple, single-page interface (`Index.cshtml`)

---

## 🧱 Tech Stack

- **.NET / ASP.NET Core MVC**
- **C#**
- **Razor Views**
- `System.Xml`, `System.Xml.Schema`

---
🛠️ How It Works

User selects an XML file and its XSD file and submits.

The controller:

Loads the XSD into XmlSchemaSet

Creates XmlReaderSettings with the schema set and ValidationType.Schema

Reads the XML with XmlReader and captures validation events

The app returns:

✅ Valid: “XML file is valid against the schema.”

❌ Invalid: Aggregated errors (message, line, and position)

