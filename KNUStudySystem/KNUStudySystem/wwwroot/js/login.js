function checkInput() {
    var input = document.getElementsByTagName("input");
    for (let index = 0; index < input.length; index++) {
        var label = document.getElementsByTagName("label");
        if (input[index].value != 0) {
            label[index].style.display = "none";
        }
        else {
            input[index].addEventListener("mouseover", function () {
                label[index].style.display = "flex";
                label[index].style.transition = "0.5s";
                label[index].style.top = "10px";
            });
            input[index].addEventListener("mouseout", function () {
                label[index].style.top = "30px";
                label[index].style.display = "flex";
                label[index].style.transition = "0.5s";
            });
        }
    }
}
setInterval(checkInput, 100);