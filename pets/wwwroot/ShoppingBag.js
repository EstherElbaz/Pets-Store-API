window.addEventListener("load", showCartItems());

function showCartItems() {
    let cart;
    const cartJson = sessionStorage.getItem("cart");
    if (cartJson) {
        cart = JSON.parse(cartJson);
    }
    for (var i = 0; i < cart.length; i++) {
        showCartItem(cart[i],i);
    }
}


function removeItem(item) {
    cart = sessionStorage.getItem("cart");
    cart = JSON.parse(cart);
    cart.splice(item, 1);
    cart = JSON.stringify(cart);
    sessionStorage.setItem("cart", cart);
    removwAllItems();
    showCartItems(cart);
}

function showCartItem(product,item) {
    var temp = document.getElementsByTagName("template")[0];
    var clon = temp.content.cloneNode(true);
    clon.querySelector(".image").style.backgroundImage = `url(./images/${product.productImageUrl})`;
    clon.querySelector(".itemName").innerHTML = (product.productName);
    clon.querySelector(".price").innerHTML = (product.productPrice);
    clon.querySelector(".showText").addEventListener("click", () => removeItem(item));
    document.querySelector(".cistGroup").appendChild(clon);
}


function removwAllItems() {
    document.querySelector(".cistGroup").innerHTML = "";
}


async function placeOrder() {
    let cart = JSON.parse(sessionStorage.getItem("cart"));
    let sum = 0;
    let OrderItemsFromSession = [];
  
    cart.forEach(cartItem => {
        item = {
         "ProductId": cartItem.productId,
         "Quantity":0
        };

        OrderItemsFromSession.push(item);
        sum += cartItem.productPrice;
    });

    user = sessionStorage.getItem("user");
    if(user)
    user = JSON.parse(user);
    order = {
        "OrderId":0,
        "OrderDate": new Date(),
        "OrderSum": sum,
        "UserId": user.userId,
        "OrderItemsDto": OrderItemsFromSession
    };
    const response = await fetch("https://localhost:44354/api/order", {
        headers: { "Content-type": "application/json" },
        method: 'POST',
        body: JSON.stringify(order)
    });
    if (response.ok) {
        removwAllItems();
        alert("well'e sent you the stuff");
        sessionStorage.setItem("cart", JSON.stringify([]));
}

    else {
        alert("sorry, we can't complete your orser now. please try again later.");
    }
}










