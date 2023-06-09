# Chatting API

This API allow users to interact with other users through posts

Changes I made to my original idea:
I grouped all of the user information into a class called UserInfo. Prior to this, I thought that the concept of grouping data into another table would make the project more complicated, which it did but it was also worth it because the API response structure looks neater.

## API Endpoints

- https://localhost:7169/api/User
- https://localhost:7169/api/User/:id
- https://localhost:7169/api/Post
- https://localhost:7169/api/Post/:id

## HTTP Methods

**GET**

- get Users -> /api/User
- get User by Id -> /api/User/:id
- get Posts -> /api/Post
- get Post by Id -> /api/Post/:id

**POST**

- create User -> /api/User
- create Post -> /api/Post

**PUT**

- edit User by Id -> /api/User/:id
- edit Post by Id -> /api/Post/:id

**DELETE**

- delete User by Id -> /api/User/:id
- delete Post by Id -> /api/Post/:id

## Sample Request Body

```
{
  "userName":"Postman Testing",
  "email":"postmantesting@gmail.com",
  "UserInfo": {
    "age": 40,
    "bio": "Postman is fun",
    "location": "New York City",
    "education": "Hunter College"
  }
}
```

## Sample Response Body

```
{
  "statusCode":200,
  "statusDescription":"User 1 retrieved!",
  "user":[
    {
      "userId":1,
      "userName":"Tommy133",
      "email":"tommytest@gmail.com",
      "userInfo":{
        "userId":1,
        "userInfoId":1,
        "age":20,
        "bio":"Hello World",
        "location":"New York",
        "education":"Hunter College"
      }
    }
  ],
  "post":null
}
```
