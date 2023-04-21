import React, { useState, useEffect } from 'react';
import axios from 'axios';

export default function Home() {
  const [users, setUsers] = useState([]);
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:7169/api/User')
      .then(res => {
        console.log(res.data.user)
        setUsers(res.data.user)
      })
      .catch(err => console.log(err))
  }, []);

  useEffect(() => {
    axios.get('https://localhost:7169/api/Post')
      .then(res => {
        console.log(res.data.post)
        setPosts(res.data.post)
      })
      .catch(err => console.log(err))
  }, []);

  return (
    <div>
      <form>
        <h2>User</h2>

        <div className="input-item">
          <label className="input-name">UserName</label>
          <input type="text" placeholder="username"/>
        </div>

        <div className="input-item">
          <label className="input-name">Email</label>
          <input type="email" placeholder="email"/>
        </div>

        <button>Create User</button>
      </form>

      <div>List of Users</div>
      {
        users.map((x) => (
          <div key={x.userId}>
            <div style={{fontWeight:"bold"}}> User {x.userId} </div>
            <div> Username: {x.userName} </div>
            <div> Email: {x.email} </div>
            <div> Age: {x.userInfo.age} </div> 
            <div> Education: {x.userInfo.education} </div>
            <div> Location: {x.userInfo.location} </div>
            <div> Bio: {x.userInfo.bio} </div>          
          </div>
        ))
      }

      <form>
        <h2>Post</h2>
        <div className="input-item">
          <textarea className="input-textarea"></textarea>
          <button>Post</button>          
        </div>
      </form>

      <div>
        {
          posts.map((x) => (
            <div key={x.postId}>
              {x.userName}
              -
              {x.postDescription}
            </div>
          ))
        }
      </div>
    </div>
  )
}