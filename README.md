<p align="center">
<img src="https://user-images.githubusercontent.com/25421570/234197954-8e8118b7-4290-4c3a-9f83-78a3422be439.png" width="90%">
</p>

# BooksAPI

BooksAPI is a RESTful API that provides access to a database called ELibraryDB, designed to handle the storage needs of a fictional library. The database contains information about books, authors, publishers, and borrowers, as well as over 26 stored procedures to perform various library-related tasks.

The API is built using the ASP.NET Core framework and C#, and is secured using a password hashing algorithm (SHA256) and a JSON Web Token (JWT) system for authentication. The API currently features a Books Controller, which handles the creation, retrieval, updating, and deletion of books in the database.

To use the BooksAPI, you will need to have a valid JWT token, which can be obtained by authenticating with the API using your username and password. Once authenticated, you can access the various endpoints provided by the Books Controller to perform CRUD (Create, Read, Update, Delete) operations on the book data stored in the ELibraryDB.

Note that this API is still in development, and more endpoints and controllers may be added in the future to provide additional functionality and support for other features of the ELibraryDB database.

