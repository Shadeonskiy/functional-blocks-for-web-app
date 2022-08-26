let input_elements = document.querySelectorAll("input");

input_elements.forEach((element) => {
    element.addEventListener("keyup", function () {
        element.setAttribute("value", element.value);
    })
})