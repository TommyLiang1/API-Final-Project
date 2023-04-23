# API-Final-Project

This API allow users to interact with other users through posts

## HTTP Methods and API Endpoints

**GET**

- get Users -> /api/User
- get User by Id -> /api/User/:id
- get Posts -> /api/Post
- get Post by Id -> /api/Post/:id
- get UserInfo -> /api/UserInfo

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
