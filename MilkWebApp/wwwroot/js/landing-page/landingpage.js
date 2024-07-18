window.onload = function () {
    var header = document.querySelector(".header");
    var sticky = header.offsetHeight;

    window.onscroll = function () {
        if (window.scrollY > sticky - 100) {
            header.classList.add("sticky");
        } else {
            header.classList.remove("sticky");
        }

        checkIfInView('special-1');
        checkIfInView('special-2');
    }

    checkIfInView('special-1');
    checkIfInView('special-2');
}

function checkIfInView(id) {
    var element = document.getElementById(id);
    var position = element.getBoundingClientRect();

    // checking whether fully visible
    if (position.top < window.innerHeight && position.bottom >= 0) {
        element.classList.add('animate');
    }
}

