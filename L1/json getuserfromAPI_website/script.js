let userhtml = document.getElementById('user');
let usershtml = document.getElementById('users');

fetch('https://localhost:44301/api/Customers')
    .then(res=>res.json())
    .then(data=>{
        for(let user of data){
            let li =document.createElement('li')

              li.innerHTML='${user.displayName}(${user.id})'
            li.innerHTML='user.displayName'
            usershtml.appendChild(li)
        }
    })
fetch('https://localhost:44301/api/Customers/{id}')
    .then(res=>res.json())
    .then(data=>userhtml.innerText=data.displayName)