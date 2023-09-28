// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


document.addEventListener("DOMContentLoaded", function () {
    const miniCartButton = document.getElementById("mini-cart-button");
    const cartPreview = document.getElementById("cart-preview");
    let isCartOpen = false;

    miniCartButton.addEventListener("click", function (event) {
        event.preventDefault(); // Prevent the default link behavior

        if (isCartOpen) {
            cartPreview.style.display = "none";
        } else {
            fetch("/Cart/Index?layout=_Layout1")
                .then(response => response.text())
                .then(data => {
                    cartPreview.innerHTML = data;
                    cartPreview.style.display = "block";
                })
                .catch(error => {
                    console.error('There was a problem with the fetch operation:', error);
                });
        }

        isCartOpen = !isCartOpen;
    });
});
