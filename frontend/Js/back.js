

// solo se puede enviar JSON en dos casos:
// SI VOY A ENVIAR INFORMACIÓN (POST)
// SI VOY A MODIFICAR INFORMACIÓN (PUT)
// para GET y DELETE no se debe utilizar JSON.stringify
// la info debe enviarse por 'headers'
function Enviarback() {

  let nombre = document.getElementById("nombre").value;
  let cedula = document.getElementById("cedula").value;
  let edad = document.getElementById("edad").value;

  var request = new Request('https://localhost:44373/api/Values', {
    method: 'Post',
    //mode: 'no-cors',
    //credentials: 'omit',
    // cache: 'only-if-cached',
    //referrerPolicy: 'no-referrer',
    headers: {
      'Content-Type': 'application/json'
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    body: JSON.stringify({
      cedula: cedula,
      nombre: nombre,
      edad: parseInt(edad)

      //   surname: "Swift"
    })
  });

  fetch(request)
    .then(function (response) {
      return response.text();
    })
    // si el backend devuelve info. entonces llega a 'data'
    .then(function (data) {
      console.log('data = ', data);
      alert(data);
    })
    // si existe un error llega por acá!
    .catch(function (err) {
      console.error(err);
    });
}


function eliminar() {
  let cedula = document.getElementById("cedula").value;

  var request = new Request('https://localhost:44373/api/Values/' + cedula, {
    method: 'Delete',
    //mode: 'no-cors',
    //credentials: 'omit',
    // cache: 'only-if-cached',
    //referrerPolicy: 'no-referrer',
    headers: {
      'Content-Type': 'application/json'
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
  });


  fetch(request)
    .then(function (response) {
      return response.text();
    })
    .then(function (data) {
      console.log(data);
      alert(data);
    })
    .catch(function (err) {
      console.error(err);
    });

}



function consultaru() {
  let cedula = document.getElementById("cedula").value;

  var diri = "";

  if (cedula != "") {
    diri = 'https://localhost:44373/api/Values/' + cedula
  } else {
    diri = 'https://localhost:44373/api/Values/'
  }

  var request = new Request(diri, {
    method: 'Get',
    headers: {
      'Content-Type': 'application/json'
    },
  });


  fetch(request)
    .then(function (response) {
      return response.text();
    })
    .then(function (data) {
      alert(data);
      generarTabla(data);
    })
    .catch(function (err) {
      console.error(err);
    });

}

function generarTabla(data) {
  cabecera();
  contenido(data);
}

function cabecera() {
  divppl = document.getElementById("informacion");

  col1 = document.createElement("div");
  col2 = document.createElement("div");
  col3 = document.createElement("div");

  col1.setAttribute("class", "celdas");
  col2.setAttribute("class", "celdas");
  col3.setAttribute("class", "celdas");


  texto1 = document.createTextNode("Cedula");
  texto2 = document.createTextNode("Nombre");
  texto3 = document.createTextNode("edad");


  col1.appendChild(texto1);
  col2.appendChild(texto2);
  col3.appendChild(texto3);


  divppl.appendChild(col1);
  divppl.appendChild(col2);
  divppl.appendChild(col3);
}


function contenido(data) {
  divppl = document.getElementById("informacion");
  json = JSON.parse(data);
  for (var dato in json) {
    col1 = document.createElement("div");
    col2 = document.createElement("div");
    col3 = document.createElement("div");

    col1.setAttribute("class", "contenido");
    col2.setAttribute("class", "contenido");
    col3.setAttribute("class", "contenido");


    texto1 = document.createTextNode(json[dato].cedula);
    texto2 = document.createTextNode(json[dato].nombre);
    texto3 = document.createTextNode(json[dato].edad);


    col1.appendChild(texto1);
    col2.appendChild(texto2);
    col3.appendChild(texto3);


    divppl.appendChild(col1);
    divppl.appendChild(col2);
    divppl.appendChild(col3);
  }
}


