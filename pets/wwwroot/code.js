let userIn = false;
async function login() {
    const userName = document.getElementById("userNameHome").value;
    const password = document.getElementById("passwordHome").value;

    const res = await fetch(`https://localhost:44354/api/Users/?password=${password}&userName=${userName}`);

    if (!res.ok) {
        throw Error(`status: {res.status} is making troubles again😱`);
    }
    else if (res.status == 204)
    {
        let confirm = window.confirm('משתמש לא רשום. להרשמה לחץ אישור ');
        if (confirm)
            window.location.href = "signIn.html";
        else
            alert("חבל");
    }
    else {

        const response = await res.json();
        sessionStorage.setItem('user', JSON.stringify(response));
        user = JSON.parse(sessionStorage.getItem('user'));
        location.href = "product.html";

         }
    
}

async function signIn() {
    const newUser = {
        "Email": document.getElementById("Email").value,
        "FirstName": document.getElementById("FirstName").value,
        "LastName": document.getElementById("LastName").value,
        "Password": document.getElementById("Password").value,
    };
        const res = await fetch("https://localhost:44354/api/users", {
        headers: {"Content-type":"application/json"},
        method: 'POST',
        body: JSON.stringify(newUser)
    });
    if (res.ok) { 
        alert("you are in!");
        userIn = true;
        window.location.href = "home.html";
    }
    else
        alert("try again");
}

function updateLink() {
    window.location.href = "update.html";
}

async function update() {

        const user = JSON.parse(sessionStorage.getItem("user"));
        const id = user.userId;
        const updatedUser = {
            "Email": document.getElementById("usernameToUpdate").value,
            "FirstName": document.getElementById("fNameToUpdate").value,
            "LastName": document.getElementById("lNameToUpdate").value,
            "Password": document.getElementById("passwordToUpdate").value,
    };
 

    const res = await fetch("https://localhost:44354/api/users/${id}", {
            headers: { "Content-type": "application/json ;charset=utf-8" },
            method: 'PUT',
            body: JSON.stringify(updatedUser)

        });

        if (res.ok) {
            sessionStorage.setItem('user', JSON.stringify(updatedUser));
            alert("העדכון נשמר בהצלחה");
            window.location.href = "home.html";
        }

        else {
            alert("we're really sorry but its too complicated and we didnt manage to update your datails")

        }


    }

async function checkPassword() {
    const password = document.getElementById("password").value;
    const response = await fetch("https://localhost:44335/api/password", {
        headers: { "Content-type": "application/json" },
        method: 'POST',
        body: JSON.stringify(password)
    });
    if (response.ok) {
        const res = await response.json();
        document.getElementById("checkPassword").innerText = "The password strength is " + res;
    }
    else {
        alert("error");
    }
}

/*}*/