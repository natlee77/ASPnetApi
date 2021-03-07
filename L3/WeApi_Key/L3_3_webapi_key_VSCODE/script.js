fetch("https://localhost:44355/weatherforecast ", {
    headers:{
        'key':"ew0KInVzZXJpZCI6MSwNCiJlbWFpbCI6ICJuYXRsaXNqb0BnbWFpbC5jb20iDQp9",
    }
    
    })
    .then(res=>res.json())
    .then(data=>console.log(data))