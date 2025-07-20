// src/Post.js
import React from 'react';

const Post = ({ title, body }) => {
  return (
    <div style={{ marginBottom: '20px' }}>
      <h2>{title}</h2>
      <p>{body}</p>
    </div>
  );
};

export default Post;
