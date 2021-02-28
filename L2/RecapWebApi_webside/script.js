// const shortDescription = document.getElementById('shortDescription')
// const name =             document.getElementById('name')
// const longDescription =  document.getElementById('longDescription')
// const price =            document.getElementById('price')


fetch('https://recapwebapi.azurewebsites.net/api/products/2 ')
    .then(res=>res.json())
    .then(data=>{         
        // console.log(data)
      
        // name.innerHTML=data.name
        // // name.innerHTML='name ${data.name}'
        // shortDescription.innerText=data.shortDescription        
        // longDescription.innerHTML=data.longDescription
        // // price.innerHTML = ' price ${ data.price } kr '
        // price.innerHTML = data.price
        document.getElementById('shortDescription').innerText=data.shortDescription
        document.getElementById('name').innerHTML=data.name
        document.getElementById('longDescription').innerHTML=data.longDescription
        document.getElementById('price').innerHTML = ' price ${ data.price } kr '
    })
