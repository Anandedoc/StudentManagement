# StudentManagement

This API allows you to perform CRUD operations on student records.

First, you need to log in with the provided username and password. Upon successful login, you will receive a token. You can then use this token to perform CRUD operations on student records. 

Additionally, you can use this token to create staff members. Staff members with the role TEACHER are the only ones authorized to delete and update student records.

This token will be valid for 2 days. Before it expires, you can renew it to obtain a new token, or you will need to log in again.

This project also contains unit test cases for the repository, business logic, and controller levels.

## API Endpoints

### Staff Login

**Endpoint:** `/Login`
**Method:** POST
**Description:** Staff Login.

**Request Body:**
```json
{
  "userName": "admin",
  "password": "password123",
}```
```

**Request Body:**

"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2OTQxMTQ0NTgsIlVzZXJJZCI6MSwiTmFtZSI6ImFkbWluIiwiUm9sZSI6IlRlYWNoZXIiLCJFbWFpbCI6ImFkbWluIiwiSXNzdWVkQXQiOjE2OTM5NDE2NTg0NDd9.N09eHtac_DZzSrM6eJJ8wjNcNgIo2C8jh7edUJ65TJM"

### Renew Token

**Endpoint:** `/Renew`
**Method:** GET
**Description:** Renew Token.


**Request Body:**

"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE2OTQxMTQ0NTgsIlVzZXJJZCI6MSwiTmFtZSI6ImFkbWluIiwiUm9sZSI6IlRlYWNoZXIiLCJFbWFpbCI6ImFkbWluIiwiSXNzdWVkQXQiOjE2OTM5NDE2NTg0NDd9.N09eHtac_DZzSrM6eJJ8wjNcNgIo2C8jh7edUJ65TJM"

### Create Student

**Endpoint:** `/Students`
**Method:** POST
**Description:** Create a new student record.

**Request Body:**
```json
{
  "name": "John Doe",
  "age": 20,
  "grade": "A"
}```
```
### Update Student

**Endpoint:** `/Students`
**Method:** PUT
**Description:** Updating the existing student record.

**Request Body:**
```json
{
  "id": 1,
  "name": "John Doe",
  "age": 20,
  "grade": "A"
}```
```
### GetAll Students
**Endpoint:** `/Students`
**Method:** GET
**Description:** Get all the existing student records.

**Response**
```json
[{
  "id": 1,
  "name": "John Doe",
  "age": 20,
  "grade": "A"
},
{
  "id": 2,
  "name": "John Doe",
  "age": 20,
  "grade": "A"
}]```
```

## Delete Student
**Endpoint:** `/Students/1`
**Method:** DELETE
**Description:** Delete the existing student record.



