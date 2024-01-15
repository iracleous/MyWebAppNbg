// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function responseToClick() {

    document.getElementById("errorDiv").innerHTML = '';
    document.getElementById("resultDiv").innerHTML = '';

    var url = "https://localhost:7077/api/customers1";

    var method = "POST";


    var regDate = document.getElementById("RegistrationDate").value;
    var userName = document.getElementById("Name").value;
    var address = document.getElementById("Address").value;

   
    if (userName == ""){
        alert("user name empty");
        return;
    }

    if (address == "") {
        alert("address name empty");
        return;
    }

 //   alert(regDate)
  //  if (!(regDate instanceof Date))

    if (regDate == "") 
    {
        alert("Not valid registration date");
        return;
    }
     

    var data = {
        name: userName,
        address: address,
        registrationDate: regDate
    };

    fetch(url, {
        method: method, // *GET, POST, PUT, DELETE, etc.
        mode: "cors", // no-cors, *cors, same-origin
        cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
        credentials: "same-origin", // include, *same-origin, omit
        headers: {
            "Content-Type": "application/json",
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: "follow", // manual, *follow, error
        referrerPolicy: "no-referrer", // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        body: JSON.stringify(data), // body data type must match "Content-Type" header
    })
        .then(res => res.json())
        .then(response => {
       //     document.getElementById("resultDiv").innerHTML = JSON.stringify(response);

            myContent = "Customer name = " + response.name + "<br>";
            myContent += "Customer address = " + response.address + "<br>";
            myContent += "Customer registrationDate = " + response.registrationDate + "<br>";

            document.getElementById("resultDiv").innerHTML  = myContent

        })
        .catch(error => {
            if (error instanceof TypeError && error.message.includes('API key')) {
                console.error('Invalid API key:', error);
                document.getElementById("errorDiv").innerHTML = 'Invalid API key:' + error;
            } else {
                console.error('There was a problem with the Fetch operation:', error);
                document.getElementById("errorDiv").innerHTML = 'here was a problem with the Fetch operation:';
            }
        });
}


function getAllCustomers() {
    document.getElementById("errorDiv").innerHTML = '';
    document.getElementById("resultDiv").innerHTML = '';

    var url = "https://localhost:7077/api/customers1";

    var method = "GET";
  

    fetch(url, {
        method: method, // *GET, POST, PUT, DELETE, etc.
        mode: "cors", // no-cors, *cors, same-origin
        cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
        credentials: "same-origin", // include, *same-origin, omit
        headers: {
            "Content-Type": "application/json",
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: "follow", // manual, *follow, error
        referrerPolicy: "no-referrer" // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
     
    })
        .then(res => res.json())
        .then(response => {
            responseText = "<table> <tr><th>Id</th><th>Name</th><th>Address</th><th>Registration Date</th></tr>";
            customers = response.$values
            customers.forEach(customer => responseText += "<tr><td>" + customer.id + "</td><td>" + customer.name
                + "</td><td>" + customer.address + "</td><td>" + customer.registrationDate + "</td></tr>")

            responseText += "</table>"
            document.getElementById("resultDiv").innerHTML = responseText;

            

        })
        .catch(error => {
            if (error instanceof TypeError && error.message.includes('API key')) {
                console.error('Invalid API key:', error);
                document.getElementById("errorDiv").innerHTML = 'Invalid API key:' + error;
            } else {
                console.error('There was a problem with the Fetch operation:', error);
                document.getElementById("errorDiv").innerHTML = 'here was a problem with the Fetch operation:';
            }
        });
}
