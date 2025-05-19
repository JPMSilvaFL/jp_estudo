import React from 'react'
import { useEffect } from 'react';

const User = () => {

    useEffect(async ()=> {
        var response = await fetch("http://localhost:5184/api/v1/")
    });


  return (
    <div>
      
    </div>
  )
}

export default User
