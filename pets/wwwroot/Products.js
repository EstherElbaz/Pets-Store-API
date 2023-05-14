window.addEventListener("load", () => {
    getProducts();
    getCategories();
    sumCart();
});


async function getProducts() {
    const res = await fetch("https://localhost:44354/api/Product");
    if (res.ok) {
        if (res.status == 204)
            alert("no products");
        else
            var prods = await res.json();
        showProducts(prods)
    }

}

function showProducts(prods) {
    cleanView();
    for (var i = 0; i < prods.length; i++) {
        showProduct(prods[i]);

    }
}

function showProduct(prod) {

    var temp = document.getElementsByTagName("template")[0];
    var clon = temp.content.cloneNode(true);
    clon.querySelector("h1").innerText = (prod.productName);
    clon.querySelector(".price").innerText = (`₪${prod.productPrice}`);
    clon.querySelector(".description").innerText = (prod.productDescription);
    clon.querySelector("img").src = (`images/${prod.productImageUrl}`);
    clon.querySelector("button").addEventListener("click", () => addToCart(prod));
    document.getElementById("PoductList").appendChild(clon);
}

function cleanView() {
    document.getElementById("PoductList").innerHTML = "";
}

function initializeCart() {
    let cart = [];
    sessionStorage.setItem("cart", JSON.stringify(cart));
}


function sumCart() {
    var cart = sessionStorage.getItem("cart");
    if (cart != null) {
        cart = JSON.parse(cart);
        document.getElementById("ItemsCountText").innerHTML = cart.length;
    }
}

function addToCart(product) {
    var productsInCart = [];
    var cartFromSession = sessionStorage.getItem("cart");
    if (cartFromSession) { 
        productsInCart = JSON.parse(cartFromSession);
    }
    productsInCart.push(product);
    sessionStorage.setItem("cart", JSON.stringify(productsInCart));
    sumCart();
}



async function getCategories() {
    const res = await fetch("https://localhost:44354/api/Category");
    if (res.ok) {
        if (res.status == 204)
            alert("no categories");
        else
            var categories = await res.json();
        showCategories(categories);
    }

}

function showCategories(categories) {
    for (var i = 0; i < categories.length; i++) {
        showCategory(categories[i]);
    }
}

function showCategory(category) {
    var tmp = document.getElementById("temp-category");
    var clon = tmp.content.cloneNode(true);
    clon.querySelector(".opt").id = category.categoryId;
    clon.querySelector(".opt").value = category.categoryId;
    clon.querySelector(".OptionName").innerText = category.categoryName;
    clon.querySelector(".opt").addEventListener('click', filterProducts);
    document.getElementById("categoryList").appendChild(clon);
}



async function filterProducts() {
    let url = "https://localhost:44354/api/product?";
    var name = document.getElementById("nameSearch").value;
    if (name)
        url = url + `name=${name}`
    var minPrice = document.getElementById("minPrice").value;
    if (minPrice)
        url = url + `&minPrice=${minPrice}`;
    var maxPrice = document.getElementById("maxPrice").value;
    if (maxPrice)
        url = url + `&maxPrice=${maxPrice}`;
    var categories = document.getElementsByClassName("opt");
    for (var i = 0; i < categories.length; i++) {
        if (categories[i].checked)
            url = url + `&categoryIds=${categories[i].value}`;
    }
    const res = await fetch(url);
    var prods = await res.json();
    await showProducts(prods);
}

